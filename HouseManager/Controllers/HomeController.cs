using Microsoft.AspNetCore.Mvc;

using static HouseManager.Infrastructure.Constants.UserRoles;

namespace HouseManager.Controllers
{
	public class HomeController() : Controller
	{
		public IActionResult Index()
		{
			if (User.Identity != null && User.Identity.IsAuthenticated)
			{
				if(User.IsInRole(UserRole))
				{
					return RedirectToAction("Index", "HouseOrganizations", new { area = "Users" });
				}

				return RedirectToAction("All", "HouseOrganizations");
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
