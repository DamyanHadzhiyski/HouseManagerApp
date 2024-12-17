using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Pagination;
using HouseManager.Core.Models.Unit;
using HouseManager.Filters;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using static HouseManager.Core.Constants.DataConstants;

namespace HouseManager.Controllers
{
	public class UnitsController(
		IUnitService unitService,
		IOccupantService occupantService) : BaseController
	{
		#region Add New Unit
		[HttpGet]
		[HouseOrganizationExists("houseOrgId")]
		public IActionResult Add(int houseOrgId)
		{
			var model = new UnitFormModel
			{
				HouseOrganizationId = houseOrgId
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(UnitFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var id = await unitService.AddAsync(model);

			return RedirectToAction("Details", "Units", new { id });
		}
		#endregion

		#region Edit Unit
		[HttpGet]
		[UnitExists]
		public async Task<IActionResult> Edit(int id)
		{
			var model = await unitService.GetByIdReadOnly(id)
											.FirstOrDefaultAsync();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(UnitFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			int id = await unitService.EditAsync(model);

			return RedirectToAction("Details", "Units", new { id });
		}
		#endregion

		#region Show Unit Details
		[HttpGet]
		[UnitExists]
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
				InactiveOccupantCurrentPage = inactiveCurrentPage,
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
				ActiveOccupantCurrentPage = activeCurrentPage,
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
		[HouseOrganizationExists("houseOrgId")]
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

			ViewBag.Controller = "Units";
			ViewBag.Action = "All";
			ViewBag.Id = houseOrgId;

			return View(model);
		}
		#endregion
	}
}
