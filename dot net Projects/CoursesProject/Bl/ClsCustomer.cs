using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursesProject.Migrations;
using Domains;
namespace Bl
{
    public class ClsCustomer : Interface1<TbCustomer>
    {
        CoursesContext ctx;
        public ClsCustomer( CoursesContext Ctx )
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

        public TbCustomer GetById(int ColumId)
        {
            try
            {
                return ctx.TbCustomers.Where(a => a.CustomerId == ColumId).FirstOrDefault();
            }
            catch
            {
                return new TbCustomer();
            }
           
        }

        public List<TbCustomer> GettAll()
        {
            try
            {
                return ctx.TbCustomers.Where(a => a.CurrentState == 0).ToList();
            }
            catch
            {
                return new List<TbCustomer> { new TbCustomer() };
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

        public void Save(TbCustomer colum)
        {
           var Item = colum;
            if (Item.CustomerId != 0)
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
          
                ctx.TbCustomers.Add(Item);
            }
            ctx.SaveChanges();
        }
    }
}
