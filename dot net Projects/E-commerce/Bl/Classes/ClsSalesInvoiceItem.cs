using Bl.InterFaces;
using Domains.Tables;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Bl.Enumorations;
using Serilog;
using Bl.Context;
using Domains;

namespace Bl.Classes
{
    public class ClsSalesInvoiceItem : SalesInvoiceItemInterFace
    {
        private readonly LapShopContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClsSalesInvoiceItem(IHttpContextAccessor _httpContextAccessors, LapShopContext ctx)
        {
            context = ctx;
            _httpContextAccessor = _httpContextAccessors;
        }
        public List<TbSalesInvoiceItem> GetSalesInvoiceId(int id)
        {
            try
            {
                var Items = context.TbSalesInvoiceItems.Where(a => a.InvoiceId == id).ToList();
                if (Items == null)
                    return new List<TbSalesInvoiceItem>();
                else
                    return Items;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public bool Save(IList<TbSalesInvoiceItem> Items, int salesInvoiceId, bool isNew)
        {
            var userEmail = _httpContextAccessor.HttpContext.User.Identity.Name;
            List<TbSalesInvoiceItem> dbInvoiceItems =
                GetSalesInvoiceId(Items[0].InvoiceId);

            foreach (var interfaceItems in Items)
            {
                var dbObject = dbInvoiceItems.Where(a => a.InvoiceItemId == interfaceItems.InvoiceItemId).FirstOrDefault();
                if (dbObject != null)
                {
                    interfaceItems.CreatedDate = DateTime.Now;
                    interfaceItems.CreatedBy = userEmail;
                    context.Entry(dbObject).State = EntityState.Modified;
                }

                else
                {
                    interfaceItems.CreatedDate = DateTime.Now;
                    interfaceItems.CreatedBy= userEmail;
                    interfaceItems.CurrentState= Convert.ToInt32(EntityStateEnum.Exists);
                    interfaceItems.InvoiceId = salesInvoiceId;
                    context.TbSalesInvoiceItems.Add(interfaceItems);
                }
            }

            foreach (var item in dbInvoiceItems)
            {
                var interfaceObject = Items.Where(a => a.InvoiceItemId == item.InvoiceItemId).FirstOrDefault();
                if (interfaceObject == null)
                    context.TbSalesInvoiceItems.Remove(item);
            }

            context.SaveChanges();
            return true;
        }
    }
}
