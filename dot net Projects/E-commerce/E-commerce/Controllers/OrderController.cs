using Microsoft.AspNetCore.Mvc;
using E_commerce.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Bl.Classes;
using Bl.InterFaces;
using Domains.Tables;
using Serilog;

namespace E_commerce.Controllers
{
    public class OrderController : Controller
    {
        #region PrivateFeilds
        private readonly BusinessLayerInterFace<TbItem> _itemService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SalesInvoiceInterFace _salesInvoiceService;
        #endregion
        #region ctx
        public OrderController(BusinessLayerInterFace<TbItem> _itemServices, UserManager<ApplicationUser> userManager,
      SalesInvoiceInterFace _salesInvoiceServicesa)
        {
            _itemService = _itemServices;
            _userManager = userManager;
            _salesInvoiceService = _salesInvoiceServicesa;
        }
        #endregion
        public IActionResult Cart()
        {
            string sesstionCart = string.Empty;
            if (HttpContext.Request.Cookies["Cart"] != null)
                sesstionCart = HttpContext.Request.Cookies["Cart"];
            var cart = JsonConvert.DeserializeObject<ShoppingCartModel>(sesstionCart);
            return View(cart);
        }

        public IActionResult MyOrders()
        {
            string sesstionCart = string.Empty;
            if (HttpContext.Request.Cookies["order"] != null)
                sesstionCart = HttpContext.Request.Cookies["order"];
            var cart = JsonConvert.DeserializeObject<ShoppingCartModel>(sesstionCart);
            return View(cart);
        }
        [Authorize]
        public IActionResult CheckOut()
        {
            string sesstionCart = string.Empty;
            if (HttpContext.Request.Cookies["Cart"] != null)
                sesstionCart = HttpContext.Request.Cookies["Cart"];
            var cart = JsonConvert.DeserializeObject<ShoppingCartModel>(sesstionCart);
            return View(cart);
        }
        public async Task<IActionResult> OrderSuccess()
        {
            #region getCart
            string sesstionCart = string.Empty;
            if (HttpContext.Request.Cookies["Cart"] != null)
                sesstionCart = HttpContext.Request.Cookies["Cart"];
            var cart = JsonConvert.DeserializeObject<ShoppingCartModel>(sesstionCart);
            #endregion

            #region Save And clear cart
            if (cart != null)
            {
                await SaveOrder(cart);

                foreach (var item in cart.lstItems)
                {
                    await AddToOrder(item.ItemId,item.Qty);
                }
                HttpContext.Response.Cookies.Append("Cart", "", new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(-1) // Set expiration date in the past
                });
            }

            #endregion

            #region getOrder
            string sesstionOrder = string.Empty;
            if (HttpContext.Request.Cookies["order"] != null)
                sesstionCart = HttpContext.Request.Cookies["order"];
            var order = JsonConvert.DeserializeObject<ShoppingCartModel>(sesstionCart);
            #endregion

            return RedirectToAction("MyOrders");
        }

        public IActionResult AddToCart(int itemId)
        {
            ShoppingCartModel cart;
            if(HttpContext.Request.Cookies["Cart"]!=null)
                 cart = JsonConvert.DeserializeObject<ShoppingCartModel>(HttpContext.Request.Cookies["Cart"]);
            else
                cart = new ShoppingCartModel();

            var item = _itemService.GetById(itemId);

            var itemInList = cart.lstItems.Where(a => a.ItemId == itemId).FirstOrDefault();

            if (itemInList != null)
            {
                itemInList.Qty++;
                itemInList.Total = itemInList.Qty * itemInList.Price;
            }
            else
            {
                cart.lstItems.Add(new ShoppingCartItemModel
                {
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    ImageName=item.ImageName,
                    Price = item.SalesPrice,
                    Qty = 1,
                    Total = item.SalesPrice
                });
            }
            cart.Total = cart.lstItems.Sum(a => a.Total);

            HttpContext.Response.Cookies.Append("Cart", JsonConvert.SerializeObject(cart));

            return RedirectToAction("Cart");
        }
        public async Task AddToOrder(int itemId,int Qty)
        {
            ShoppingCartModel order;
            if (HttpContext.Request.Cookies["order"] != null)
                order = JsonConvert.DeserializeObject<ShoppingCartModel>(HttpContext.Request.Cookies["order"]);
            else
                order = new ShoppingCartModel();

            var item = _itemService.GetById(itemId);

            var itemInList = order.lstItems.Where(a => a.ItemId == itemId).FirstOrDefault();

            if (itemInList != null)
            {
                itemInList.Qty+= Qty;
                itemInList.Total = itemInList.Qty * itemInList.Price;
            }
            else
            {
                order.lstItems.Add(new ShoppingCartItemModel
                {
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    ImageName=item.ImageName,
                    Price = item.SalesPrice,
                    Qty = 1,
                    Total = item.SalesPrice
                });
            }
            order.Total = order.lstItems.Sum(a => a.Total);

            HttpContext.Response.Cookies.Append("order", JsonConvert.SerializeObject(order));

            //return RedirectToAction("Cart");
        }
        async Task SaveOrder(ShoppingCartModel ShopingCart)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);

                TbSalesInvoice invoice = new TbSalesInvoice()
                {
                    InvoiceDate = DateTime.Now,
                    CustomerId = Guid.Parse(user.Id),
                    DelivryDate = DateTime.Now.AddDays(5),
                    CreatedBy = user.Id,
                    CreatedDate = DateTime.Now
                };

                List<TbSalesInvoiceItem> invoiceItems = new List<TbSalesInvoiceItem>();
                foreach (var item in ShopingCart.lstItems)
                {
                    invoiceItems.Add(new TbSalesInvoiceItem()
                    {
                        InvoiceId = invoice.InvoiceId,
                        ItemId = item.ItemId,
                        Qty = item.Qty,
                        InvoicePrice = item.Price
                    });
                }

                _salesInvoiceService.Save(invoice, invoiceItems, true);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                throw;
            }
        }
    }
}
