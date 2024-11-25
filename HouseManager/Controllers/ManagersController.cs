
using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Manager;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HouseManager.Controllers
{
	public class ManagersController(
					IManagerService managerService) : BaseController
	{
		#region Show All Board Members
		public async Task<IActionResult> All(int houseOrgId)
		{
			var model = await managerService
								.GetAllReadonlyAsync()
								.Select(bm => new ManagerViewModel
								{
									Id = bm.Id,
									Name = bm.Name,
									StartDate = bm.StartDate,
									EndDate = bm.EndDate,
									PhoneNumber = bm.PhoneNumber,
									IsActive = bm.IsActive
								})
								.ToListAsync();

			return View(model);
		}
		#endregion

		#region Add New Board member
		//[HttpGet]
		//public IActionResult Add()
		//{
		//	var model = new ManagerViewModel();

		//	return View(model);
		//}

		//public async Task<IActionResult> Add(ManagerViewModel model)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return View(model);
		//	}

		//	await managerService.AddBoardMemberAsync(model);

		//	return RedirectToAction(nameof(All));
		//}
		#endregion

		#region Edit Board Member
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

		#region Private Methods
		//private List<SelectListItem> GetMemberPositions()
		//{
		//	var positions = new List<SelectListItem>();

		//	foreach (var position in Enum.BoardMemberPosition)
		//	{
		//		positions.Add(new )
		//	}

		//}
		#endregion
	}
}
