using System.Security.Claims;

using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Access;
using HouseManager.Infrastructure.Enums;

using Microsoft.AspNetCore.Mvc;

namespace HouseManager.Controllers
{

	public class AccessController(
		IAccessService accessService) : BaseController
	{
		#region Generate Access Codes
		[HttpGet]
		public async Task<IActionResult> GenerateOccupantCode(int occupantId)
		{
			//does exists
			var accessCode = accessService.GenerateAccessCode();

			await accessService.AddAccessCodeToOccupant(occupantId, accessCode);

			TempData["AccessCode"] = accessCode;

			return RedirectToAction("Edit", "Occupants", new { id = occupantId });
		}

		[HttpGet]
		public async Task<IActionResult> GenerateManagerCode(int managerId)
		{
			//does exists
			var accessCode = accessService.GenerateAccessCode();

			await accessService.AddAccessCodeToManager(managerId, accessCode);

			TempData["AccessCode"] = accessCode;

			return RedirectToAction("Edit", "Managers", new { id = managerId });
		}
		#endregion

		#region Getting Manager Access
		[HttpGet]
		public IActionResult RequestManagerAccess(ManagerPosition position)
		{
			var model = new AccessManagerFormModel();

			model.Position = position;

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> RequestManagerAccess(AccessManagerFormModel model)
		{
			if (!ModelState.IsValid)
			{
			}

			int houseOrgId = await accessService.ProvideManagerAccess(model);

			return RedirectToAction("Details", "HouseOrganization", new {id = houseOrgId});
		}
		#endregion

		#region Getting Occupant Access
		[HttpGet]
		public IActionResult RequestOccupantAccess()
		{
			var model = new AccessOccupantFormModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> RequestOccupantAccess(AccessOccupantFormModel model)
		{
			model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			if (!ModelState.IsValid)
			{
			}

			int unitId = await accessService.ProvideOccupantAccess(model);

			return RedirectToAction("Details", "Unit", new { id = unitId });
		}
		#endregion
	}
}
