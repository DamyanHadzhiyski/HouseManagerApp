using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Managers;
using HouseManager.Core.Models.Pagination;
using HouseManager.Filters;
using HouseManager.Infrastructure.Enums;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using static HouseManager.Constants.SessionConstants;
using static HouseManager.Core.Constants.DataConstants;

namespace HouseManager.Controllers
{
	public class ManagersController(
		IManagementService managementService) : BaseController
	{
		#region Add Manager
		[HttpGet]
		public IActionResult Add(ManagerPosition position)
		{
			var model = new ActiveManagerFormModel
			{
				Position = position,
				HouseOrganizationId = HttpContext?.Session?.GetInt32(HouseOrgId) ?? 0
			};
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(ActiveManagerFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction(nameof(All), new { houseOrgId = model.HouseOrganizationId });
			}

			await managementService.AddAsync(model);

			return RedirectToAction(nameof(All), new { houseOrgId = model.HouseOrganizationId });
		}
		#endregion

		#region Edit Manager
		[HttpGet]
		[ActiveManagerExists]
		public async Task<IActionResult> Edit(int id)
		{
			var model = await managementService
									.GetByIdAsync(id);
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(ActiveManagerFormModel model)
		{
			var houseOrgId = HttpContext.Session.GetInt32(HouseOrgId);

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await managementService.EditAsync(model);

			return RedirectToAction("All", "Managers", new { houseOrgId });
		}
		#endregion

		#region Show Managers
		[HttpGet]
		[HouseOrganizationExists("houseOrgId")]
		public async Task<IActionResult> All(int houseOrgId, int presidentsCurrentPage = 1, int cashiersCurrentPage = 1)
		{
			ViewBag.ActivePresident = await managementService
									.GetAllActiveReadOnlyAsync(houseOrgId)
									.Where(m => m.Position == ManagerPosition.President)
									.FirstOrDefaultAsync();

			var inactivePresidents = managementService
												.GetAllInactiveReadOnlyAsync(houseOrgId)
												.Where(m => m.Position == ManagerPosition.President);

			ViewBag.ActiveCashier = await managementService
									.GetAllActiveReadOnlyAsync(houseOrgId)
									.Where(m => m.Position == ManagerPosition.Cashier)
									.FirstOrDefaultAsync();

			var inactiveCashiers = managementService
												.GetAllInactiveReadOnlyAsync(houseOrgId)
												.Where(m => m.Position == ManagerPosition.Cashier);

			ViewBag.InactivePresidents = new InactivePresidentsPageViewModel
			{
				Position = ManagerPosition.President,
				CurrentPage = presidentsCurrentPage,
				ElementsPerPage = ElementsOnPage,
				TotalElements = inactivePresidents.Count(),
				Collection = await inactivePresidents
										.Skip((presidentsCurrentPage - 1) * ElementsOnPage)
										.Take(ElementsOnPage)
										.ToListAsync()
			};

			ViewBag.InactiveCashiers = new InactiveCashiersPageViewModel
			{
				Position = ManagerPosition.Cashier,
				CurrentPage = cashiersCurrentPage,
				ElementsPerPage = ElementsOnPage,
				TotalElements = inactiveCashiers.Count(),
				Collection = await inactiveCashiers
										.Skip((cashiersCurrentPage - 1) * ElementsOnPage)
										.Take(ElementsOnPage)
										.ToListAsync()
			};

			return View();
		}
		#endregion

		#region End Term
		[HttpGet]
		[ActiveManagerExists]
		public async Task<IActionResult> EndTerm(int id)
		{
			var houseOrgId = await managementService.EndTermAsync(id);

			return RedirectToAction(nameof(All), new { houseOrgId });
		}
		#endregion
	}
}
