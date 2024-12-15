using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Managers;
using HouseManager.Core.Models.Pagination;
using HouseManager.Infrastructure.Enums;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using static HouseManager.Constants.SessionConstants;
using static HouseManager.Core.Constants.DataConstants;

namespace HouseManager.Areas.User.Controllers
{
	public class ManagersController(
		IManagementService managementService) : UserController
	{
		#region Show Managers
		[HttpGet]
		public async Task<IActionResult> All(int id)
		{
			ViewBag.ActivePresident = await managementService
									.GetActiveReadOnlyAsync(id)
									.Where(m => m.Position == ManagerPosition.President)
									.FirstOrDefaultAsync();

			ViewBag.ActiveCashier = await managementService
									.GetActiveReadOnlyAsync(id)
									.Where(m => m.Position == ManagerPosition.Cashier)
									.FirstOrDefaultAsync();

			return View();
		}
		#endregion
	}
}
