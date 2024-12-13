using HouseManager.Core.Contracts;
using HouseManager.Core.Models.OccupantModel;

using Microsoft.AspNetCore.Mvc;

using NuGet.Protocol.Plugins;

using static HouseManager.Core.Constants.DataConstants;

namespace HouseManager.Controllers
{
	public class OccupantsController(
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

			return RedirectToAction(nameof(Details), "Occupants", new { id });
		}
		#endregion

		#region Edit Occupant
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var occupant = await occupantService.GetByIdAsync(id);

			var model = new OccupantFormModel
			{
				Id = occupant.Id,
				BirthDate = DateOnly.FromDateTime(occupant.BirthDate),
				FullName = occupant.FullName,
				IsOwner = occupant.IsOwner,
				OccupationDate = DateOnly.FromDateTime(occupant.OccupationDate),
				UnitId = occupant.UnitId,
				PhoneNumber = occupant.PhoneNumber
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(OccupantFormModel model)
		{
			await occupantService.EditAsync(model);

			return RedirectToAction(nameof(Details), "Occupants", new { model.Id });
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

		#region Leave
		[HttpGet]
		public async Task<IActionResult> Leave(int id)
		{
			if (!await occupantService.ExistsByIdAsync(id))
			{
				return NotFound();
			}

			if (!await occupantService.IsActiveAsync(id))
			{
				return BadRequest();
			}

			var unitId = await occupantService.Leave(id);

			return RedirectToAction("Details", "Unit", new { id = unitId });
		}
		#endregion
	}
}
