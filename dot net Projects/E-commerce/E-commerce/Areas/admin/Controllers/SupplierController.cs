using Bl.Classes;
using Bl.Enumorations;
using Bl.InterFaces;
using Domains.Tables;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace E_commerce.Areas.admin.Controllers
{
    public class SupplierController : BaseController
    {
        #region privateFields
        private readonly BusinessLayerInterFace<TbSupplier> _clsSUpplier;
        #endregion
        #region ctor
        public SupplierController(BusinessLayerInterFace<TbSupplier> _clsSUppliers)
        {
            _clsSUpplier = _clsSUppliers;
        }
        #endregion
        #region Helper Methods
        private void LoadTempDataMessages()
        {
            if (TempData.ContainsKey("Success"))
            {
                ViewBag.Success = TempData["Success"].ToString();
            }
            if (TempData.ContainsKey("Failed"))
            {
                ViewBag.Failed = TempData["Failed"].ToString();
            }
        }

        private void LogError(Exception ex)
        {
            Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
        }
        #endregion
        #region Actions
        public IActionResult List()
        {
            try
            {
                LoadTempDataMessages();
                var skill = _clsSUpplier.GetAll();
                return View(skill);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return RedirectToAction("Error", "Home");
            }

        }
        public IActionResult Edit(int? Id)
        {
            try
            {
                TbSupplier skill = new TbSupplier();
                if (Id != null)
                {
                    skill = _clsSUpplier.GetById(Convert.ToInt32(Id));

                }

                return View(skill);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return RedirectToAction("Error", "Home");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TbSupplier Supplier)
        {
            try
            {
                ModelState.Remove("CreatedBy");
                if (!ModelState.IsValid)
                    return View("Edit", Supplier);

                bool result = _clsSUpplier.Save(Supplier);
                TempData[result ? "Success" : "Failed"] = result ? "Saved successfully" : "Save operation failed";
                return result ? RedirectToAction("List") : View("Edit", Supplier);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }
        public IActionResult Delete(int Id)
        {
            try
            {
                bool result = _clsSUpplier.ChangeState(Id, EntityStateEnum.Deleted);
                TempData[result ? "Success" : "Failed"] = result ? "Deleted successfully" : "Delete operation failed.";
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        } 
        #endregion
    }
}
