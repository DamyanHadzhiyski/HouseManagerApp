using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Unit;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;

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
			var model = new UnitFormModel();
			var unitTypes = await GetUnitTypes();

			ViewBag.UnitTypes = unitTypes
										.Select(ut => new SelectListItem
										{
											Text = ut.Name,
											Value = ut.Id.ToString()
										})
										.ToList(); ;

			return View(model);
		}

		public async Task<IActionResult> Add(UnitFormModel model)
		{
			var unitTypes = await GetUnitTypes();

			if (!ModelState.IsValid || !unitTypes.Any(ut => ut.Id == model.TypeId))
			{
				ViewBag.UnitTypes = unitTypes
										.Select(ut => new SelectListItem
										{
											Text = ut.Name,
											Value = ut.Id.ToString()
										})
										.ToList();

				//TODO: Add Exception

				return View(model);
			}

			var addUnit = new Unit
			{
				UnitNumber = model.Number,
				Floor = model.Floor,
				UnitTypeId = model.TypeId,
				CommonParts = model.CommonParts,
				TotalArea = model.TotalArea,
			};

			await context.Units.AddAsync(addUnit);
			await context.SaveChangesAsync();

			return RedirectToAction(nameof(All));
		}
		#endregion

		#region Edit Unit
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			try
			{
				var unitFromDb = await unitService.GetUnitByIdAsync(id);

				var unitTypes = await GetUnitTypes();

				ViewBag.UnitTypes = unitTypes
										.Select(ut => new SelectListItem
										{
											Text = ut.Name,
											Value = ut.Id.ToString()
										})
										.ToList();

				var model = new UnitFormModel
				{
					Id = unitFromDb.Id,
					Number = unitFromDb.UnitNumber,
					Floor = unitFromDb.Floor,
					TypeId = unitFromDb.UnitTypeId,
					TotalArea = unitFromDb.TotalArea,
					CommonParts = unitFromDb.CommonParts
				};

				return View(model);
			}
			catch (NullReferenceException argNullEx)
			{
				throw new NullReferenceException("There is no unit with the provided Id", argNullEx);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(UnitFormModel model)
		{


			if (!ModelState.IsValid)
			{
				var unitTypes = await GetUnitTypes();

				ViewBag.UnitTypes = unitTypes
										.Select(ut => new SelectListItem
										{
											Text = ut.Name,
											Value = ut.Id.ToString()
										})
										.ToList();

				//TODO: add exception handling

				return View(model);
			}

			var unitFromDb = await unitService.GetUnitByIdAsync(model.Id);

			unitFromDb.UnitNumber = model.Number;
			unitFromDb.Floor = model.Floor;
			unitFromDb.UnitTypeId = model.TypeId;
			unitFromDb.TotalArea = model.TotalArea;
			unitFromDb.CommonParts = model.CommonParts;

			await context.SaveChangesAsync();

			return RedirectToAction(nameof(All));
		}
		#endregion

		#region Show Unit Details
		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var model = await unitService.GetUnitDetailsByIdAsync(id);

			return View(model);
		}
		#endregion

		#region Private Methods TODO: Change method to return List<SelectedListItems>
		private async Task<List<UnitType>> GetUnitTypes()
		{
			return await context.UnitTypes.ToListAsync();
		}
		#endregion
	}
}
