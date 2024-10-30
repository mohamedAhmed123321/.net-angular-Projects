using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_commerce.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApiCartController : ControllerBase
    {
        
        // GET: api/<ApiCartController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ApiCartController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApiCartController>
        [HttpPost]
        public ApiResponseModel<string> UpdateCart([FromBody] UpdateCartModel Model)
        {

                try
                {
                ApiResponseModel<string> response = new ApiResponseModel<string>();
                    string sesstionCart = HttpContext.Request.Cookies["Cart"];
                    var cart = JsonConvert.DeserializeObject<ShoppingCartModel>(sesstionCart);
                    var itemInList = cart.lstItems.Where(a => a.ItemId == Model.ItemId).FirstOrDefault();
                    itemInList.Qty= Model.Qty;
                    itemInList.Total = itemInList.Qty * itemInList.Price;
                    cart.Total = cart.lstItems.Sum(a => a.Total);

                    HttpContext.Response.Cookies.Append("Cart", JsonConvert.SerializeObject(cart));

                response.IsSuccess = true;
                return response;
                }
                catch (Exception ex)
                {
                    Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return new ApiResponseModel<string> { IsSuccess = false };
                }
            
        }

        // POST api/<ApiCartController>
        [HttpPost]
        public ApiResponseModel<string> RemoveFromCart([FromBody] int itemId)
        {
            try
            {
                ApiResponseModel<string> response = new ApiResponseModel<string>();

                string sesstionCart = HttpContext.Request.Cookies["Cart"];
                var cart = JsonConvert.DeserializeObject<ShoppingCartModel>(sesstionCart);
                var itemInList = cart.lstItems.Where(a => a.ItemId == itemId).FirstOrDefault();

                cart.lstItems.Remove(itemInList);
                cart.Total = cart.lstItems.Sum(a => a.Total);

                HttpContext.Response.Cookies.Append("Cart", JsonConvert.SerializeObject(cart));
                //return RedirectToAction("Cart");
                response.IsSuccess = true;
                response.Data =new List<string>();
                return response;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return new ApiResponseModel<string> { IsSuccess = false };
            }

        }


        // DELETE api/<ApiCartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
