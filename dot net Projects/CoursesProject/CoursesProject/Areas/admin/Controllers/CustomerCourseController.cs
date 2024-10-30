using Bl;
using Microsoft.AspNetCore.Mvc;
using Domains;
using CoursesProject.Utlities;

namespace CoursesProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class CustomerCourseController : Controller
    {
        #region privateField
        private readonly ICustomerCourse<TbCustomerCourse> _clsCustomerCourse;
        private readonly Interface1<TbPaymentMethod> _clsPayment;
        private readonly Interface1<TbCustomer> _clsCustomer; 
        private readonly Interface1<TbCourse> _clsCourse;
        #endregion
        public CustomerCourseController(Interface1<TbCourse> _clsCourses, ICustomerCourse<TbCustomerCourse> _clsCustomerCourses, Interface1<TbPaymentMethod> _clsPayments, Interface1<TbCustomer> _clsCustomers)
        {
            _clsCourse = _clsCourses;
            _clsCustomerCourse = _clsCustomerCourses;
            _clsPayment = _clsPayments;
            _clsCustomer = _clsCustomers;

        }
        public IActionResult List()
        {
            var courses = _clsCustomerCourse.GettAll();
            return View(courses);
        }
        public IActionResult Edit(int? id)
        {
            TbCustomerCourse Course = new TbCustomerCourse();
            ViewBag.payment = _clsPayment.GettAll();
            ViewBag.Customer = _clsCustomer.GettAll();
            ViewBag.Course = _clsCourse.GettAll();
            if (id != 0)
            {
                Course = _clsCustomerCourse.GetById(Convert.ToInt32(id));

            }
            return View(Course);
        }
        public IActionResult Delete(int id)
        {

            _clsCustomerCourse.Delete(id);
            return RedirectToAction("List");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TbCustomerCourse Course)
        {
            //if (!ModelState.IsValid)
            //    return View("Edit", Course);

            _clsCustomerCourse.Save(Course);

            return RedirectToAction("List");
        }
    }
}
