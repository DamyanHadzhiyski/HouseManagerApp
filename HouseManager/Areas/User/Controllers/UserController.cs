using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static HouseManager.Infrastructure.Constants.UserRoles;

namespace HouseManager.Areas.User.Controllers
{
	[Area("User")]
	[Authorize(Roles = UserRole)]
	public class UserController : Controller
	{
	}
}
