using HouseManager.Core.Models.BoardMember;

using Microsoft.AspNetCore.Mvc;

namespace HouseManager.Controllers
{
	public class BoardMembersController : BaseController
	{
		#region Show All Board Members
		public IActionResult All()
		{
			var model = new BoardMemberModel();


		}
		#endregion


	}
}
