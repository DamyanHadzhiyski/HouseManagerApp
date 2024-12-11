using System.Globalization;

using HouseManager.Core.Contracts;
using HouseManager.Core.Services;

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
	name: "ManagementEndTerm",
	pattern: "Management/EndTerm/{id}",
	defaults: new { Controller = "Management", Action = "EndTerm" });

app.MapControllerRoute(
	name: "ManagementAll",
	pattern: "Management/All/{houseOrgId}",
	defaults: new { Controller = "Management", Action = "All" });

app.MapControllerRoute(
	name: "AddOccupant",
	pattern: "Occupant/Add/{unitId}",
	defaults: new { Controller = "Occupant", Action = "Add" });

app.MapControllerRoute(
	name: "OccupantPages",
	pattern: "Units/Details/{id}/{activeCurrentPage}/{inactiveCurrentPage}",
	defaults: new { Controller = "Units", Action = "Details" });

app.MapControllerRoute(
	name: "FinancesPages",
	pattern: "Finances/Index/{houseOrgId}/{incomesCurrentPage}/{expensesCurrentPage}",
	defaults: new { Controller = "Finances", Action = "Index"});

app.MapControllerRoute(
	name: "NewIncome",
	pattern: "Finances/{action}/{houseOrgId?}",
	defaults: new { Controller = "Finances", Action = "NewIncome" });

app.MapDefaultControllerRoute();

app.MapRazorPages();

app.Run();
