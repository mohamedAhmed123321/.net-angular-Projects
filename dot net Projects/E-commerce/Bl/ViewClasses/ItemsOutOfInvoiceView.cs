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
    public class ItemsOutOfInvoiceView : ViewInterFace<VwItemsOutOfInvoice>
    {
        private readonly LapShopContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ItemsOutOfInvoiceView(IHttpContextAccessor _httpContextAccessors, LapShopContext ctx)
        {
            context = ctx;
            _httpContextAccessor = _httpContextAccessors;
        }
        public List<VwItemsOutOfInvoice> GetAll()
        {
            try
            {
                List<VwItemsOutOfInvoice> photos = context.VwItemsOutOfInvoices.Where(a => a.CurrentState == Convert.ToInt32(EntityStateEnum.Exists)).ToList();
                return photos;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return new List<VwItemsOutOfInvoice>();
            }
        }

        public VwItemsOutOfInvoice GetById(int Id)
        {
            try
            {
                VwItemsOutOfInvoice item = new VwItemsOutOfInvoice();
                return item;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return new VwItemsOutOfInvoice();
            }
        }

    }
}
