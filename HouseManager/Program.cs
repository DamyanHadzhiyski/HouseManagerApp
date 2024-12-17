using System.Globalization;

using HouseManager.Core.Contracts;
using HouseManager.Core.Services;
using HouseManager.Filters;

using Microsoft.AspNetCore.Mvc;

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromSeconds(300);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});

builder.Services.AddHouseManagerDbContext(builder.Configuration);
builder.Services.AddHouseManagerIdentity();

builder.Services.AddScoped<IHouseOrganizationService, HouseOrganizationService>();
builder.Services.AddScoped<IManagementService, ManagementService>();
builder.Services.AddScoped<IUnitService, UnitService>();
builder.Services.AddScoped<IOccupantService, OccupantService>();
builder.Services.AddScoped<IFinanceService, FinanceService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAccessService, AccessService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddControllersWithViews(options =>
{
	options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error/500");
	app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
	app.UseHsts();
}
else
{
	app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "AddManager",
	pattern: "Managers/Add/{position}",
	defaults: new { Controller = "Managers", Action = "Add" });

app.MapControllerRoute(
	name: "ManagersAll",
	pattern: "Managers/All/{houseOrgId}/{presidentCurrentPage?}/{cashierCurrentPage?}",
	defaults: new { Controller = "Managers", Action = "All" });

app.MapControllerRoute(
	name: "AddOccupant",
	pattern: "Occupant/Add/{unitId}",
	defaults: new { Controller = "Occupant", Action = "Add" });

app.MapControllerRoute(
	name: "OccupantPages",
	pattern: "Units/Details/{id}/{activeCurrentPage?}/{inactiveCurrentPage?}",
	defaults: new { Controller = "Units", Action = "Details" });

app.MapControllerRoute(
	name: "AddUnit",
	pattern: "Units/Add/{houseOrgId}",
	defaults: new { Controller = "Units", Action = "Add" });

app.MapControllerRoute(
	name: "AllUnits",
	pattern: "Units/All/{houseOrgId}",
	defaults: new { Controller = "Units", Action = "All" });

app.MapControllerRoute(
	name: "NewIncome",
	pattern: "Finances/{action}/{houseOrgId?}",
	defaults: new { Controller = "Finances", Action = "NewIncome" });

app.MapControllerRoute(
	name: "RequestManagerAccess",
	pattern: "Access/RequestManagerAccess/{position}",
	defaults: new { Controller = "Access", Action = "RequestManagerAccess" });

app.MapDefaultControllerRoute();

app.MapRazorPages();

app.Run();
