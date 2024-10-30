using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class ClsCourseType : Interface1<TbCourseType>
    {
        CoursesContext ctx;
        public ClsCourseType(CoursesContext Ctx)
        {
            ctx = Ctx;
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

        public TbCourseType GetById(int ColumId)
        {
            try
            {
                return ctx.TbCourseTypes.Where(a => a.CourseTypeId == ColumId).FirstOrDefault();
            }
            catch
            {
                return new TbCourseType();
            }

        }

        public List<TbCourseType> GettAll()
        {
            try
            {
                return ctx.TbCourseTypes.Where(a=>a.CurrentState==0).ToList();
            }
            catch
            {
                return new List<TbCourseType> { new TbCourseType() };
            }

        }

        public List<Details> GettAllWithData()
        {
            try
            {
                return ctx.vwdetails.ToList();
            }
            catch
            {
                return new List<Details> { new Details() };
            }

        }

        public void Save(TbCourseType colum)
        {
            var Item = colum;
            if (Item.CourseTypeId != 0)
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

                ctx.TbCourseTypes.Add(Item);
            }
            ctx.SaveChanges();
        }
    }
}
