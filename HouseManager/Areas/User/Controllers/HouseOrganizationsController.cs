using System.Security.Claims;

using HouseManager.Core.Contracts;
using HouseManager.Infrastructure.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using static HouseManager.Constants.SessionConstants;
using static HouseManager.Infrastructure.Constants.UserRoles;

namespace HouseManager.Areas.User.Controllers
{
	public class HouseOrganizationsController(
		IHouseOrganizationService houseOrgService,
		IUserService userService,
		HouseManagerDbContext context) : UserController
	{
		public async Task<IActionResult> All()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			var ids = await context.UsersOccupants
											.Where(uo => uo.UserId == userId)
											.Select(uo => uo.OccupantId)
											.ToListAsync();

			var model = await houseOrgService
							.GetAllByOccupantIdReadOnly(ids)
									.ToListAsync();

			await userService.SetCurrentRoleAsync(userId, UserRole);

			HttpContext.Session.SetInt32(SideBarOpen, 1);

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Select(int id)
		{
			var houseOrg  = await houseOrgService
											.GetByIdAsync(id)
											.FirstOrDefaultAsync();

			HttpContext.Session.SetString(HouseOrgName, houseOrg.Name);
			HttpContext.Session.SetInt32(HouseOrgId, houseOrg.Id);

			return RedirectToAction("All", "Units", new { id , area = "User"});
		}
	}
}
