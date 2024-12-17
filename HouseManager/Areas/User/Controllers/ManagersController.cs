using HouseManager.Core.Contracts;
using HouseManager.Infrastructure.Enums;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
									.GetAllActiveReadOnlyAsync(id)
									.Where(m => m.Position == ManagerPosition.President)
									.FirstOrDefaultAsync();

			ViewBag.ActiveCashier = await managementService
									.GetAllActiveReadOnlyAsync(id)
									.Where(m => m.Position == ManagerPosition.Cashier)
									.FirstOrDefaultAsync();

			return View();
		}
		#endregion
	}
}
