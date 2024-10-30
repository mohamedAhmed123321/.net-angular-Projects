
#region Using
using Bl.Classes;
using Bl.Context;
using Bl.InterFaces;
using Domains.SpResult;
using Domains.Tables;
using Domains.ViewResult;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
#endregion


#region builder
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
}); ; 
#endregion

#region EntityFrameWork
builder.Services.AddDbContext<LapShopContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = false;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<LapShopContext>(); 
#endregion

#region CustomServices

#region ClassesService

builder.Services.AddScoped<BusinessLayerInterFace<TbBusinessInfo>, ClsBusinessInfo>();
builder.Services.AddScoped<BusinessLayerInterFace<TbCategory>, ClsCategory>();
builder.Services.AddScoped<BusinessLayerInterFace<TbCustomer>, ClsCustomer>();
builder.Services.AddScoped<BusinessLayerInterFace<TbItem>, ClsItem>();
builder.Services.AddScoped<BusinessLayerInterFace<TbItemDiscount>, ClsItemDisCount>();
builder.Services.AddScoped<BusinessLayerInterFace<TbItemImage>, ClsItemImage>();
builder.Services.AddScoped<BusinessLayerInterFace<TbItemType>, ClsItemType>();
builder.Services.AddScoped<BusinessLayerInterFace<TbO>, ClsOs>();
builder.Services.AddScoped<BusinessLayerInterFace<TbPage>, ClsPage>();
builder.Services.AddScoped<SalesInvoiceInterFace, ClsSalesInvoice>();
builder.Services.AddScoped<SalesInvoiceItemInterFace, ClsSalesInvoiceItem>();
builder.Services.AddScoped<BusinessLayerInterFace<TbSetting>, ClsSetting>();
builder.Services.AddScoped<BusinessLayerInterFace<TbSlider>, ClsSlider>();
builder.Services.AddScoped<BusinessLayerInterFace<TbSupplier>, ClsSupplier>();
builder.Services.AddScoped<BusinessLayerInterFace<TbPurchaseInvoice>, CslPurchaseInvoice>();
builder.Services.AddScoped<BusinessLayerInterFace<TbPurchaseInvoiceItem>, CslPurchaseInvoiceItem>();
builder.Services.AddScoped<UserInterFasce<ApplicationUser>, ClsUserManager>();
builder.Services.AddSingleton<ClsPayPal>();
#endregion

#region ViewClasses

builder.Services.AddScoped<ViewInterFace<VwItem>, ItemView>();
builder.Services.AddScoped<ViewInterFace<VwItemCategory>, ItemCategoryView>();
builder.Services.AddScoped<ViewInterFace<VwItemCategory1>, ItemCategoryView1>();
builder.Services.AddScoped<ViewInterFace<VwSalesInvoice>, SalesInvoiceView>();
builder.Services.AddScoped<ViewInterFace<VwItemsOutOfInvoice>, ItemsOutOfInvoiceView>();
#endregion

#region Procedure

builder.Services.AddScoped<SpHomePageInterFace<Sp_GetHomePageData_Result>, ClsHomePage>(); 
builder.Services.AddScoped<SpFilteredItemInterFace<Sp_GetFillteredItems_Result>, ClsFillteredItem>();

#endregion




#endregion

#region Sesstion and cookies
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();



builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Users/AccessDenied";
    options.Cookie.Name = "Cookie";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(360);
    options.LoginPath = "/Users/Login";
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    options.SlidingExpiration = true;
});
#endregion
#region Loggers
var loggerConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(loggerConfig).CreateLogger();

#endregion

#region AppSetting
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
app.MapControllers();
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
#endregion


