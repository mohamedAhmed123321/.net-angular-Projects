using Microsoft.AspNetCore.Mvc;
using CoursesProject.Models;
using Microsoft.AspNetCore.Identity;
using Bl;
using Domains;
namespace CoursesProject.Controllers
{
    public class Users : Controller
    {
        Interface1<TbCustomer> ClsCustomer;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        public Users(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, Interface1<TbCustomer> ClsCustomers)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            ClsCustomer = ClsCustomers;
        }
        public IActionResult Login(string returnUrl)
        {
            LoginModel model = new LoginModel()
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }
        public IActionResult Register(string returnUrl)
        {
            RegisterModel model = new RegisterModel()
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        public async Task<IActionResult> LoginOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return View("Register", model);

            ApplicationUser user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.Phone,
             

            };
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var loginResult = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
                    var myUser = await _userManager.FindByEmailAsync(user.Email);
                    TbCustomer customer = new TbCustomer() 
                    { CustomerName= model.FirstName,
                    Email= model.Email,
                    Phone=model.Phone,
                   
                    };
                    ClsCustomer.Save(customer);
                    if (loginResult.Succeeded)
                    {
                        if (string.IsNullOrEmpty(model.ReturnUrl))
                            return Redirect("~/");
                        else
                            return Redirect(model.ReturnUrl);
                    }
                        
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
            return View(new RegisterModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Email
            };
            try
            {
                var loginResult = await _signInManager.PasswordSignInAsync(user.Email, model.Password, true, true);
                if (loginResult.Succeeded)
                {
                    if (string.IsNullOrEmpty(model.ReturnUrl))
                        return Redirect("~/");
                    else
                        return Redirect(model.ReturnUrl);
                }
            }
            catch (Exception ex)
            {

            }
            return View(new LoginModel());
        }


        public IActionResult AccessDenied() 
        {
            return View();
        }
    }
}
