using Bl;
using Domains;
using Microsoft.AspNetCore.Mvc;

namespace CoursesProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class CourseTypeController : Controller
    {
        #region privateFields
        private readonly Interface1<TbCourseType> _clsCourseType;
        #endregion
        #region ctor
        public CourseTypeController(Interface1<TbCourseType> _clsCourseTypes)
        {
            _clsCourseType = _clsCourseTypes;
        }
        #endregion
        #region Actions
        public IActionResult List()
        {
            try
            {

                var skill = _clsCourseType.GettAll();
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
                TbCourseType skill = new TbCourseType();
                if (Id != null)
                {
                    skill = _clsCourseType.GetById(Convert.ToInt32(Id));

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
        public IActionResult Edit(TbCourseType Supplier)
        {
            try
            {
                ModelState.Remove("CreatedBy");
                if (!ModelState.IsValid)
                    return View("Edit", Supplier);

                _clsCourseType.Save(Supplier);
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
                _clsCourseType.Delete(Id);
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
