using Bl;
using Microsoft.AspNetCore.Mvc;
using Domains;
using CoursesProject.Utlities;

namespace CoursesProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class CoursesController : Controller
    {
        Interface1<TbCourse> ClsCourse;
        Interface1<TbCourseType> ClsCourseType;
        Interface1<TbInstructor> ClsInstructor;
        public CoursesController(Interface1<TbCourse> ClsCourses, Interface1<TbCourseType> ClsCourseTypes, Interface1<TbInstructor> ClsInstructors)
        {
            ClsCourse = ClsCourses;
            ClsCourseType= ClsCourseTypes;
            ClsInstructor= ClsInstructors;

        }
        public IActionResult List()
        {
            var model = ClsCourse.GettAllWithData();
            return View(model);
        }
        public IActionResult Edit(int? id)
        {
            TbCourse Course=new TbCourse();
            ViewBag.CourseType = ClsCourseType.GettAll();
            ViewBag.Instructors = ClsInstructor.GettAll();
            if (id != 0)
            {
                Course = ClsCourse.GetById(Convert.ToInt32(id));

            }
            return View(Course);
        }
        public IActionResult Delete(int id)
        {
            
            ClsCourse.Delete(id);
            return RedirectToAction("List");
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TbCourse Course, List<IFormFile> Files)
        {
            //if (!ModelState.IsValid)
            //    return View("Edit", Course);

            var (messageOrImage, isValid) = await Helper.UploadImage(Files,Course.ImageName, "CoursesImage");
            if (!isValid)
            {
                ModelState.AddModelError("ImageName", messageOrImage);
                return View("Edit", Course);
            }
            Course.ImageName = messageOrImage;
            ClsCourse.Save(Course);

            return RedirectToAction("List");
        }
    }
}
