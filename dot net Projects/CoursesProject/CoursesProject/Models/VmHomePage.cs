using Domains;
namespace CoursesProject.Models
{
    public class VmHomePage
    {
        public VmHomePage()
        {
            Slider = new List<Details>();
            AllCourses=new List<TbCourse>();
            Courses=new List<Details>();
            WorkShop=new List<Details>();
        }
        public List<Details> Slider { get; set; }
        public List<TbCourse> AllCourses { get; set; }
        public List<Details> Courses { get; set; }
        public List<Details> WorkShop { get; set; }
    }
}
