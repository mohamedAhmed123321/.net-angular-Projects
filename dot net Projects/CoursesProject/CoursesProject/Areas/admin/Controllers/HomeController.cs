using Bl;
using Microsoft.AspNetCore.Mvc;
using Domains;
namespace CoursesProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        Interface1<TbCourse> courses;
        Interface1<TbCourseType> courseType;
        public HomeController(Interface1<TbCourse> course, Interface1<TbCourseType> courseTypes) 
        {
            courses = course;
            courseType = courseTypes;
        }
        public IActionResult Index()
        {
            var coursesll = courses.GettAll();

            return View();
        }
        public IActionResult Error()
        {
           
            return View();
        }
    }
}
