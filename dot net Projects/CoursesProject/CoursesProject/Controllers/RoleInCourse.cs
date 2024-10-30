using Bl;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoursesProject.Controllers
{
    [Authorize]
    public class RoleInCourse : Controller
    {
        Interface1<TbCustomer> ClsTbCustomer;
        ICustomerCourse<TbCustomerCourse> ClsCustomerCourse;
  
        public RoleInCourse(Interface1<TbCustomer> ClsTbCustomers, ICustomerCourse<TbCustomerCourse> ClsCustomerCourses)
        {
            ClsTbCustomer= ClsTbCustomers;
            ClsCustomerCourse= ClsCustomerCourses;
       
        }
        public IActionResult Role(int id)
        {
            var CurrentUserEmail = User.FindFirstValue(ClaimTypes.Name);
            var Customer= ClsTbCustomer.GettAll().Where(a=>a.Email== CurrentUserEmail).FirstOrDefault();
            TbCustomerCourse oTbCustomerCourse = new TbCustomerCourse()
            {
                
                CourseId = id,
                CustomerId = Customer.CustomerId,
          
                 
            };
            ClsCustomerCourse.Save(oTbCustomerCourse);


            return Redirect("~/");
        }

    }
}
