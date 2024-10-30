using Bl;
using Domains;
using Microsoft.AspNetCore.Mvc;

namespace CoursesProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class CustomerController : Controller
    {
        #region privateFields
        private readonly Interface1<TbCustomer> _clsCustomer;
        #endregion
        #region ctor
        public CustomerController(Interface1<TbCustomer> _clsCustomers)
        {
            _clsCustomer = _clsCustomers;
        }
        #endregion
        #region Actions
        public IActionResult List()
        {
            try
            {
              
                var skill = _clsCustomer.GettAll();
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
                TbCustomer skill = new TbCustomer();
                if (Id != null)
                {
                    skill = _clsCustomer.GetById(Convert.ToInt32(Id));

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
        public IActionResult Edit(TbCustomer Supplier)
        {
            try
            {
                //ModelState.Remove("CreatedBy");
                //if (!ModelState.IsValid)
                //    return View("Edit", Supplier);

                 _clsCustomer.Save(Supplier);
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
              _clsCustomer.Delete(Id);
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
