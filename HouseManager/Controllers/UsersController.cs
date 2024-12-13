using Microsoft.AspNetCore.Mvc;

namespace HouseManager.Controllers
{
	public class UsersController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
