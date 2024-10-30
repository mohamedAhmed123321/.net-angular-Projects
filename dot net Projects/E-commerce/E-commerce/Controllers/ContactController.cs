using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
