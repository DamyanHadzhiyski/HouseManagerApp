
using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Unit;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace HouseManager.Core.Services
{
    public class UnitService(
        HouseManagerDbContext context) : IUnitService
    {
        //public async Task EditUnitAsync(UnitModel model)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<UnitModel>> GetAllUnitsAsync()
        {
            return await context.Units
                            .Select(u => new UnitModel
                            {
                                Id = u.Id,
                                Number = u.UnitNumber,
                                Floor = u.Floor,
                                TypeId = u.UnitTypeId,
                                TotalArea = u.TotalArea,
                                CommonParts = u.CommonParts
                            })
                            .ToListAsync();
        }

        public async Task<Unit?> GetUnitByIdAsync(int id)
        {
            return await context.Units
                            .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
