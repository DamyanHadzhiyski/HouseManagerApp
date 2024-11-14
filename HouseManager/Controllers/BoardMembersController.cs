
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
		public async Task<IActionResult> Edit(int id)
		{

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
