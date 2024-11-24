using System.Globalization;

using HouseManager.Core.Contracts;
using HouseManager.Core.Services;

using Microsoft.AspNetCore.Mvc;


CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

var builder = WebApplication.CreateBuilder(args);

//Add Session Config
builder.Services.AddMemoryCache();

// Add services to the container.
builder.Services.AddHouseManagerDbContext(builder.Configuration);
builder.Services.AddHouseManagerIdentity();

builder.Services.AddScoped<IHouseOrganizationService, HouseOrganizationService>();
builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<IUnitService, UnitService>();

builder.Services.AddControllersWithViews(options =>
{
	options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseExceptionHandler("/Error");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "AllUnits",
	pattern: "Units/All/{houseOrgId}",
	defaults: new { Controller = "Units", Action = "All" });

app.MapControllerRoute(
	name: "AddUnits",
	pattern: "Units/Add/{houseOrgId}",
	defaults: new { Controller = "Units", Action = "Add" });

app.MapControllerRoute(
	name: "AllManagers",
	pattern: "Managers/All/{houseOrgId}",
	defaults: new { Controller = "Managers", Action = "All" });

app.MapControllerRoute(
	name: "ManageHouseOrg",
	pattern: "HouseOrganizations/Manage/{id}",
	defaults: new { Controller = "HouseOrganizations", Action = "Manage" });

app.MapDefaultControllerRoute();

app.MapRazorPages();

app.Run();
