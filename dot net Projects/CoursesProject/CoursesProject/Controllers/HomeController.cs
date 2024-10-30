using CoursesProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Bl;
using Domains;
using System.Security.Claims;

namespace CoursesProject.Controllers
{
    public class HomeController : Controller
    {
        Interface1<TbCourse> oClsCourse;
        Interface1<TbCourseType> ClscourseType;
        Interface1<TbFeature> oClsFeatures;
        public HomeController(Interface1<TbCourseType> ClscourseTypes, Interface1<TbCourse> oClsCourses, Interface1<TbFeature> oClsFeaturess)
        {
            oClsCourse=oClsCourses;
            oClsFeatures=oClsFeaturess;
            ClscourseType = ClscourseTypes;

        }
        public IActionResult Index(int id)
        {
            ViewBag.CourseType = ClscourseType.GettAll();
            if (id != 0)
            {
                var model = oClsCourse.GettAllWithData().Where(a => a.CourseTypeId == id).ToList();
                return View(model);
            }
            else
            {
                var model = oClsCourse.GettAllWithData();
                return View(model);
            }

        }
        public IActionResult CourseDetails(int id) 
        {
            ViewBag.Features = oClsFeatures.GettAll().Where(a => a.CousreId == id);
            var Course = oClsCourse.GettAllWithData().Where(a=>a.CourseId==id).FirstOrDefault();
            return View(Course);
        }

    }
}