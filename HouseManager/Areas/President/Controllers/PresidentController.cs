using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static HouseManager.Infrastructure.Constants.UserRoles;

namespace HouseManager.Areas.President.Controllers
{
	[Area("President")]
	[Authorize(Roles = PresidentRole)]
	public class PresidentController : Controller
	{
	}
}
