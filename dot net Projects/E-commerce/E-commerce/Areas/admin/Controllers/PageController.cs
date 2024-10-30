using Bl.Classes;
using Bl.Enumorations;
using Bl.InterFaces;
using Domains.Tables;
using E_commerce.Utlities;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace E_commerce.Areas.admin.Controllers
{
    public class PageController : BaseController
    {
        #region privateFields
        private readonly BusinessLayerInterFace<TbPage> _clsPage;
        #endregion
        #region ctor
        public PageController(BusinessLayerInterFace<TbPage> _clsPages)
        {
            _clsPage = _clsPages;
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
                var colums = _clsPage.GetAll();
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
                TbPage skill = new TbPage();
                if (Id != null)
                {
                    skill = _clsPage.GetById(Convert.ToInt32(Id));

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
        public async Task<IActionResult> EditAsync(TbPage Page,List<IFormFile> Files)
        {
            try
            {
                ModelState.Remove("CreatedBy");
                if (!ModelState.IsValid)
                    return View("Edit", Page);

                var (messageOrImage, isValid) = await Helper.UploadImage(Files, Page.ImageName, "Page");
                if (!isValid)
                {
                    ModelState.AddModelError("ImageName", messageOrImage);
                    return View("Edit", Page);
                }
                Page.ImageName = messageOrImage;
                bool result = _clsPage.Save(Page);
                TempData[result ? "Success" : "Failed"] = result ? "Saved successfully" : "Save operation failed";
                return result ? RedirectToAction("List") : View("Edit", Page);
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
                bool result = _clsPage.ChangeState(Id, EntityStateEnum.Deleted);
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
