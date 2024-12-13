using System.Security.Claims;

using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Access;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Enums;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HouseManager.Controllers
{

	public class AccessController(
		IAccessService accessService,
		IUsersService userService,
		HouseManagerDbContext context) : BaseController
	{
		#region Generate Access Codes
		[HttpGet]
		public async Task<IActionResult> GenerateOccupantCode(int id)
		{
			//does exists
			var accessCode = accessService.GenerateAccessCode();

			await accessService.AddAccessCodeToOccupant(id, accessCode);

			TempData["AccessCode"] = accessCode;

			return RedirectToAction("Edit", "Occupants", new { id });
		}

		[HttpGet]
		public async Task<IActionResult> GenerateManagerCode(int id)
		{
			//does exists
			var accessCode = accessService.GenerateAccessCode();

			await accessService.AddAccessCodeToManager(id, accessCode);

			TempData["AccessCode"] = accessCode;

			return RedirectToAction("Edit", "Managers", new { id });
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
			model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

			IdentityUser user = await context.Users.FindAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

			if (!ModelState.IsValid)
			{
			}

			int houseOrgId = await accessService.ProvideManagerAccess(model);

			await userService.AddToRole(user, Enum.GetName(typeof(ManagerPosition),model.Position));

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
			model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

			if (!ModelState.IsValid)
			{
			}

			int unitId = await accessService.ProvideOccupantAccess(model);

			return RedirectToAction("Details", "Units", new { id = unitId });
		}
		#endregion
	}
}
