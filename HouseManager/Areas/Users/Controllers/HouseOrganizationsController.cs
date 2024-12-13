using HouseManager.Core.Contracts;
using HouseManager.Core.Models.HouseOrganization;

using Microsoft.AspNetCore.Mvc;

namespace HouseManager.Areas.Users.Controllers
{
	public class HouseOrganizationsController(
		IHouseOrganizationService houseOrgService,
		IUnitService unitService,
		IUsersService userService) : Controller
	{
		//public IActionResult Index()
		//{
		//	return View("~/Areas/Users/Views/HouseOrganizations/Index.cshtml");
		//}
		//#region Add New House Organization
		//[HttpGet]
		//public async Task<IActionResult> Add()
		//{
		//	var user = User.FindFirstValue(ClaimTypes.NameIdentifier);


		//	await userService.ChangeRole(user, UserRole, AdminRole);


		//	return View(model);
		//}

		//[HttpPost]
		//public async Task<IActionResult> Add(HouseOrganizationFormModel model)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return View(model);
		//	}

		//	var id = await houseOrgService.AddAsync(model);

		//	return RedirectToAction(nameof(Details), "HouseOrganizations", new { id });
		//}
		//#endregion

	}
}
