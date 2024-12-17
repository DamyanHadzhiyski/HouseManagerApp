using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Pagination;
using HouseManager.Core.Models.Unit;
using HouseManager.Filters;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using static HouseManager.Core.Constants.DataConstants;

namespace HouseManager.Areas.Cashier.Controllers
{
	public class UnitsController(
		HouseManagerDbContext context,
		IHouseOrganizationService houseOrgService,
		IUnitService unitService,
		IOccupantService occupantService) : CashierController
	{
		#region Show Unit Details
		[HttpGet]
		public async Task<IActionResult> Details(int id, int activeCurrentPage = 1, int inactiveCurrentPage = 1)
		{
			var model = await unitService.GetDetailsByIdAsync(id);

			var activeOccupants = await occupantService
										.GetAllActiveReadOnlyAsync(id)
										.OrderByDescending(o => o.IsOwner)
										.ToListAsync();

			var inactiveOccupants = await occupantService
										.GetAllInactiveReadOnlyAsync(id)
										.ToListAsync();

			model.ActiveOccupants = new ActiveOccupantsPageViewModel
			{
				CurrentPage = activeCurrentPage,
				TotalElements = activeOccupants.Count,
				ElementsPerPage = DefaultElementsOnPage,
				Collection = activeOccupants
								   .Skip((activeCurrentPage - 1) * DefaultElementsOnPage)
								   .Take(DefaultElementsOnPage)
								   .ToList()
			};

			model.InactiveOccupants = new InactiveOccupantsPageViewModel
			{
				CurrentPage = inactiveCurrentPage,
				TotalElements = inactiveOccupants.Count,
				ElementsPerPage = DefaultElementsOnPage,
				Collection = inactiveOccupants
								   .Skip((inactiveCurrentPage - 1) * DefaultElementsOnPage)
								   .Take(DefaultElementsOnPage)
								   .ToList()
			};

			return View(model);
		}
		#endregion

		#region Show All Units
		[HttpGet]
		[HouseOrganizationExists("id")]
		public async Task<IActionResult> All(int houseOrgId, int currentPage = 1)
		{
			var units = unitService.GetAllFromHOAsync(houseOrgId);

			var model = new UnitsPageViewModel
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
	}
}
