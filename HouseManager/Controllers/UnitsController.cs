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
		[HouseOrganizationExists("houseOrgId")]
		public async Task<IActionResult> All(int houseOrgId)
		{
			var model = await unitService.GetAllFromHOAsync(houseOrgId);

			ViewBag.HouseOrgId = houseOrgId;

			return View(model);
		}
		#endregion
	}
}
