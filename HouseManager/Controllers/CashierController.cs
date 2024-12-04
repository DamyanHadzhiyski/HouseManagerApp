using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Manager;

using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace HouseManager.Controllers
{
	public class CashierController(
		ICashierService cashierService) : BaseController
	{
		#region Show Cashier
		public async Task<IActionResult> Show(int houseOrgId)
		{
			var model = cashierService
							.GetActiveReadOnlyAsync(houseOrgId)
							.FirstOrDefaultAsync();

			return View(model);
		}
		#endregion

		#region Add Cashier
		[HttpGet]
		public IActionResult Add(int houseOrgId)
		{
			var emptyModel = new CashierFormModel();

			return ViewComponent("ActiveManager", new { model = emptyModel, position = "Cashier" });
		}

		[HttpPost]
		public async Task<IActionResult> Add(CashierFormModel model, int houseOrgId)
		{
			if (await cashierService.ActiveExistsAsync(houseOrgId))
			{
				ModelState.AddModelError("ActiveExists", "There is already assigned Cashier, you must end it's term, before assigning a new one!");
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
				return LocalRedirect($"~/Management/all/{houseOrgId}");
			}

			model.HouseOrganizationId = houseOrgId;

			await cashierService.AddAsync(model);

			return LocalRedirect($"~/Management/all/{houseOrgId}");
		}
		#endregion

		#region Edit Cashier
		//[HttpGet]
		//public async Task<IActionResult> Edit(int id)
		//{
		//	var boardMember = await managerService.GetBoardMemberByIdAsync(id);

		//	if (boardMember == null)
		//	{
		//		///TODO: Add exception logic
		//	}

		//	var model = new ManagerViewModel
		//	{
		//		Id = boardMember.Id,
		//		Name = boardMember.Name,
		//		Position = boardMember.Position,
		//		StartDate = boardMember.StartDate,
		//		EndDate = boardMember.EndDate,
		//		PhoneNumber = boardMember.PhoneNumber
		//	};

		//	return View(model);
		//}

		//[HttpPost]
		//public async Task<IActionResult> Edit(ManagerViewModel model)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		//TODO: exception logic

		//		return View(model);
		//	}

		//	await boardMemberService.EditBoardMemberAsync(model);

		//	return RedirectToAction(nameof(All));
		//}
		#endregion

		#region End Term
		[HttpGet]
		public async Task<IActionResult> EndTerm(int id)
		{
			if (!await cashierService.ExistsByIdAsync(id))
			{
				return NotFound();
			}

			if (!await cashierService.IsActiveAsync(id))
			{
				return BadRequest();
			}

			var houseOrgId = await cashierService.EndTermAsync(id);

			return LocalRedirect($"~/Management/all/{houseOrgId}");
		}
		#endregion
	}
}
