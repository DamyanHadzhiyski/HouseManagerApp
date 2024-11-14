
using HouseManager.Core.Contracts;
using HouseManager.Core.Models.BoardMember;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HouseManager.Controllers
{
	public class BoardMembersController(
					IBoardMemberService boardMemberService) : BaseController
	{
		#region Show All Board Members
		public async Task<IActionResult> All()
		{
			var model = await boardMemberService
								.GetAllReadonlyAsync()
								.Select(bm => new BoardMemberModel
								{
									Id = bm.Id,
									Name = bm.Name,
									Position = bm.Position,
									StartDate = bm.StartDate,
									EndDate = bm.EndDate,
									PhoneNumber = bm.PhoneNumber
								})
								.ToListAsync();

			return View(model);
		}
		#endregion

		#region Add New Board member
		[HttpGet]
		public IActionResult Add()
		{
			var model = new BoardMemberModel();
			
			return View(model);
		}

		public async Task<IActionResult> Add(BoardMemberModel model)
		{
			if(!ModelState.IsValid)
			{
				return View(model);
			}

			await boardMemberService.AddBoardMemberAsync(model);

			return RedirectToAction(nameof(All));
		}
		#endregion

		#region Edit Board Member
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var boardMember = await boardMemberService.GetBoardMemberByIdAsync(id);

			if (boardMember == null)
			{
				///TODO: Add exception logic
			}

			var model = new BoardMemberModel
			{
				Id = boardMember.Id,
				Name = boardMember.Name,
				Position = boardMember.Position,
				StartDate = boardMember.StartDate,
				EndDate = boardMember.EndDate,
				PhoneNumber = boardMember.PhoneNumber
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(BoardMemberModel model)
		{
			if(!ModelState.IsValid)
			{
				//TODO: exception logic

				return View(model);
			}

			await boardMemberService.EditBoardMemberAsync(model);

			return RedirectToAction(nameof(All));
		}
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
