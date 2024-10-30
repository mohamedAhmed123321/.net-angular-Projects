using Bl.Classes;
using Bl.Enumorations;
using Bl.InterFaces;
using Domains.Tables;
using E_commerce.Utlities;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace E_commerce.Areas.admin.Controllers
{
    public class SettingController : BaseController
    {
        #region privateFields
        private readonly BusinessLayerInterFace<TbSetting> _clsSetting;
        #endregion
        #region ctor
        public SettingController(BusinessLayerInterFace<TbSetting> _clsSettings)
        {
            _clsSetting = _clsSettings;
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
                var colums = _clsSetting.GetAll();
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
                TbSetting skill = new TbSetting();
                if (Id != null)
                {
                    skill = _clsSetting.GetById(Convert.ToInt32(Id));

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
        public async Task<IActionResult> EditAsync(TbSetting Setting,List<IFormFile> Files)
        {
            try
            {
                ModelState.Remove("CreatedBy");
                if (!ModelState.IsValid)
                    return View("Edit", Setting);
                var (messageOrImage, isValid) = await Helper.UploadImage(Files, Setting.Logo, "Setting");
                if (!isValid)
                {
                    ModelState.AddModelError("ImageName", messageOrImage);
                    return View("Edit", Setting);
                }
                Setting.Logo = messageOrImage;

                bool result = _clsSetting.Save(Setting);
                TempData[result ? "Success" : "Failed"] = result ? "Saved successfully" : "Save operation failed";
                return result ? RedirectToAction("List") : View("Edit", Setting);
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
                bool result = _clsSetting.ChangeState(Id, EntityStateEnum.Deleted);
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
