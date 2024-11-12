using HouseManager.Core.Contracts;
using HouseManager.Core.Models;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HouseManager.Controllers
{
	public class HouseOrganizationController(
		IHouseOrganizationService houseService,
		HouseManagerDbContext context) : Controller
	{
		[HttpGet]
		public async Task<IActionResult> All()
		{
			var model = await houseService
							.GetAllReadonlyAsync()
							.Select(h => new HouseOrganizationModel
							{
								Id = h.Id,
								Name = h.Name,
								Address = h.Address,
								TownName = h.Town.Name
							})
							.ToListAsync();

			return View(model);
		}

		#region Add New House Organization
		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var model = new HouseOrganizationModel();

			ViewBag.Towns = await GetTowns();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(HouseOrganizationModel model)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.Towns = await GetTowns();

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

			var model = new HouseOrganizationModel
			{
				Id = houseDb.Id,
				Name = houseDb.Name,
				Address = houseDb.Address,
				TownId = houseDb.TownId,
				TownName = houseDb.Town.Name
			};

			ViewBag.Towns = await GetTowns();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(HouseOrganizationModel model, int id)
		{
			var houseDb = await houseService.GetHouseOrganizationById(id);

			if (!ModelState.IsValid)
			{
				ViewBag.Towns = await GetTowns();
				//TODO: Redirect to custom error page
				return View(model);
			}

			await houseService.EditHouseOrganizationAsync(model, id);

			return RedirectToAction(nameof(All), "HouseOrganization");
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
