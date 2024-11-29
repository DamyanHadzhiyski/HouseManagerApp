using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Manager;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HouseManager.Controllers
{
	public class ManagementController(
		IPresidentService presidentService,
		ICashierService cashierService) : BaseController
	{
		#region Show All Board Members
		[HttpGet]
		public async Task<IActionResult> All(int houseOrgId)
		{
			ViewBag.ActivePresident = await presidentService
									.GetActiveReadOnlyAsync(houseOrgId)
									.Select(p => new Class1
									{
										Id = p.Id,
										Name = p.Name,
										PhoneNumber = p.PhoneNumber,
										StartDate = p.StartDate,
										EndDate = p.EndDate,
										Progress = p.Progress
									})
									.FirstOrDefaultAsync();

			ViewBag.InactivePresidents = await presidentService
												.GetAllInactiveReadOnlyAsync(houseOrgId)
												.Select(p => new InactiveManagementViewModel
												{
													Name = p.Name,
													StartDate = p.StartDate,
													EndDate = p.EndDate,
													TerminationDate = p.TerminationDate
												})
												.ToListAsync();

			ViewBag.ActiveCashier = await cashierService
									.GetActiveReadOnlyAsync(houseOrgId)
									.Select(p => new Class2
									{
										Id = p.Id,
										Name = p.Name,
										PhoneNumber = p.PhoneNumber,
										StartDate = p.StartDate,
										EndDate = p.EndDate,
										Progress = p.Progress
									})
									.FirstOrDefaultAsync();

			ViewBag.InactiveCashiers = await cashierService
												.GetAllInactiveReadOnlyAsync(houseOrgId)
												.Select(p => new InactiveManagementViewModel
												{
													Name = p.Name,
													StartDate = p.StartDate,
													EndDate = p.EndDate,
													TerminationDate = p.TerminationDate
												})
												.ToListAsync();

			return View();
		}
		#endregion
	}
}
