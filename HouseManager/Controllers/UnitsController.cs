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
        [Route("Units/All/{houseOrgId}")]
        public async Task<IActionResult> All(int houseOrgId)
        {
            var model = await unitService.GetAllUnitsFromHOAsync(houseOrgId);

            ViewBag.HouseOrgId = houseOrgId;

            return View(model);
        }
        #endregion

        #region Add New Unit
        [HttpGet]
        [Route("Units/Add/{houseOrgId}")]
        public async Task<IActionResult> Add(int houseOrgId)
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

        [HttpPost]
        [Route("Units/Add/{houseOrgId}")]
        public async Task<IActionResult> Add(UnitFormModel model, int houseOrgId)
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

            return RedirectToAction("All", "Units", new { houseOrgId = unitFromDb.HouseOrganizationId });
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
