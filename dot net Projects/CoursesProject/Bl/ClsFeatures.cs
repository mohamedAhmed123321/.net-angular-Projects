using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class ClsFeatures : Interface1<TbFeature>
    {
        CoursesContext ctx;
        public ClsFeatures(CoursesContext Ctx)
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

        public TbFeature GetById(int ColumId)
        {
            try
            {
                return ctx.TbFeatures.Where(a => a.Featuresd == ColumId).FirstOrDefault();
            }
            catch
            {
                return new TbFeature();
            }

        }

        public List<TbFeature> GettAll()
        {
            try
            {
                return ctx.TbFeatures.ToList();
            }
            catch
            {
                return new List<TbFeature> { new TbFeature() };
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

        public void Save(TbFeature colum)
        {
            var Item = colum;
            if (Item.Featuresd != 0)
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

                ctx.TbFeatures.Add(Item);
            }
            ctx.SaveChanges();
        }
    }
}
