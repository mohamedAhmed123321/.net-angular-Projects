using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class ClsIntructor : Interface1<TbInstructor>
    {
        CoursesContext ctx;
        public ClsIntructor(CoursesContext Ctx)
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

        public TbInstructor GetById(int ColumId)
        {
            try
            {
                return ctx.TbInstructors.Where(a => a.InstructorId == ColumId).FirstOrDefault();
            }
            catch
            {
                return new TbInstructor();
            }

        }

        public List<TbInstructor> GettAll()
        {
            try
            {
                return ctx.TbInstructors.Where(a => a.CurrentState == 0).ToList();
            }
            catch
            {
                return new List<TbInstructor> { new TbInstructor() };
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

        public void Save(TbInstructor colum)
        {
            var Item = colum;
            if (Item.InstructorId != 0)
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

                ctx.TbInstructors.Add(Item);
            }
            ctx.SaveChanges();
        }
    }
}
