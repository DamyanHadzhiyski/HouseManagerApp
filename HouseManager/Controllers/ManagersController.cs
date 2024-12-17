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
			var model = new ActiveManagerFormModel();

			model.Position = position;

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(ActiveManagerFormModel model)
		{
			if (await managementService.ActiveExistsAsync(model.HouseOrganizationId, model.Position))
			{
				ModelState.AddModelError("ActiveExists", "There is already assigned President, you must end it's term, before assigning a new one!");
			}

			if (!ModelState.IsValid)
			{
				List<string> errors = [];

				foreach (var modelState in ModelState)
				{
					if (modelState.Value.Errors.Any())
					{
						errors.Add(modelState.Value.Errors.FirstOrDefault().ErrorMessage);
					}
				}

				TempData["Errors"] = errors;
				return RedirectToAction(nameof(All), new { houseOrgId = model.HouseOrganizationId });
			}

			await managementService.AddAsync(model);

			return RedirectToAction(nameof(All), new { houseOrgId = model.HouseOrganizationId });
		}
		#endregion

		#region Edit Manager
		[HttpGet]
		[TypeFilter<ActiveManagerExistsFilterAttribute>]
		public async Task<IActionResult> Edit(int id)
		{
			var manager = await managementService
									.GetByIdAsync(id);

			if (manager == null)
			{
				///TODO: Add exception logic
			}

			var model = new ActiveManagerFormModel
			{
				Id = manager.Id,
				Name = manager.Name,
				Position = manager.Position,
				StartDate = manager.StartDate,
				TermPeriod = manager.TermPeriod,
				PhoneNumber = manager.PhoneNumber
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(ActiveManagerFormModel model)
		{
			var houseOrgId = HttpContext.Session.GetInt32(HouseOrgId);

			if (!ModelState.IsValid)
			{
				//TODO: exception logic

				return View(model);
			}

			await managementService.EditAsync(model);

			return RedirectToAction("All", "Managers", new { houseOrgId });
		}
		#endregion

		#region Show Managers
		[HttpGet]
		[TypeFilter<HouseOrganizationExistsFilterAttribute>]
		public async Task<IActionResult> All(int id, int presidentsCurrentPage = 1, int cashiersCurrentPage = 1)
		{
			ViewBag.ActivePresident = await managementService
									.GetActiveReadOnlyAsync(id)
									.Where(m => m.Position == ManagerPosition.President)
									.FirstOrDefaultAsync();

			var inactivePresidents = await managementService
												.GetAllInactiveReadOnlyAsync(id)
												.Where(m => m.Position == ManagerPosition.President)
												.ToListAsync();

			ViewBag.ActiveCashier = await managementService
									.GetActiveReadOnlyAsync(id)
									.Where(m => m.Position == ManagerPosition.Cashier)
									.FirstOrDefaultAsync();

			var inactiveCashiers = await managementService
												.GetAllInactiveReadOnlyAsync(id)
												.Where(m => m.Position == ManagerPosition.Cashier)
												.ToListAsync();

			ViewBag.InactivePresidents = new InactivePresidentsPageViewModel
			{
				Position = ManagerPosition.President,
				CurrentPage = presidentsCurrentPage,
				ElementsPerPage = ElementsOnPage,
				TotalElements = inactivePresidents.Count,
				Collection = inactivePresidents
										.Skip((presidentsCurrentPage - 1) * ElementsOnPage)
										.Take(ElementsOnPage)
										.ToList()
			};

			ViewBag.InactiveCashiers = new InactiveCashiersPageViewModel
			{
				Position = ManagerPosition.Cashier,
				CurrentPage = cashiersCurrentPage,
				ElementsPerPage = ElementsOnPage,
				TotalElements = inactiveCashiers.Count,
				Collection = inactiveCashiers
										.Skip((cashiersCurrentPage - 1) * ElementsOnPage)
										.Take(ElementsOnPage)
										.ToList()
			};

			return View();
		}
		#endregion

		#region End Term
		[HttpGet]
		[TypeFilter<ActiveManagerExistsFilterAttribute>]
		public async Task<IActionResult> EndTerm(int id)
		{
			var houseOrgId = await managementService.EndTermAsync(id);

			return RedirectToAction(nameof(All), new { houseOrgId });
		}
		#endregion
	}
}
