using System.Security.Claims;

using HouseManager.Core.Contracts;
using HouseManager.Core.Models.HouseOrganization;
using HouseManager.Core.Models.Pagination;
using HouseManager.Filters;
using HouseManager.Infrastructure.Data;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using static HouseManager.Constants.SessionConstants;
using static HouseManager.Infrastructure.Constants.UserRoles;
using static HouseManager.Core.Constants.DataConstants;

namespace HouseManager.Areas.Creator.Controllers
{
	public class HouseOrganizationsController(
		IHouseOrganizationService houseOrgService,
		IUnitService unitService,
		IUserService userService,
		HouseManagerDbContext context) : CreatorController
	{
		#region Edit House Organization
		[HttpGet]
		[HouseOrganizationExists("id")]
		public async Task<IActionResult> Edit(int id)
		{
			var model = await houseOrgService
								.GetByIdReadOnly(id)
								.FirstOrDefaultAsync();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(HouseOrganizationFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await houseOrgService.EditAsync(model);

			return RedirectToAction(nameof(Details), "HouseOrganizations", new { id = model.Id, area = "President" });
		}
		#endregion

		#region Show House Organization Details
		[HttpGet]
		[HouseOrganizationExists("id")]
		public async Task<IActionResult> Details(int id, int currentPage = 1)
		{
			var model = await houseOrgService
								.GetDetailsByIdReadOnly(id)
								.FirstOrDefaultAsync();

			var units = unitService.GetAllFromHOAsync(id);

			model.Units = new UnitsPageViewModel
			{
				CurrentPage = currentPage,
				ElementsPerPage = DefaultElementsOnPage,
				TotalElements = units.Count(),
				Collection = await units
										.Skip((currentPage - 1) * DefaultElementsOnPage)
										.Take(DefaultElementsOnPage)
										.ToListAsync()
			};

			return View(model);
		}
		#endregion

		#region Show All House Organizations
		[HttpGet]
		public async Task<IActionResult> All()
		{
			var model = new List<HouseOrganizationViewModel>();

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			var ids = await context.UsersManagers
									.Where(um => um.UserId == userId)
									.Select(um => um.ManagerId)
									.ToListAsync();

			model = await houseOrgService
								.GetAllManagedByAsync(ids)
								.ToListAsync();

			await userService.SetCurrentRoleAsync(userId, PresidentRole);

			HttpContext.Session.SetInt32(SideBarOpen, 1);

			return View("~/Views/HouseOrganizations/All.cshtml", model);
		}
		#endregion

		#region Manage House Organization
		[HttpGet]
		[Authorize(Roles = CreatorRole)]
		[HouseOrganizationExists("id")]
		public async Task<IActionResult> Manage(int id)
		{
			var houseOrgName = await houseOrgService
								.GetByIdReadOnly(id)
								.Select(ho => new
								{
									ho.Name
								})
								.FirstOrDefaultAsync();

			if (houseOrgName == null)
			{
				BadRequest();
			}

			HttpContext.Session.SetString(HouseOrgName, houseOrgName.Name);
			HttpContext.Session.SetInt32(HouseOrgId, id);

			return RedirectToAction(nameof(Details), new { id });
		}
		#endregion
	}
}
