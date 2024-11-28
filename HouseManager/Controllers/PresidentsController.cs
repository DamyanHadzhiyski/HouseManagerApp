﻿using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Manager;

using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace HouseManager.Controllers
{
	public class PresidentsController(
		IPresidentService presidentService) : BaseController
	{
		#region Show President
		public async Task<IActionResult> Show(int houseOrgId)
		{
			var model = await presidentService
								.GetActiveReadOnlyAsync(houseOrgId);

			return View(model);
		}
		#endregion

		#region Add President
		[HttpGet]
		public IActionResult Add(int houseOrgId)
		{
			var model = new PresidentFormModel();

			return View(model);
		}

		public async Task<IActionResult> Add(PresidentFormModel model, int houseOrgId)
		{
			if (await presidentService.ActiveExistsAsync(houseOrgId))
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

			await presidentService.AddAsync(model);

			return LocalRedirect($"Management/all/{houseOrgId}");
		}
		#endregion

		#region Edit President
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
			if (!await presidentService.ExistsByIdAsync(id))
			{
				return NotFound();
			}

			if (!await presidentService.IsActiveAsync(id))
			{
				return BadRequest();
			}

			await presidentService.EndTermAsync(id);

			return LocalRedirect($"~/Management/all/{houseOrgId}");
		}
		#endregion
	}
}
