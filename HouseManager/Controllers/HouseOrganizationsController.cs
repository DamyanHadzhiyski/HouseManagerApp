﻿using HouseManager.Core.Contracts;
using HouseManager.Core.Models.HouseOrganization;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Enums;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HouseManager.Controllers
{
	public class HouseOrganizationsController(
		IHouseOrganizationService houseService,
		HouseManagerDbContext context) : BaseController
	{
		#region Show All House Organizations
		[HttpGet]
		public async Task<IActionResult> All()
		{
			var model = await houseService
							.GetAllReadOnly()
							.Select(h => new HouseOrganizationViewModel
							{
								Id = h.Id,
								Name = h.Name,
								Address = h.Address,
								TownName = h.Town.Name
							})
							.ToListAsync();

			return View(model);
		}
		#endregion

		#region Add New House Organization
		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var model = new HouseOrganizationFormModel();

			ViewBag.Towns = await GetTowns();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(HouseOrganizationFormModel model)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.Towns = await GetTowns();

				ModelState.AddModelError(string.Empty, "");

				return View(model);
			}

			await houseService.AddHouseOrganizationAsync(model);

			return RedirectToAction(nameof(All));
		}
		#endregion

		#region Edit House Organization
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var houseDb = await houseService.GetHouseOrganizationById(id);

			if (houseDb == null)
			{
				//TODO: Redirect to custom error page
				return View();
			}

			var model = new HouseOrganizationFormModel
			{
				Id = houseDb.Id,
				Name = houseDb.Name,
				Address = houseDb.Address,
				TownId = houseDb.TownId
			};

			ViewBag.Towns = await GetTowns();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(HouseOrganizationFormModel model)
		{
			var houseDb = await houseService.GetHouseOrganizationById(model.Id);

			if (!ModelState.IsValid)
			{
				ViewBag.Towns = await GetTowns();
				//TODO: Redirect to custom error page
				return View(model);
			}

			await houseService.EditHouseOrganizationAsync(model);

			return RedirectToAction(nameof(All), "HouseOrganizations");
		}
		#endregion

		#region Show House Organization Details
		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			if (!await houseService.ExistByIdAsync(id))
			{
				return RedirectToAction(nameof(All), "HouseOrganizations");
			}

			var houseOrgDb = await houseService
									.GetHouseOrganizationById(id);

			var model = new HouseOrganizationDetailViewModel
			{
				Id = houseOrgDb.Id,
				Name = houseOrgDb.Name,
				Address = houseOrgDb.Address,
				TownName = houseOrgDb.Town.Name,
				PresidentName = houseOrgDb.Managers
											.Where(m => m.IsActive && m.Position.Equals(ManagerPosition.President))
											.Select(m => m.Name).FirstOrDefault() ?? "Not Assigned",
				CashierName = houseOrgDb.Managers
											.Where(m => m.IsActive && m.Position.Equals(ManagerPosition.Cashier))
											.Select(m => m.Name).FirstOrDefault() ?? "Not Assigned",
				UnitsCount = houseOrgDb.Units.Count.ToString(),
				OccupantsCount = houseOrgDb.Units.Sum(u => u.Occupants.Count).ToString(),
			};

			return View(model);
		}
		#endregion

		#region Private Methods
		private async Task<ICollection<SelectListItem>> GetTowns()
		{
			return await context.Towns
								.Select(t => new SelectListItem()
								{
									Text = t.Name,
									Value = t.Id.ToString()

								})
								.AsNoTracking()
								.ToListAsync();
		}
		#endregion
	}
}
