using System.Security.Claims;

using HouseManager.Core.Contracts;
using HouseManager.Core.Models.HouseOrganization;
using HouseManager.Filters;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using static HouseManager.Constants.SessionConstants;
using static HouseManager.Infrastructure.Constants.UserRoles;


namespace HouseManager.Controllers
{
	public class HouseOrganizationsController(
		IHouseOrganizationService houseOrgService,
		IUnitService unitService,
		IUserService userService) : Controller
	{
		#region Add New House Organization
		[HttpGet]
		[Authorize]
		public IActionResult Add()
		{
			var model = new HouseOrganizationFormModel
			{
				CreatorId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty
			};

			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Add(HouseOrganizationFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var id = await houseOrgService.AddAsync(model);

			await userService.AddToRoleAsync(model.CreatorId, CreatorRole);

			return RedirectToAction(nameof(Details), "HouseOrganizations", new { id });
		}
		#endregion

		#region Edit House Organization
		[HttpGet]
		[Authorize(Roles = AdminRole)]
		[HouseOrganizationExists("id")]
		public async Task<IActionResult> Edit(int id)
		{
			var model = await houseOrgService
								.GetByIdReadOnly(id)
								.FirstOrDefaultAsync();

			return View(model);
		}

		[HttpPost]
		[Authorize(Roles = AdminRole)]
		public async Task<IActionResult> Edit(HouseOrganizationFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await houseOrgService.EditAsync(model);

			return RedirectToAction(nameof(Details), "HouseOrganizations", new { id = model.Id });
		}
		#endregion

		#region Show House Organization Details
		[HttpGet]
		[Authorize]
		[HouseOrganizationExists("id")]
		public async Task<IActionResult> Details(int id)
		{
			var model = await houseOrgService
								.GetDetailsByIdReadOnly(id)
								.FirstOrDefaultAsync();

			model.Units = await unitService.GetAllFromHOAsync(id);

			return View(model);
		}
		#endregion

		#region Show All House Organizations
		[HttpGet]
		[Authorize(Roles = AdminRole)]
		public async Task<IActionResult> All()
		{
			var model = await houseOrgService
						.GetAllReadOnly()
						.ToListAsync();

			HttpContext.Session.SetInt32(SideBarOpen, 1);

			return View(model);
		}
		#endregion

		#region Manage House Organization
		[HttpGet]
		[Authorize(Roles = AdminRole)]
		[HouseOrganizationExists("id")]
		public async Task<IActionResult> Manage(int id)
		{
			var houseOrgName = await houseOrgService
										.GetNameByIdAsync(id);

			HttpContext.Session.SetString(HouseOrgName, houseOrgName);
			HttpContext.Session.SetInt32(HouseOrgId, id);

			return RedirectToAction(nameof(Details), new { id });
		}
		#endregion
	}
}
