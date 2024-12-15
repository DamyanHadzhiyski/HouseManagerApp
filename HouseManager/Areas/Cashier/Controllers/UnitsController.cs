using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Pagination;
using HouseManager.Core.Models.Unit;
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

			int elementsPerPage = ElementsOnPage;

			model.ActiveOccupants = new ActiveOccupantsPageViewModel
			{
				CurrentPage = activeCurrentPage,
				TotalElements = activeOccupants.Count,
				ElementsPerPage = elementsPerPage,
				Collection = activeOccupants
								   .Skip((activeCurrentPage - 1) * elementsPerPage)
								   .Take(elementsPerPage)
								   .ToList()
			};

			model.InactiveOccupants = new InactiveOccupantsPageViewModel
			{
				CurrentPage = inactiveCurrentPage,
				TotalElements = inactiveOccupants.Count,
				ElementsPerPage = elementsPerPage,
				Collection = inactiveOccupants
								   .Skip((inactiveCurrentPage - 1) * elementsPerPage)
								   .Take(elementsPerPage)
								   .ToList()
			};

			return View(model);
		}
		#endregion

		#region Show All Units
		[HttpGet]
		public async Task<IActionResult> All(int houseOrgId)
		{
			if (!await houseOrgService.ExistById(houseOrgId))
			{
				return BadRequest();
			}

			var model = await unitService.GetAllFromHOAsync(houseOrgId);

			ViewBag.HouseOrgId = houseOrgId;

			return View(model);
		}
		#endregion
	}
}
