using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static HouseManager.Infrastructure.Constants.UserRoles;

namespace HouseManager.Areas.Creator.Controllers
{
	[Area("Creator")]
	[Authorize(Roles = CreatorRole)]
	public class CreatorController : Controller
	{
	}
}
