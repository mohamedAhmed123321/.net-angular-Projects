using Bl.Classes;
using Bl.Enumorations;
using Bl.InterFaces;
using Domains.Tables;
using E_commerce.Utlities;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace E_commerce.Areas.admin.Controllers
{
    public class CategoryController : BaseController
    {
        #region privateFields
        private readonly BusinessLayerInterFace<TbCategory> _clsCategory;
        #endregion
        #region ctor
        public CategoryController(BusinessLayerInterFace<TbCategory> _clsCategorys)
        {
            _clsCategory = _clsCategorys;
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
                var colums = _clsCategory.GetAll();
                return View(colums);
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
                TbCategory skill = new TbCategory();
                if (Id != null)
                {
                    skill = _clsCategory.GetById(Convert.ToInt32(Id));

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
        public async  Task<IActionResult> Edit(TbCategory Category, List<IFormFile> Files)
        {
            try
            {
                ModelState.Remove("CreatedBy");
                if (!ModelState.IsValid)
                    return View("Edit", Category);

                var (messageOrImage, isValid) = await Helper.UploadImage(Files, Category.ImageName, "Category");
                if (!isValid)
                {
                    ModelState.AddModelError("ImageName", messageOrImage);
                    return View("Edit", Category);
                }
                Category.ImageName = messageOrImage;

                bool result = _clsCategory.Save(Category);
                TempData[result ? "Success" : "Failed"] = result ? "Saved successfully" : "Save operation failed";
                return result ? RedirectToAction("List") : View("Edit", Category);
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
                bool result = _clsCategory.ChangeState(Id, EntityStateEnum.Deleted);
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
