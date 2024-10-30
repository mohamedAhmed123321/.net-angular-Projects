using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Areas.admin.Controllers
{
    public class TransilateController : BaseController
    {
        public IActionResult Arabic()
        {
            HttpContext.Session.SetString("lang", "ar");
            return Redirect(Request.Headers["Referer"]);
        }  
        public IActionResult English()
        {
            HttpContext.Session.SetString("lang", "en-US");
            return Redirect(Request.Headers["Referer"]);
        }
    }
}
