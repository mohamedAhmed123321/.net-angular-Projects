﻿using Bl.InterFaces;
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
    public class ClsItemType : BusinessLayerInterFace<TbItemType>
    {
        private readonly LapShopContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClsItemType(IHttpContextAccessor _httpContextAccessors, LapShopContext ctx)
        {
            context = ctx;
            _httpContextAccessor = _httpContextAccessors;
        }
        public List<TbItemType> GetAll()
        {
            try
            {
                List<TbItemType> photos = context.TbItemTypes.Where(a => a.CurrentState == Convert.ToInt32(EntityStateEnum.Exists)).ToList();
                return photos;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return new List<TbItemType>();
            }
        }

        public TbItemType GetById(int Id)
        {
            try
            {
                TbItemType item = context.TbItemTypes.Where(a => a.ItemTypeId == Id && a.CurrentState == Convert.ToInt32(EntityStateEnum.Exists)).FirstOrDefault();
                return item;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return new TbItemType();
            }
        }
        public bool Save(TbItemType Article)
        {
            try
            {
                var userEmail = _httpContextAccessor.HttpContext.User.Identity.Name; // Get the email of the logged-in user
                if (Article.ItemTypeId == default(int))
                {
                    Article.CurrentState = Convert.ToInt32(EntityStateEnum.Exists);
                    Article.CreatedBy = userEmail;
                    Article.CreatedDate = DateTime.Now;
                    context.TbItemTypes.Add(Article);
                }
                else
                {
                    Article.UpdatedBy = userEmail;
                    Article.UpdatedDate = DateTime.Now;

                    context.Entry(Article).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return false;
            }
        }

        public bool ChangeState(int Id, EntityStateEnum EntityState)
        {
            try
            {
                var article = GetById(Id);
                article.CurrentState = Convert.ToInt32(EntityState);
                context.Entry(article).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return false;
            }
        }
    }
}
