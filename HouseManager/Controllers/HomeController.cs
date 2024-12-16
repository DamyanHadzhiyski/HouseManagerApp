using System.Security.Claims;

using HouseManager.Core.Contracts;

using Microsoft.AspNetCore.Mvc;

using static HouseManager.Constants.SessionConstants;
using static HouseManager.Infrastructure.Constants.UserRoles;


namespace HouseManager.Controllers
{
	public class HomeController(
		IUserService userService) : Controller
	{
		public async Task<IActionResult> Index()
		{
			HttpContext.Session.SetInt32(SideBarOpen, 0);

			if (User.Identity != null && User.Identity.IsAuthenticated)
			{
				if (User.IsInRole(AdminRole))
				{
					return RedirectToAction("All", "HouseOrganizations");
				}

				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

				await userService.SetCurrentRoleAsync(userId, "");
			}

			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error(int statusCode)
		{
			if (statusCode == 400)
			{
				return View("Error400");
			};

			if (statusCode == 404)
			{
				return View("Error404");
			};

			return View();
		}
	}
}
