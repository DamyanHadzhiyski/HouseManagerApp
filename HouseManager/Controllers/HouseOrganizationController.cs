using HouseManager.Core.Contracts;
using HouseManager.Core.Models;
using HouseManager.Infrastructure.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HouseManager.Controllers
{
    public class HouseOrganizationController(
        IHouseOrganizationService houseService,
        HouseManagerDbContext context) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = houseService
                            .GetAllReadonlyAsync()
                            .Select(h => new HouseOrganizationModel
                            {
                                Address = h.Address,
                                TownId = h.TownId,
                                Name = h.Name
                            })
                            .ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new HouseOrganizationModel();

            ViewBag.Towns = await context.Towns
                                    .Select(t => new SelectListItem()
                                    {
                                        Text = t.Name,
                                        Value = t.Id.ToString()
                                    })
                                    .AsNoTracking()
                                    .ToListAsync();

            return View(model);
        }
    }
}
