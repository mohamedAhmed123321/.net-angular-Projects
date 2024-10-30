
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Areas.admin.Controllers
{
    public class HomeController : BaseController
    {
        //[Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
