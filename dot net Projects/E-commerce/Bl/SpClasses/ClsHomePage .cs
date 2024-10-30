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
    public class ClsHomePage : SpHomePageInterFace<Sp_GetHomePageData_Result>
    {

        private readonly LapShopContext context;
        public ClsHomePage(LapShopContext ctx)
        {
            context = ctx;
        }

        public List<Sp_GetHomePageData_Result> GetContent(int PageNum, int Count)
        {
            // Create parameters for the stored procedure
            var pageNumberParam = new SqlParameter("@PageNumber", PageNum);
            var countParam = new SqlParameter("@Count", Count);

            // Call the stored procedure using FromSqlRaw with the parameters

            return context.sp_GetHomePageData
                .FromSqlRaw("EXEC SpGetHomePageData @PageNumber, @Count", pageNumberParam, countParam)
                .ToList();
        }

    }
}
