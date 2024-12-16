using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static HouseManager.Infrastructure.Constants.UserRoles;

namespace HouseManager.Controllers
{
	[Authorize(Roles = AdminRole)]
	public class BaseController : Controller
	{
	}
}
