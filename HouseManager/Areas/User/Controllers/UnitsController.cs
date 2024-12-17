using System.Security.Claims;

using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Pagination;
using HouseManager.Filters;
using HouseManager.Infrastructure.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using static HouseManager.Core.Constants.DataConstants;

namespace HouseManager.Areas.User.Controllers
{
	public class UnitsController(
		HouseManagerDbContext context,
		IHouseOrganizationService houseOrgService,
		IUnitService unitService,
		IOccupantService occupantService) : UserController
	{
		#region Show Unit Details
		[HttpGet]
		public async Task<IActionResult> Details(int id, int activeCurrentPage = 1)
		{
			var model = await unitService.GetDetailsByIdAsync(id);

			var activeOccupants = await occupantService
										.GetAllActiveReadOnlyAsync(id)
										.OrderByDescending(o => o.IsOwner)
										.ToListAsync();

			int elementsPerPage = ElementsOnPage;

			model.ActiveOccupants = new ActiveOccupantsPageViewModel
			{
				CurrentPage = activeCurrentPage,
				TotalElements = activeOccupants.Count,
				ElementsPerPage = elementsPerPage,
				Collection = activeOccupants
								   .Skip((activeCurrentPage - 1) * elementsPerPage)
								   .Take(elementsPerPage)
								   .ToList()
			};

			return View(model);
		}
		#endregion

		#region Show All Units
		[HttpGet]
		[HouseOrganizationExists("id")]
		public async Task<IActionResult> All(int id)
		{
			var ids = await context.UsersOccupants
											.Where(uo => uo.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
											.Select(uo => uo.OccupantId)
											.ToListAsync();
			var model = await unitService
								.GetAllByOccupantAsync(id, ids);

			ViewBag.HouseOrgId = id;

			return View(model);
		}
		#endregion
	}
}
