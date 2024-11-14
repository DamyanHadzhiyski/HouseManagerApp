using Microsoft.AspNetCore.Mvc;

namespace HouseManager.Controllers
{
	public class UnitsController : BaseController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
