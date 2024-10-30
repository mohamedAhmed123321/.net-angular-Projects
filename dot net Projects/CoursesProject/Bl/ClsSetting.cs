using CoursesProject.Migrations;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bl
{
    public class ClsSetting : Interface1<TableSetting>
    {
        CoursesContext ctx;
        public ClsSetting(CoursesContext Ctx)
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

        public TableSetting GetById(int ColumId)
        {
            try
            {
                return ctx.TbSettings.Where(a => a.Id == ColumId).FirstOrDefault();
            }
            catch
            {
                return new TableSetting();
            }

        }

        public List<TableSetting> GettAll()
        {
            try
            {
                return ctx.TbSettings.Where(a => a.CurrentState == 0).ToList();
            }
            catch
            {
                return new List<TableSetting> { new TableSetting() };
            }

        }

        public List<Details> GettAllWithData()
        {
            try
            {
                return ctx.vwdetails.Where(a => a.CurrentState == 0).ToList();
            }
            catch
            {
                return new List<Details> { new Details() };
            }

        }

        public void Save(TableSetting colum)
        {
            var Item = colum;
            if (Item.Id != 0)
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

                ctx.TbSettings.Add(Item);
            }
            ctx.SaveChanges();
        }


    }
}
