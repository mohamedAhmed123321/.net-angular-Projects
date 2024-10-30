using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public interface ICustomerCourse<t>
    {
        public List<t> GettAll();
        public List<VwCustomerCourses> GetAllCustomerCourses();
        public void Delete(int id);
        public void Save(t Colum);
        public t GetById(int ColumId);


    }
    public class ClsCustomerCourses : ICustomerCourse<TbCustomerCourse>
    {
        CoursesContext ctx;
        Interface1<TbCourse> ClsCourse;
        public ClsCustomerCourses(CoursesContext Ctx, Interface1<TbCourse> ClsCourses)
        {
            ctx = Ctx;
            ClsCourse = ClsCourses;
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

        public TbCustomerCourse GetById(int ColumId)
        {
            try
            {
                return ctx.TbCustomerCourses.Where(a => a.CustomerCourseId == ColumId).FirstOrDefault();
            }
            catch
            {
                return new TbCustomerCourse();
            }

        }

        public List<TbCustomerCourse> GettAll()
        {
            try
            {
                return ctx.TbCustomerCourses.Where(a => a.CurrentState == 0).ToList();
            }
            catch
            {
                return new List<TbCustomerCourse> { new TbCustomerCourse() };
            }

        }
        public void Save(TbCustomerCourse Colum)
        {
            try
            {
                var Item = Colum;
                if (Item.CustomerCourseId != 0)
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
                    
                    ctx.TbCustomerCourses.Add(Item);

                }


                ctx.SaveChanges();

            }

            catch (Exception ex)
            { 
            }
        }

        public List<VwCustomerCourses> GetAllCustomerCourses()
        {
            return ctx.VwCoustomersCourses.ToList();
        }
    }
}
