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
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http.HttpResults;
using Bl.Context;

namespace Bl.Classes
{
    public class ClsUserManager : UserInterFasce<ApplicationUser>
    {
        private readonly LapShopContext context;
        private readonly ILogger<ClsUserManager> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
       private readonly UserManager<ApplicationUser> _userManager;
        public ClsUserManager(UserManager<ApplicationUser> userManager, IHttpContextAccessor _httpContextAccessors, LapShopContext ctx, ILogger<ClsUserManager> logger)
        {
            context = ctx;
            _logger = logger;
            _userManager = userManager;
            _httpContextAccessor = _httpContextAccessors;
        }
        public List<ApplicationUser> GetAll()
        {
            try
            {
                List<ApplicationUser> items = _userManager.Users.Where(u => u.CurrentState == 1).ToList();
                return items;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return new List<ApplicationUser>();
            }
        }

        public async Task<ApplicationUser> GetById(string Id)
        {
            try
            {
                ApplicationUser item =await _userManager.FindByIdAsync(Id);
                return item;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return new ApplicationUser();
            }
        }
        public async Task<bool> Save(ApplicationUser User)
        {
            try
            {
                var userEmail = _httpContextAccessor.HttpContext.User.Identity.Name; // Get the email of the logged-in user
                if (string.IsNullOrEmpty(User.Id))
                {
                    User.Id = Guid.NewGuid().ToString();
                    User.CurrentState = Convert.ToInt32(EntityStateEnum.Exists);
                    User.CreatedBy = userEmail;
                    User.CreatedDate = DateTime.Now;
                   var result= await _userManager.CreateAsync(User, User.PasswordHash);
                    if (!result.Succeeded)
                        return false;
                }
                else
                {
                   var user = await _userManager.FindByIdAsync(User.Id);
                    user.FirstName = User.FirstName;
                    user.LastName = User.LastName;
                    user.Email = User.Email;
                    user.PasswordHash = User.PasswordHash;
                    User.UpdatedBy = userEmail;
                    User.UpdatedDate = DateTime.Now;
                    var result = await _userManager.UpdateAsync(user);
                    if (!result.Succeeded)
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return false;
            }
        }

        public async Task<bool> ChangeState(string Id, EntityStateEnum EntityState)
        {
            try
            {
                ApplicationUser user =await GetById(Id);
                user.CurrentState = Convert.ToInt32(EntityState);
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded) 
                    return false;
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
