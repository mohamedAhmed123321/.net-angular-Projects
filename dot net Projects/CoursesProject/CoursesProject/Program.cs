using Microsoft.EntityFrameworkCore;
using Bl;
using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region EntityFrameWork
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CoursesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;

}).AddEntityFrameworkStores<CoursesContext>(); 
#endregion

#region CustomServices
builder.Services.AddScoped<Interface1<TbCourse>, ClsCourse>();
builder.Services.AddScoped<Interface1<TableSetting>, ClsSetting>();
builder.Services.AddScoped<Interface1<TbPaymentMethod>, ClsPayment>();
builder.Services.AddScoped<Interface1<TbFeature>, ClsFeatures>();
builder.Services.AddScoped<Interface1<TbInstructor>, ClsIntructor>();
builder.Services.AddScoped<Interface1<TbCourseType>, ClsCourseType>();
builder.Services.AddScoped<Interface1<TbCustomer>, ClsCustomer>();
builder.Services.AddScoped<ICustomerCourse<TbCustomerCourse>, ClsCustomerCourses>();
#endregion

#region CookiesAndSession

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Users/AccessDenied";
    options.Cookie.Name = "Cookie";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
    options.LoginPath = "/Users/Login";
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    options.SlidingExpiration = true;
}); 
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
#region Routing

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}");



    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

 



}
);
#endregion

app.Run();
