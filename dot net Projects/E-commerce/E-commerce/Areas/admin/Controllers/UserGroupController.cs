using Bl.Classes;
using E_commerce.Controllers;
using E_commerce.Areas.admin.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace E_commerce.Areas.admin.Controllers
{
    public class UserGroupController : BaseController
    {
        #region privateFields
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<UserGroupController> _logger;

        #endregion
        #region ctor
        public UserGroupController(RoleManager<IdentityRole> RoleManager, UserManager<ApplicationUser> userManager, ILogger<UserGroupController> logger)
        {
            _roleManager = RoleManager;
            _logger = logger;
        } 
        #endregion
        public IActionResult List()
        {
            try
            {
                var roles = _roleManager.Roles.ToList();
                return View(roles);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return View("Error");
            }

        }

    }
}
