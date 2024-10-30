using Microsoft.AspNetCore.Mvc;
using E_commerce.Models;
using Microsoft.AspNetCore.Identity;
using Bl;
using Bl.Classes;
using System.Diagnostics.Eventing.Reader;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Domains.Tables;
using Bl.InterFaces;
using System.Text;
using Microsoft.CodeAnalysis.CSharp;
using System.Buffers.Text;
using Bl.Enumorations;
namespace CompanySystem.Controllers
{
    public class Users : Controller
    {
        #region Context
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;

        public Users(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {

            _userManager = userManager;
            _signInManager = signInManager;

        }
        #endregion
        public IActionResult Login(string ReturnUrl)
        {
            LoginModel model = new LoginModel()
            {
                ReturnUrl = ReturnUrl
            };
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Home/Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel Model)
        {
            if (!ModelState.IsValid)
                return View("Login", Model);
            var _user = await _userManager.FindByEmailAsync(Model.Email);
            if (_user == null)
            {
                // User with the provided email does not exist
                ModelState.AddModelError("Email", "User with this email does not exist.");
                return View("Login", Model);
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = Model.Email,
                UserName = Model.Email
            };
            try
            {
                var loginResult = await _signInManager.PasswordSignInAsync(user.Email, Model.Password, true, true);
                if (loginResult.Succeeded)
                {
                    if (!string.IsNullOrEmpty(Model.ReturnUrl))
                        return Redirect(Model.ReturnUrl);
                    else
                            return Redirect("/Home/Index");
                }
                else
                {
                    // Sign-in failed due to incorrect password
                    ModelState.AddModelError("Password", "Incorrect password.");
                    return View("Login", Model);
                }
            }
            catch (Exception ex)
            {
                return Redirect("/Home/Index");
            }
        }
        public IActionResult Register(string ReturnUrl)
        {

            RigesterModel Model = new RigesterModel()
            {
                ReturnUrl = ReturnUrl
            };
            return View(Model);



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RigesterModel RegisterModel)
        {
            if (!ModelState.IsValid)
                return View("EmployerRegister", RegisterModel);
            var existingUser = await _userManager.FindByEmailAsync(RegisterModel.Email);
            if (existingUser != null)
            {
                // Email address is already in use
                ModelState.AddModelError("Email", "Email address is already exist.");
                return View("EmployerRegister", RegisterModel); // Return the view with the error message
            }
            ApplicationUser user = new ApplicationUser()
            {
                FirstName= RegisterModel.FirstName,
                LastName= RegisterModel.LastName,
                Email = RegisterModel.Email,
                UserName = RegisterModel.Email
               

            };

            try
            {
                user.CurrentState = (int)EntityStateEnum.Exists ;
                var result = await _userManager.CreateAsync(user, RegisterModel.Password);

                if (result.Succeeded)
                {
                    var loginResult = await _signInManager.PasswordSignInAsync(user, RegisterModel.Password, true, true);

                    if (loginResult.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(RegisterModel.ReturnUrl))
                            return Redirect(RegisterModel.ReturnUrl);
                        else
                            return Redirect("/Home/Index");
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        // Determine the property name associated with the error
                        string propertyName = ""; // Initialize with an empty string
                        if (error.Code.StartsWith("Email", StringComparison.OrdinalIgnoreCase))
                        {
                            // If the error code starts with "Email", associate it with the "Email" property
                            propertyName = "Email";
                        }
                        else if (error.Code.StartsWith("Password", StringComparison.OrdinalIgnoreCase))
                        {
                            // If the error code starts with "Password", associate it with the "Password" property
                            propertyName = "Password";
                        }
                        // Add the error to the ModelState with the associated property name
                        ModelState.AddModelError(propertyName, error.Description);
                    }
                    return View("EmployerRegister", RegisterModel); // Return the view with the error messages
                }
            }
            catch (Exception ex)
            {

            }
            return Redirect("/Home/Index");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
