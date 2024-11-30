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
			//var model = new ActiveManagementFormModel();

			return RedirectToAction("All", "Management");
		}

		[HttpPost]
		public async Task<IActionResult> Add(ActiveManagementFormModel model, int houseOrgId)
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
				return View(model);
			}

			var model1 = new CashierFormModel
			{
				Name = model.Name,
				PhoneNumber = model.PhoneNumber,
				StartDate = model.StartDate,
				EndDate = model.EndDate,
				HouseOrganizationId = houseOrgId
			};

			await cashierService.AddAsync(model1);

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
		[HttpGet]
		#region End Term
		public async Task<IActionResult> EndTerm(int id,int houseOrgId)
		{
			if (!await cashierService.ExistsByIdAsync(id))
			{
				return NotFound();
			}

			if (!await cashierService.IsActiveAsync(id))
			{
				return BadRequest();
			}

			await cashierService.EndTermAsync(id);

			return LocalRedirect($"~/Management/all/{houseOrgId}");
		}
		#endregion
	}
}
