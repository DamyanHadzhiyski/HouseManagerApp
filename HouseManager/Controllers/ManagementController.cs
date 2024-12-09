using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Management;
using HouseManager.Infrastructure.Enums;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using static HouseManager.Constants.SessionConstants;

namespace HouseManager.Controllers
{
	public class ManagementController(
		IManagementService managementService) : BaseController
	{
		#region Add Manager
		[HttpGet]
		public IActionResult Add(ManagerPosition position)
		{
			var model = new ActiveManagementFormModel();

			model.Position = position;

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(ActiveManagementFormModel model)
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
		public async Task<IActionResult> Edit(int id)
		{
			var manager = await managementService
									.GetByIdAsync(id);

			if (manager == null)
			{
				///TODO: Add exception logic
			}

			var model = new ActiveManagementFormModel
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
		public async Task<IActionResult> Edit(ActiveManagementFormModel model)
		{
			var houseOrgId = HttpContext.Session.GetInt32(ManagedHouseOrgId);

			if (!ModelState.IsValid)
			{
				//TODO: exception logic

				return View(model);
			}

			await managementService.EditAsync(model);

			return RedirectToAction("All", "Management", new { houseOrgId });
		}
		#endregion

		#region Show Managers
		[HttpGet]
		public async Task<IActionResult> All(int houseOrgId)
		{
			ViewBag.ActivePresident = await managementService
									.GetActiveReadOnlyAsync(houseOrgId)
									.Where(m => m.Position == ManagerPosition.President)
									.FirstOrDefaultAsync();

			ViewBag.InactivePresidents = await managementService
												.GetAllInactiveReadOnlyAsync(houseOrgId)
												.Where(m => m.Position == ManagerPosition.President)
												.ToListAsync();

			ViewBag.ActiveCashier = await managementService
									.GetActiveReadOnlyAsync(houseOrgId)
									.Where(m => m.Position == ManagerPosition.Cashier)
									.FirstOrDefaultAsync();

			ViewBag.InactiveCashiers = await managementService
												.GetAllInactiveReadOnlyAsync(houseOrgId)
												.Where(m => m.Position == ManagerPosition.Cashier)
												.ToListAsync();

			return View();
		}
		#endregion

		#region End Term
		[HttpGet]
		public async Task<IActionResult> EndTerm(int id)
		{
			if (!await managementService.ExistsByIdAsync(id))
			{
				return NotFound();
			}

			if (!await managementService.IsActiveAsync(id))
			{
				return BadRequest();
			}

			var houseOrgId = await managementService.EndTermAsync(id);

			return RedirectToAction(nameof(All), new { houseOrgId });
		}
		#endregion
	}
}
