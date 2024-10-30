using Bl;
using CoursesProject.Migrations;
using CoursesProject.Utlities;
using Domains;
using CoursesProject.Utlities;
using Microsoft.AspNetCore.Mvc;


namespace CoursesProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class SettingController : Controller
    {
        #region privateFields
        private readonly Interface1<TableSetting> _clsSetting;
        #endregion
        #region ctor
        public SettingController(Interface1<TableSetting> _clsSettings)
        {
            _clsSetting = _clsSettings;
        }
        #endregion

        #region Actions
        public IActionResult List()
        {
            try
            {
                var colums = _clsSetting.GettAll();
                return View(colums);
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
                TableSetting skill = new TableSetting();
                if (Id != 0)
                {
                    skill = _clsSetting.GetById(Convert.ToInt32(Id));

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
        public async Task<IActionResult> Save(TableSetting Setting, List<IFormFile> Files)
        {
            try
            {

                //if (!ModelState.IsValid)
                //    return View("Edit", Setting);
                var (messageOrImage, isValid) = await Helper.UploadImage(Files, Setting.Logo, "Setting");
                if (!isValid)
                {
                    ModelState.AddModelError("ImageName", messageOrImage);
                    return View("Edit", Setting);
                }
                Setting.Logo = messageOrImage;

                _clsSetting.Save(Setting);
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
                 _clsSetting.Delete(Id);
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
