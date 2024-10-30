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
    public class ClsPayment : Interface1<TbPaymentMethod>
    {
        CoursesContext ctx;
        public ClsPayment(CoursesContext Ctx)
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

        public TbPaymentMethod GetById(int ColumId)
        {
            try
            {
                return ctx.TbPaymentMethods.Where(a => a.PaymentMethodId == ColumId).FirstOrDefault();
            }
            catch
            {
                return new TbPaymentMethod();
            }

        }

        public List<TbPaymentMethod> GettAll()
        {
            try
            {
                return ctx.TbPaymentMethods.Where(a => a.CurrentState == 0).ToList();
            }
            catch
            {
                return new List<TbPaymentMethod> { new TbPaymentMethod() };
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

        public void Save(TbPaymentMethod colum)
        {
            var Item = colum;
            if (Item.PaymentMethodId != 0)
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
                ctx.TbPaymentMethods.Add(Item);
            }
            ctx.SaveChanges();
        }


    }
}
