using System.Security.Claims;

using HouseManager.Core.Contracts;
using HouseManager.Core.Models.HouseOrganization;
using HouseManager.Filters;
using HouseManager.Infrastructure.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using static HouseManager.Constants.SessionConstants;
using static HouseManager.Infrastructure.Constants.UserRoles;

namespace HouseManager.Areas.Cashier.Controllers
{
	public class HouseOrganizationsController(
        IHouseOrganizationService houseOrgService,
        IUnitService unitService,
        IUserService userService,
        HouseManagerDbContext context) : CashierController
    {
        #region Show House Organization Details
        [HttpGet]
		[HouseOrganizationExists("id")]
		public async Task<IActionResult> Details(int id)
        {
            var model = await houseOrgService
                                .GetDetailsByIdReadOnly(id)
                                .FirstOrDefaultAsync();

            model.Units = await unitService.GetAllFromHOAsync(id);

            return View(model);
        }
        #endregion

        #region Show All House Organizations
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new List<HouseOrganizationViewModel>();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			var ids = await context.UsersManagers
                                    .Where(um => um.UserId == userId)
                                    .Select(um => um.ManagerId)
                                    .ToListAsync();

            model = await houseOrgService
                                .GetAllManagedByAsync(ids)
                                .ToListAsync();

            await userService.SetCurrentRoleAsync(userId, CashierRole);

            HttpContext.Session.SetInt32(SideBarOpen, 1);

            return View(model);
        }
        #endregion

        #region Manage House Organization
        [HttpGet]
        public async Task<IActionResult> Manage(int id)
        {
            var houseOrgName = await houseOrgService
                                .GetByIdReadOnly(id)
                                .Select(ho => new
                                {
                                    ho.Name
                                })
                                .FirstOrDefaultAsync();

            if (houseOrgName == null)
            {
                BadRequest();
            }

            HttpContext.Session.SetString(HouseOrgName, houseOrgName.Name);
            HttpContext.Session.SetInt32(HouseOrgId, id);

            return RedirectToAction("Details", new { id , area="Cashier"});
        }
        #endregion
    }
}
