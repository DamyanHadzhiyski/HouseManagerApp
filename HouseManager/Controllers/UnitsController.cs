using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Unit;
using HouseManager.Core.Services;
using HouseManager.Infrastructure.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HouseManager.Controllers
{
    public class UnitsController(
		HouseManagerDbContext context,
		IUnitService unitService) : BaseController
	{
        #region Show All Units
        [HttpGet]
		public async Task<IActionResult> All()
		{
			var model = await unitService.GetAllUnitsAsync();

			return View(model);
		}
		#endregion

		#region Add New Unit
		[HttpGet]
        public async Task<IActionResult> Add()
		{
			var model = new UnitModel();

			ViewBag.UnitTypes = await GetUnitTypes();

			return View(model);
		}

		public async Task<IActionResult> Add(UnitModel model)
		{
			if(!ModelState.IsValid)
			{
				ViewBag.UnitTypes = await GetUnitTypes();

				//TODO: Add Exception

				return View(model);
			}

			return RedirectToAction(nameof(All));
		}
        #endregion

        #region Private Methods
        private async Task<List<SelectListItem>> GetUnitTypes()
		{
			return await context.UnitTypes
								.Select(ut => new SelectListItem()
								{
									Text = ut.Name,
									Value = ut.Id.ToString()
								})
								.ToListAsync();
		}
		#endregion
	}
}
