using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursesProject.Migrations;
using Domains;
namespace Bl
{
    public class ClsCourse : Interface1<TbCourse>
    {
        CoursesContext ctx;
        public ClsCourse( CoursesContext Ctx )
        {
            ctx=Ctx;
        }
        public void Delete(int id)
        {
            try 
            {
                var colum = GetById(id);
                colum.CurrentState = 1;

                ctx.Entry(colum).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();
            }
            catch (Exception e) { }
        }

        public TbCourse GetById(int ColumId)
        {
            try
            {
                return ctx.TbCourses.Where(a => a.CourseId == ColumId).FirstOrDefault();
            }
            catch
            {
                return new TbCourse();
            }
           
        }

        public List<TbCourse> GettAll()
        {
            try
            {
                return ctx.TbCourses.Where(a => a.CurrentState == 0).ToList();
            }
            catch
            {
                return new List<TbCourse> { new TbCourse() };
            }
            
        }

        public List<Details> GettAllWithData()
        {
            try
            {
                return ctx.vwdetails.Where(a=>a.CurrentState==0).ToList();
            }
            catch
            {
                return new List<Details> { new Details() };
            }
       
        }

        public void Save(TbCourse colum)
        {
           var Item = colum;
            if (Item.CourseId != 0)
            {
                Item.UpdatedBy = "de";
                Item.UpdatedDate = DateTime.Now;
                Item.CreatedBy = string.Empty;

                ctx.Entry(Item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            }
            else
            {

                Item.CreatedBy = string.Empty;
                Item.CreatedDate = DateTime.Now;
                Item.Video = "https://youtu.be/vf9oXM8o360";
                Item.Time = "0";
                Item.Lectures = "0";
                Item.SkillLevel = "beginner";
                ctx.TbCourses.Add(Item);
            }
            ctx.SaveChanges();
        }
    }
}
