using HouseManager.Core.Contracts;
using HouseManager.Infrastructure.Enums;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HouseManager.Areas.Cashier.Controllers
{
	public class ManagersController(
		IManagementService managementService) : CashierController
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
