using System.Security.Claims;

using HouseManager.Core.Contracts;
using HouseManager.Core.Models.HouseOrganization;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using static HouseManager.Constants.SessionConstants;
using static HouseManager.Infrastructure.Constants.UserRoles;


namespace HouseManager.Controllers
{
	public class HouseOrganizationsController(
		IHouseOrganizationService houseOrgService,
		IUnitService unitService) : BaseController
	{
		public IActionResult Index()
		{
			return View();
		}

		#region Add New House Organization
		[HttpGet]
		public IActionResult Add()
		{
			var model = new HouseOrganizationFormModel();

			model.CreatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(HouseOrganizationFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var id = await houseOrgService.AddAsync(model);

			return RedirectToAction(nameof(Details), "HouseOrganizations", new { id });
		}
		#endregion

		#region Edit House Organization
		[HttpGet]
		[Authorize(Roles = AdminRole)]
		public async Task<IActionResult> Edit(int id)
		{
			if (!await houseOrgService.ExistById(id))
			{
				return BadRequest();
			}

			var model = await houseOrgService
								.GetByIdReadOnly(id)
								.FirstOrDefaultAsync();

			return View(model);
		}

		[HttpPost]
		[Authorize(Roles = AdminRole)]
		public async Task<IActionResult> Edit(HouseOrganizationFormModel model)
		{
			if (!await houseOrgService.ExistById(model.Id))
			{
				return BadRequest();
			}

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
		public async Task<IActionResult> Details(int id)
		{
			if (!await houseOrgService.ExistById(id))
			{
				return BadRequest();
			}

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

			return View(model);
		}
		#endregion

		#region Manage House Organization
		[HttpGet]
		[Authorize(Roles = AdminRole)]
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

			HttpContext.Session.SetString(ManagedHouseOrgName, houseOrgName.Name);
			HttpContext.Session.SetInt32(ManagedHouseOrgId, id);

			return RedirectToAction(nameof(Details), new { id });
		}
		#endregion
	}
}
