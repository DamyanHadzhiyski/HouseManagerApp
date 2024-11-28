using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Unit;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;
using HouseManager.Infrastructure.Enums;

using Microsoft.AspNetCore.Mvc;

namespace HouseManager.Controllers
{
	public class UnitsController(
        HouseManagerDbContext context,
        IUnitService unitService,
        IHouseOrganizationService houseOrgService) : BaseController
    {
        #region Add New Unit
        [HttpGet]
        public IActionResult Add(int houseOrgId)
        {
            var model = new UnitFormModel();

			return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(UnitFormModel model, int houseOrgId)
        {
			//TODO: ViewBag.UnitTypes = get all unit types

			if (!ModelState.IsValid) //TODO: check if unit type exists || !unitTypes.Any(ut => ut.Id == model.TypeId))
            {
				//TODO: ViewBag.UnitTypes = get all unit types

				//TODO: Add Exception

				return View(model);
            }

            var addUnit = new Unit
            {
                UnitNumber = model.Number,
                Floor = model.Floor,
                UnitType = model.Type,
                CommonParts = model.CommonParts,
                TotalArea = model.TotalArea,
                HouseOrganizationId = houseOrgId

            };

            await context.Units.AddAsync(addUnit);
            await context.SaveChangesAsync();

            return RedirectToAction("All", "Units", new {houseOrgId = houseOrgId});
        }
        #endregion

        #region Edit Unit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var unitFromDb = await unitService.GetByIdAsync(id);

                //TODO: ViewBag.UnitTypes = unit types

                var model = new UnitFormModel
                {
                    Id = unitFromDb.Id,
                    Number = unitFromDb.UnitNumber,
                    Floor = unitFromDb.Floor,
                    Type = unitFromDb.UnitType,
                    TotalArea = unitFromDb.TotalArea,
                    CommonParts = unitFromDb.CommonParts,
                    HouseOrganizationId = unitFromDb.HouseOrganizationId
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
				//TODO: ViewBag.UnitTypes = get all unit types

				//TODO: add exception handling

				return View(model);
            }

            var unitFromDb = await unitService.GetByIdAsync(model.Id);

            unitFromDb.UnitNumber = model.Number;
            unitFromDb.Floor = model.Floor;
            unitFromDb.UnitType = model.Type;
            unitFromDb.TotalArea = model.TotalArea;
            unitFromDb.CommonParts = model.CommonParts;

            await context.SaveChangesAsync();

            return RedirectToAction("All", "Units", new { houseOrgId = unitFromDb.HouseOrganizationId });
        }
        #endregion

        #region Show Unit Details
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await unitService.GetDetailsByIdAsync(id);

            return View(model);
        }
		#endregion

		#region Show All Units
		[HttpGet]
		//[Route("Units/All/{houseOrgId}")]
		public async Task<IActionResult> All(int houseOrgId)
		{
            if(!await houseOrgService.ExistById(houseOrgId))
            {
                return BadRequest();
            }

			var model = await unitService.GetAllFromHOAsync(houseOrgId);

			ViewBag.HouseOrgId = houseOrgId;

			return View(model);
		}
		#endregion
	}
}
