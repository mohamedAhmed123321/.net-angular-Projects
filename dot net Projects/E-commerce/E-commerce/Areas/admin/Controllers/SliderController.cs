using Bl.Classes;
using Bl.Enumorations;
using Bl.InterFaces;
using Domains.Tables;
using E_commerce.Utlities;
using Microsoft.AspNetCore.Mvc;
using PayPalCheckoutSdk.Orders;
using Serilog;

namespace E_commerce.Areas.admin.Controllers
{
    public class SliderController : BaseController
    {
        #region privateFields
        private readonly BusinessLayerInterFace<TbSlider> _clsSlider;
        #endregion
        #region ctor
        public SliderController(BusinessLayerInterFace<TbSlider> _clsSliders)
        {
            _clsSlider = _clsSliders;
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
                var skill = _clsSlider.GetAll();
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
                TbSlider skill = new TbSlider();
                if (Id != null)
                {
                    skill = _clsSlider.GetById(Convert.ToInt32(Id));

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
        public async Task<IActionResult> Edit(TbSlider Slider,List<IFormFile>Files)
        {
            try
            {
                 ModelState.Remove("CreatedBy");
                if (!ModelState.IsValid)
                    return View("Edit", Slider);

                var (messageOrImage, isValid) = await Helper.UploadImage(Files, Slider.ImageName, "Slider");
                if (!isValid)
                {
                    ModelState.AddModelError("ImageName", messageOrImage);
                    return View("Edit", Slider);
                }
                Slider.ImageName = messageOrImage;

               bool result = _clsSlider.Save(Slider);
                TempData[result ? "Success" : "Failed"] = result ? "Saved successfully" : "Save operation failed";
                return result ? RedirectToAction("List") : View("Edit", Slider);
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
                bool result = _clsSlider.ChangeState(Id, EntityStateEnum.Deleted);
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
