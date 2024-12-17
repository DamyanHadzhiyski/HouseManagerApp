using System.Security.Claims;

using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Access;
using HouseManager.Filters;
using HouseManager.Infrastructure.Enums;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using static HouseManager.Infrastructure.Constants.UserRoles;

namespace HouseManager.Controllers
{

	public class AccessController(
		IAccessService accessService,
		IUserService userService) : Controller
	{
		#region Generate Access Codes
		[HttpGet]
		[Authorize(Roles = $"{AdminRole},{PresidentRole}")]
		[TypeFilter<ActiveOccupantExistsFilterAttribute>]
		public async Task<IActionResult> GenerateOccupantCode(int id)
		{
			TempData["AccessCode"] = await accessService.AddAccessCodeToOccupant(id);

			return RedirectToAction("Edit", "Occupants", new { id });
		}

		[HttpGet]
		[Authorize(Roles = $"{AdminRole},{PresidentRole}")]
		[TypeFilter<ActiveOccupantExistsFilterAttribute>]
		public async Task<IActionResult> GenerateManagerCode(int id)
		{
			TempData["AccessCode"] = await accessService.AddAccessCodeToManager(id);

			return RedirectToAction("Edit", "Managers", new { id });
		}
		#endregion

		#region Getting Manager Access
		[HttpGet]
		[Authorize]
		public IActionResult RequestManagerAccess(ManagerPosition position)
		{
			if(!Enum.IsDefined(typeof(ManagerPosition), position))
			{
				return BadRequest();
			}

			var model = new AccessManagerFormModel();

			model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			model.Position = position;

			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> RequestManagerAccess(AccessManagerFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			await accessService.ProvideManagerAccess(model);

			await userService.AddToRoleAsync(model.UserId, Enum.GetName(typeof(ManagerPosition), model.Position));

			return RedirectToAction("Index", "Home");
		}
		#endregion

		#region Getting Occupant Access
		[HttpGet]
		[Authorize]
		public IActionResult RequestOccupantAccess()
		{
			var model = new AccessOccupantFormModel();

			model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> RequestOccupantAccess(AccessOccupantFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			await accessService.ProvideOccupantAccess(model);

			await userService.AddToRoleAsync(model.UserId, UserRole);

			return RedirectToAction("Index", "Home");
		}
		#endregion
	}
}
