using Bl;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoursesProject.Controllers
{
    [Authorize]
    public class Profile : Controller
    {
        Interface1<TbCustomer> ClsTbCustomer;
        ICustomerCourse<TbCustomerCourse> CustomersCourses;

        public Profile(Interface1<TbCustomer> ClsTbCustomers, ICustomerCourse<TbCustomerCourse> CustomersCoursess)
        {
            ClsTbCustomer = ClsTbCustomers;
            CustomersCourses = CustomersCoursess;

        }
        public IActionResult MyProfile()
        {
            var CurrentUserEmail = User.FindFirstValue(ClaimTypes.Name);
            var Customer = ClsTbCustomer.GettAll().Where(a => a.Email == CurrentUserEmail).FirstOrDefault();
            var AllData = CustomersCourses.GetAllCustomerCourses().Where(a=>a.CustomerId==Customer.CustomerId).ToList();
            
            if (AllData.Count == 0)
                return RedirectToAction("EmptyAccount");
            return View(AllData);
        }
        public IActionResult EmptyAccount() 
        {
            return View();
        }
    }
}
