using HouseManager.Core.Contracts;
using HouseManager.Core.Models.OccupantModels;

using Microsoft.AspNetCore.Mvc;

namespace HouseManager.Controllers
{
	public class OccupantController(
		IOccupantService occupantService) : BaseController
	{
		#region Add Occupant
		[HttpGet]
		public IActionResult Add(int unitId)
		{
			var model = new OccupantFormModel();

			model.UnitId = unitId;

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(OccupantFormModel model)
		{
			if (model == null)
			{
				return View(model);
			}

			var id = await occupantService.AddAsync(model);

			return RedirectToAction(nameof(Details), "Occupant", new { id });
		}
		#endregion

		#region Edit Occupant
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var model = await occupantService.GetByIdAsync(id);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(OccupantFormModel model)
		{
			await occupantService.EditAsync(model);

			return RedirectToAction(nameof(Details), "Occupant", new { model.Id });
		}
		#endregion

		#region Show Occupant Details
		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var model = await occupantService.GetDetailsByIdAsync(id);

			return View(model);
		}
		#endregion
	}
}
