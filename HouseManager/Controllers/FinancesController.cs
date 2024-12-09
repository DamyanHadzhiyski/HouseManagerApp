using Microsoft.AspNetCore.Mvc;

namespace HouseManager.Controllers
{
	public class FinancesController : BaseController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
