using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Manager;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HouseManager.Controllers
{
	public class ManagementController(
		IManagementService managementService) : BaseController
	{
		#region Show All Managers
		[HttpGet]
		public async Task<IActionResult> All(int houseOrgId)
		{
			ViewBag.ActivePresident = await managementService
									.GetActiveReadOnlyAsync(houseOrgId)
									.Select(p => new ActiveManagementViewModel
									{
										Id = p.Id,
										Name = p.Name,
										PhoneNumber = p.PhoneNumber,
										StartDate = p.StartDate,
										EndDate = p.EndDate,
										Progress = p.Progress
									})
									.FirstOrDefaultAsync();

			ViewBag.InactivePresidents = await managementService
												.GetAllInactiveReadOnlyAsync(houseOrgId)
												.Select(p => new InactiveManagementViewModel
												{
													Name = p.Name,
													StartDate = p.StartDate,
													EndDate = p.EndDate,
													TerminationDate = p.TerminationDate
												})
												.ToListAsync();

			ViewBag.ActiveCashier = await managementService
									.GetActiveReadOnlyAsync(houseOrgId)
									.Select(p => new ActiveManagementViewModel
									{
										Id = p.Id,
										Name = p.Name,
										PhoneNumber = p.PhoneNumber,
										StartDate = p.StartDate,
										EndDate = p.EndDate,
										Progress = p.Progress
									})
									.FirstOrDefaultAsync();

			ViewBag.InactiveCashiers = await managementService
												.GetAllInactiveReadOnlyAsync(houseOrgId)
												.Select(p => new InactiveManagementViewModel
												{
													Name = p.Name,
													StartDate = p.StartDate,
													EndDate = p.EndDate,
													TerminationDate = p.TerminationDate
												})
												.ToListAsync();

			return View();
		}
		#endregion

		#region Add President
		[HttpGet]
		public IActionResult Add(int houseOrgId)
		{
			var emptyModel = new ActiveManagementFormModel();

			//return RedirectToAction("All", "Management", new {houseOrgId});

			return ViewComponent("ActiveManager", new { model = emptyModel, position = "President" });
		}

		[HttpPost]
		public async Task<IActionResult> Add(ActiveManagementFormModel model, int houseOrgId)
		{
			if (await managementService.ActiveExistsAsync(houseOrgId))
			{
				ModelState.AddModelError("ActiveExists", "There is already assigned President, you must end it's term, before assigning a new one!");
			}

			model.HouseOrganizationId = houseOrgId;

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
				return View(model);
			}

			await managementService.AddAsync(model);

			return LocalRedirect($"~/Management/all/{houseOrgId}");
		}
		#endregion

		#region Edit President
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var president = await managementService
									.GetByIdAsync(id);

			if (president == null)
			{
				///TODO: Add exception logic
			}

			var model = new ActiveManagementFormModel
			{
				Id = president.Id,
				Name = president.Name,
				StartDate = president.StartDate,
				PhoneNumber = president.PhoneNumber
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(ActiveManagementFormModel model)
		{
			if (!ModelState.IsValid)
			{
				//TODO: exception logic

				return View(model);
			}

			await managementService.EditAsync(model);

			return RedirectToAction("All", "Management", new { model.HouseOrganizationId });
		}
		#endregion

		#region Show President
		public async Task<IActionResult> Show(int houseOrgId)
		{
			var model = managementService
							.GetActiveReadOnlyAsync(houseOrgId)
							.FirstOrDefaultAsync();

			return View(model);
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

			return LocalRedirect($"~/Management/all/{houseOrgId}");
		}
		#endregion
	}
}
