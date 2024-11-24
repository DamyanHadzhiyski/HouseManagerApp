using HouseManager.Core.Contracts;
using HouseManager.Core.Models.HouseOrganization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace HouseManager.Controllers
{
	public class HouseOrganizationsController(
		IHouseOrganizationService houseOrgService,
		IMemoryCache cache) : BaseController
	{
		#region Add New House Organization
		[HttpGet]
		public IActionResult Add()
		{
			var model = new HouseOrganizationFormModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(HouseOrganizationFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await houseOrgService.AddAsync(model);

			return RedirectToAction(nameof(All));
		}
		#endregion

		#region Edit House Organization
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			if (!await houseOrgService.ExistById(id))
			{
				return BadRequest();
			}

			var model = await houseOrgService
								.GetByIdReadOnly(id)
								.Select(ho => new HouseOrganizationFormModel
								{
									Id = ho.Id,
									Name = ho.Name,
									Address = ho.Address,
									Town = ho.Town
								})
								.FirstOrDefaultAsync();

			return View(model);
		}

		[HttpPost]
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

			return RedirectToAction(nameof(All), "HouseOrganizations");
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

			return View(model);
		}
		#endregion

		#region Show All House Organizations
		[HttpGet]
		public async Task<IActionResult> All()
		{
			var model = await houseOrgService
							.GetAllReadOnly()
							.ToListAsync();

			return View(model);
		}
		#endregion

		[HttpGet]
		public async Task<IActionResult> Manage(int id)
		{
			var houseOrg = await houseOrgService
								.GetByIdAsync(id);

			if (houseOrg == null)
			{
				BadRequest();
			}

			cache.Set("ManagedHouseOrgName", houseOrg.Name);
			cache.Set("ManagedHouseOrgId", id);

			return RedirectToAction(nameof(All), "Units", new { houseOrgId = id });
		}
	}
}
