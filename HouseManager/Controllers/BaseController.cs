using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseManager.Controllers
{
	[Authorize]
	public class BaseController : Controller
	{
	}
}
