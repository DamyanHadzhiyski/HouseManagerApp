using Microsoft.AspNetCore.Mvc;

namespace HouseManager.Controllers
{
	public class UnitsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
