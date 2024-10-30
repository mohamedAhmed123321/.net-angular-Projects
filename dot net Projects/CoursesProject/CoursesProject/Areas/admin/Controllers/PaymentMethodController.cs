using Bl;
using Domains;
using Microsoft.AspNetCore.Mvc;

namespace CoursesProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class PaymentMethodController : Controller
    {
        #region privateFields
        private readonly Interface1<TbPaymentMethod> _clsPayment;
        #endregion
        #region ctor
        public PaymentMethodController(Interface1<TbPaymentMethod> _clsPayments)
        {
            _clsPayment = _clsPayments;
        }
        #endregion
        #region Actions
        public IActionResult List()
        {
            try
            {

                var skill = _clsPayment.GettAll();
                return View(skill);
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", "Home");
            }

        }
        public IActionResult Edit(int? Id)
        {
            try
            {
                TbPaymentMethod skill = new TbPaymentMethod();
                if (Id != null)
                {
                    skill = _clsPayment.GetById(Convert.ToInt32(Id));

                }

                return View(skill);
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", "Home");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TbPaymentMethod Supplier)
        {
            try
            {
                ModelState.Remove("CreatedBy");
                if (!ModelState.IsValid)
                    return View("Edit", Supplier);
                Supplier.TbCustomerCourses = null;
                _clsPayment.Save(Supplier);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", "Home");
            }
        }
        public IActionResult Delete(int Id)
        {
            try
            {
                _clsPayment.Delete(Id);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
        #endregion
    }
}
