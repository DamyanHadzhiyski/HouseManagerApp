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
		public async Task EditUnitAsync(UnitViewModel model)
		{
			throw new NotImplementedException();
		}

		public async Task<List<UnitViewModel>> GetAllUnitsAsync()
		{
			return await context.Units
								.Select(u => new UnitViewModel
								{
									Id = u.Id,
									Number = u.UnitNumber,
									Floor = u.Floor.ToString(),
									Type = u.UnitType.Name,
								})
								.ToListAsync();
		}

		public async Task<UnitDetailViewModel?> GetUnitDetailsByIdAsync(int id)
		{
			return await context.Units
								.Where(u => u.Id == id)
								.Select(u => new UnitDetailViewModel
								{
									Id = u.Id,
									Number = u.UnitNumber,
									Floor = u.Floor.ToString(),
									Type = u.UnitType.Name,
									TotalArea = u.TotalArea.ToString("f2"),
									CommonParts = u.CommonParts.ToString("f2"),
									PetsCount = u.PetsCount.ToString(),
									Balance = u.Balance.ToString()
								})
								.FirstOrDefaultAsync();
		}

		public async Task<Unit?> GetUnitByIdAsync(int id)
		{
			return await context.Units
							.Where(u => u.Id == id)
							.FirstOrDefaultAsync();//u => u.Id == id);
		}

        public async Task<List<UnitViewModel>> GetAllUnitsFromHOAsync(int houseOrgId)
        {
            return await context.Units
								.Where(u => u.HouseOrganizationId == houseOrgId)
                                .Select(u => new UnitViewModel
                                {
                                    Id = u.Id,
                                    Number = u.UnitNumber,
                                    Floor = u.Floor.ToString(),
                                    Type = u.UnitType.Name,
                                })
                                .ToListAsync();
        }
    }
}
