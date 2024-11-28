using HouseManager.Core.Contracts;

using Microsoft.AspNetCore.Mvc;

namespace HouseManager.Controllers
{
	public class ManagementController(
		IPresidentService presidentService) : BaseController
	{
		#region Show All Board Members
		public async Task<IActionResult> All(int houseOrgId)
		{
			ViewBag.ActivePresident = await presidentService
								.GetActiveReadOnlyAsync(houseOrgId);

			ViewBag.InactivePresidents = await presidentService
								.GetAllInactiveReadOnlyAsync(houseOrgId);

			ViewBag.ActiveCashier = await presidentService
								.GetActiveReadOnlyAsync(houseOrgId);

			ViewBag.InactiveCashiers = await presidentService
								.GetAllInactiveReadOnlyAsync(houseOrgId);

			return View();
		}
		#endregion
	}
}
