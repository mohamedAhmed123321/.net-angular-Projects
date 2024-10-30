using Bl.Classes;
using Bl.Enumorations;
using Bl.InterFaces;
using E_commerce.Controllers;
using E_commerce.Models;
using Domains.Tables;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace E_commerce.Areas.admin.Controllers
{
    public class UserController : BaseController
    {
        #region private Fields
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserInterFasce<ApplicationUser> _clsUser;
        #endregion

        #region Ctor

        public UserController(UserInterFasce<ApplicationUser> _users, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _clsUser = _users;
        }

        #endregion
        public async Task<IActionResult> List()
        {
            try
            {
                if (TempData.ContainsKey("Success"))
                {
                    ViewBag.Success = TempData["Success"].ToString();
                }
                if (TempData.ContainsKey("Failed"))
                {
                    ViewBag.Failed = TempData["Failed"].ToString();
                }
                var users = _clsUser.GetAll();
                return View(users);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                throw new Exception(ex.Message);

            }
        }
        public async Task<IActionResult> Edit(string Id)
        {
            try
            {
                if (TempData.ContainsKey("Failed"))
                {
                    ViewBag.Failed = TempData["Failed"].ToString();
                }
                ApplicationUserModel user = new ApplicationUserModel();
                if (!string.IsNullOrEmpty(Id))
                {
                    var myUser = await _clsUser.GetById(Id);
                    user.FirstName = myUser.FirstName;
                    user.LastName = myUser.LastName;
                    user.Email = myUser.Email;
                    user.UserId = myUser.Id;
                    user.Password = myUser.PasswordHash;
                }


                return View(user);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return RedirectToAction("Error", "Home");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ApplicationUserModel User)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Edit", User);
                ApplicationUser user = new ApplicationUser()
                {
                    Id = User.UserId,
                    FirstName = User.FirstName,
                    LastName = User.LastName,
                    Email = User.Email,
                    UserName = User.Email,
                    PasswordHash = User.Password


                };

                bool result = await _clsUser.Save(user);
                if (result)
                {
                    TempData["Success"] = "Saved successfully";
                    return RedirectToAction("List");
                }

                else
                {
                    ViewBag.Failed = "Save operation failed.";
                    return View("Edit", User);

                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return RedirectToAction("Error", "Home");
            }

        }
        public async Task<IActionResult> Delete(string Id)
        {
            try
            {
                bool result = await _clsUser.ChangeState(Id, EntityStateEnum.Deleted);
                if (result)
                {
                    TempData["Success"] = "Deleted successfully";
                    return RedirectToAction("List");
                }
                else
                {
                    TempData["Failed"] = "Delete operation failed.";
                    return RedirectToAction("List");

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
