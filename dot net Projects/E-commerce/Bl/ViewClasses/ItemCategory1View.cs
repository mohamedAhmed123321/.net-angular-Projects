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
    public class ItemCategoryView1 : ViewInterFace<VwItemCategory1>
    {
        private readonly LapShopContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ItemCategoryView1(IHttpContextAccessor _httpContextAccessors, LapShopContext ctx)
        {
            context = ctx;
            _httpContextAccessor = _httpContextAccessors;
        }
        public List<VwItemCategory1> GetAll()
        {
            try
            {
                List<VwItemCategory1> photos = context.VwItemCategories1.Where(a => a.CurrentState == Convert.ToInt32(EntityStateEnum.Exists)).ToList();
                return photos;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return new List<VwItemCategory1>();
            }
        }

        public VwItemCategory1 GetById(int Id)
        {
            try
            {
                VwItemCategory1 item = context.VwItemCategories1.Where(a => a.ItemId == Id && a.CurrentState == Convert.ToInt32(EntityStateEnum.Exists)).FirstOrDefault();
                return item;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return new VwItemCategory1();
            }
        }

    }
}
