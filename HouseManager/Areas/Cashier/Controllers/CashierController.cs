using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static HouseManager.Infrastructure.Constants.UserRoles;

namespace HouseManager.Areas.Cashier.Controllers
{
	[Area("Cashier")]
	[Authorize(Roles = CashierRole)]
	public class CashierController : Controller
	{
	}
}
