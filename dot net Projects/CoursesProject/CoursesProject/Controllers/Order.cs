using Bl;
using CoursesProject.Models;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CoursesProject.Controllers
{
    [Authorize]
    public class Order : Controller
    {
        Interface1<TbCourse> OclsCourse;
        UserManager<ApplicationUser> _userManager;
        public Order(Interface1<TbCourse> OclsCourses, UserManager<ApplicationUser> userManager)
        {
            OclsCourse = OclsCourses;
            _userManager = userManager;
        }
        public IActionResult Cart()
        {
            string sesstionCart = string.Empty;
            if (HttpContext.Request.Cookies[User.FindFirstValue(ClaimTypes.NameIdentifier)] != null)
                sesstionCart = HttpContext.Request.Cookies[User.FindFirstValue(ClaimTypes.NameIdentifier)];
            var cart = JsonConvert.DeserializeObject<ShoppingCart>(sesstionCart);
            return View(cart);
        }
        public IActionResult AddToCart(int CourseId)
        {
            ShoppingCart cart;

            string CookyName = User.FindFirstValue(ClaimTypes.NameIdentifier);


            if (HttpContext.Request.Cookies[CookyName] != null)
                cart = JsonConvert.DeserializeObject<ShoppingCart>(HttpContext.Request.Cookies[CookyName]);
            else
                cart = new ShoppingCart();

            var item = OclsCourse.GetById(CourseId);

            var itemInList = cart.lstItems.Where(a => a.CourseId == CourseId).FirstOrDefault();

            if (itemInList != null)
            {
                return Redirect("~/");
            }
            else
            {
                cart.lstItems.Add(new ShoppingCartItem
                {
                    CourseId = item.CourseId,
                    CourseName = item.CourseName,
                    Price = item.Price,
                    ImageName = item.ImageName,
                    Qty = 1,
                    Total = item.Price
                });
            }
            cart.Total = item.Price;


            HttpContext.Response.Cookies.Append(CookyName, JsonConvert.SerializeObject(cart));

            return RedirectToAction("Cart");
        }
    
        public async Task AddToOrder(int itemId, int Qty)
        {
            ShoppingCart order;
            string CookyName = User.FindFirstValue(ClaimTypes.NameIdentifier)+"order";


            if (HttpContext.Request.Cookies[CookyName] != null)
                order = JsonConvert.DeserializeObject<ShoppingCart>(HttpContext.Request.Cookies[CookyName]);
            else
                order = new ShoppingCart();

            var item = OclsCourse.GetById(itemId);

            var itemInList = order.lstItems.Where(a => a.CourseId == itemId).FirstOrDefault();

            if (itemInList != null)
            {
                itemInList.Qty += Qty;
                itemInList.Total = itemInList.Qty * itemInList.Price;
            }
            else
            {
                order.lstItems.Add(new ShoppingCartItem
                {
                    CourseId = item.CourseId,
                    CourseName = item.CourseName,
                    Price = item.Price,
                    ImageName = item.ImageName,
                    Qty = 1,
                    Total = item.Price
                });
            }
            order.Total = order.lstItems.Sum(a => a.Total);

            HttpContext.Response.Cookies.Append(CookyName, JsonConvert.SerializeObject(order));
            //return RedirectToAction("Cart");
        }

        [Authorize]
        public IActionResult CheckOut()
        {
            string sesstionCart = string.Empty;
            if (HttpContext.Request.Cookies[User.FindFirstValue(ClaimTypes.NameIdentifier)] != null)
                sesstionCart = HttpContext.Request.Cookies[User.FindFirstValue(ClaimTypes.NameIdentifier)];
            var cart = JsonConvert.DeserializeObject<ShoppingCart>(sesstionCart);
            return View(cart);
        }
        public async Task<IActionResult> OrderSuccess()
        {
            #region getCart
            string sesstionCart = string.Empty;
            if (HttpContext.Request.Cookies[User.FindFirstValue(ClaimTypes.NameIdentifier)] != null)
                sesstionCart = HttpContext.Request.Cookies[User.FindFirstValue(ClaimTypes.NameIdentifier)];
            var cart = JsonConvert.DeserializeObject<ShoppingCart>(sesstionCart);
            #endregion

            #region Save And clear cart
            if (cart != null)
            {
           
                foreach (var item in cart.lstItems)
                {
                    await AddToOrder(item.CourseId, item.Qty);
                }
                HttpContext.Response.Cookies.Append(User.FindFirstValue(ClaimTypes.NameIdentifier), "", new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(-1) // Set expiration date in the past
                });
            }

            #endregion

            #region getOrder
            string sesstionOrder = string.Empty;
            if (HttpContext.Request.Cookies[User.FindFirstValue(ClaimTypes.NameIdentifier) + "order"] != null)
                sesstionOrder = HttpContext.Request.Cookies[User.FindFirstValue(ClaimTypes.NameIdentifier) + "order"];
            var order = JsonConvert.DeserializeObject<ShoppingCart>(sesstionOrder);
            #endregion

            return RedirectToAction("MyOrders");
        }
        public IActionResult MyOrders()
        {
            string sesstionOrder = string.Empty;
            if (HttpContext.Request.Cookies[User.FindFirstValue(ClaimTypes.NameIdentifier) + "order"] != null)
                sesstionOrder = HttpContext.Request.Cookies[User.FindFirstValue(ClaimTypes.NameIdentifier) + "order"];
            var order = JsonConvert.DeserializeObject<ShoppingCart>(sesstionOrder);
            return View(order);
        }
    }
}
