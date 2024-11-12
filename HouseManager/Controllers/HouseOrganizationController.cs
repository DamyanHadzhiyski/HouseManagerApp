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

			var newHouseOrganization = new HouseOrganization()
			{
				Name = model.Name,
				Address = model.Address,
				TownId = model.TownId
			};

			await context.HouseOrganizations.AddAsync(newHouseOrganization);
			await context.SaveChangesAsync();

			return RedirectToAction(nameof(All));
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
