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
using Domains.SpResult;
using Microsoft.Data.SqlClient;

namespace Bl.Classes
{
    public class ClsFillteredItem : SpFilteredItemInterFace<Sp_GetFillteredItems_Result>
    {

        private readonly LapShopContext context;
        public ClsFillteredItem(LapShopContext ctx)
        {
            context = ctx;
        }

        public List<Sp_GetFillteredItems_Result> GetItems(int pageNum, int count, string title, int? ramSize, string categoryName, float? minPrice, float? maxPrice)
        {
            // Create parameters for the stored procedure
            var pageNumberParam = new SqlParameter("@PageNumber", pageNum);
            var countParam = new SqlParameter("@Count", count);
            var titleParam = new SqlParameter("@Title", string.IsNullOrEmpty(title) ? DBNull.Value : (object)title);
            var ramSizeParam = new SqlParameter("@RamSize", ramSize.HasValue ? (object)ramSize.Value : DBNull.Value);
            var categoryNameParam = new SqlParameter("@CategoryName", string.IsNullOrEmpty(categoryName) ? DBNull.Value : (object)categoryName);
            var minPriceParam = new SqlParameter("@MinPrice", minPrice.HasValue ? (object)minPrice.Value : DBNull.Value);
            var maxPriceParam = new SqlParameter("@MaxPrice", maxPrice.HasValue ? (object)maxPrice.Value : DBNull.Value);

            // Call the stored procedure using FromSqlRaw with the parameters
            return context.FilteredItems_Result
                .FromSqlRaw("EXEC SpGetFilteredItems @CategoryName, @Title, @RamSize, @MinPrice, @MaxPrice, @PageNumber, @Count",
                            categoryNameParam, titleParam, ramSizeParam, minPriceParam, maxPriceParam, pageNumberParam, countParam)
                .ToList();
        }


    }
}
