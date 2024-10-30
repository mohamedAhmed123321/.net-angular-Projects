
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Domains.Tables;

namespace E_commerce.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string lang = HttpContext.Session.GetString("lang");
            if (lang != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            }
                
        }

    }
}
