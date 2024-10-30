using Bl.Classes;
using Bl.Enumorations;
using Bl.InterFaces;
using Domains.Tables;
using E_commerce.Utlities;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace E_commerce.Areas.admin.Controllers
{
    public class ItemTypeController : BaseController
    {
        #region privateFields
        private readonly BusinessLayerInterFace<TbItemType> _clsItemType;
        #endregion
        #region ctor
        public ItemTypeController(BusinessLayerInterFace<TbItemType> _clsItemTypes)
        {
            _clsItemType = _clsItemTypes;
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
                var colums = _clsItemType.GetAll();
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
                TbItemType skill = new TbItemType();
                if (Id != null)
                {
                    skill = _clsItemType.GetById(Convert.ToInt32(Id));

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
        public async Task<IActionResult> Edit(TbItemType ItemType,List<IFormFile> Files)
        {
            try
            {
                ModelState.Remove("CreatedBy");
                if (!ModelState.IsValid)
                    return View("Edit", ItemType);

                var (messageOrImage, isValid) = await Helper.UploadImage(Files, ItemType.ImageName, "ItemType");
                if (!isValid)
                {
                    ModelState.AddModelError("ImageName", messageOrImage);
                    return View("Edit", ItemType);
                }
                ItemType.ImageName = messageOrImage;

                bool result = _clsItemType.Save(ItemType);
                TempData[result ? "Success" : "Failed"] = result ? "Saved successfully" : "Save operation failed";
                return result ? RedirectToAction("List") : View("Edit", ItemType);
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
                bool result = _clsItemType.ChangeState(Id, EntityStateEnum.Deleted);
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
