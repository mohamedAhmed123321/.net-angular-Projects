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
using Domains.ViewResult;

namespace Bl.Classes
{
    public class ClsSalesInvoice :SalesInvoiceInterFace
    {
        private readonly LapShopContext context;
        private readonly SalesInvoiceItemInterFace _salesInvoiceItem;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClsSalesInvoice(IHttpContextAccessor _httpContextAccessors, LapShopContext ctx, SalesInvoiceItemInterFace salesInvoiceItem)
        {
            context = ctx;
            _httpContextAccessor = _httpContextAccessors;
            _salesInvoiceItem = salesInvoiceItem;
        }
   
        public List<VwSalesInvoice> GetAll()
        {
            try
            {
                return context.VwSalesInvoices.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public TbSalesInvoice GetById(int id)
        {
            try
            {
                var Item = context.TbSalesInvoices.Where(a => a.InvoiceId == id).FirstOrDefault();
                if (Item == null)
                    return new TbSalesInvoice();
                else
                    return Item;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public bool Save(TbSalesInvoice Item, List<TbSalesInvoiceItem> lstItems, bool isNew)
        {
            using var transaction = context.Database.BeginTransaction();
            try
            {
                Item.CurrentState = 1;
                if (isNew)
                {
                    Item.CreatedBy = "1";
                    Item.CreatedDate = DateTime.Now;
                    context.TbSalesInvoices.Add(Item);
                }

                else
                {
                    Item.UpdatedBy = "1";
                    Item.UpdatedDate = DateTime.Now;
                    context.Entry(Item).State = EntityState.Modified;
                }

                context.SaveChanges();
                _salesInvoiceItem.Save(lstItems, Item.InvoiceId, true);

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception();
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var Item = context.TbSalesInvoices.Where(a => a.InvoiceId == id).FirstOrDefault();
                if (Item != null)
                {
                    context.TbSalesInvoices.Remove(Item);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
