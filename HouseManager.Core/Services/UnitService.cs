﻿using HouseManager.Core.Contracts;
using HouseManager.Core.Models.HouseOrganization;
using HouseManager.Core.Models.Unit;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;

using Microsoft.EntityFrameworkCore;


namespace HouseManager.Core.Services
{
	public class UnitService(
		HouseManagerDbContext context) : IUnitService
	{
		public async Task EditAsync(UnitViewModel model)
		{
			throw new NotImplementedException();
		}

		public async Task<List<UnitViewModel>> GetAllAsync()
		{
			return await context.Units
								.Select(u => new UnitViewModel
								{
									Id = u.Id,
									Number = u.UnitNumber,
									Floor = u.Floor.ToString(),
									Type = u.UnitType.ToString()
								})
								.ToListAsync();
		}

		public async Task<UnitDetailViewModel?> GetDetailsByIdAsync(int id)
		{
			return await context.Units
								.Where(u => u.Id == id)
								.Select(u => new UnitDetailViewModel
								{
									Id = u.Id,
									Number = u.UnitNumber,
									Floor = u.Floor.ToString(),
									Type = u.UnitType.ToString(),
									TotalArea = u.TotalArea.ToString("f2"),
									CommonParts = u.CommonParts.ToString("f2"),
									OccupantsCount = u.Occupants
															.Where(o => o.IsActive)
															.Count(),
									Balance = u.Balance
								})
								.FirstOrDefaultAsync();
		}

		public async Task<Unit?> GetByIdAsync(int id)
		{
			return await context.Units
							.Where(u => u.Id == id)
							.FirstOrDefaultAsync();
		}

        public async Task<List<UnitViewModel>> GetAllFromHOAsync(int houseOrgId)
        {
            return await context.Units
								.Where(u => u.HouseOrganizationId == houseOrgId)
                                .Select(u => new UnitViewModel
                                {
                                    Id = u.Id,
                                    Number = u.UnitNumber,
                                    Floor = u.Floor.ToString(),
                                    Type = u.UnitType.ToString(),
                                })
                                .ToListAsync();
        }

		public async Task<List<UnitViewModel>> GetAllByOccupantAsync(int houseOrgId, List<int> occupantIds)
		{
			var result = context.Units
							.Where(u => u.HouseOrganizationId == houseOrgId 
											&& u.Occupants.Any(o => occupantIds.Contains(o.Id) && o.IsActive))
							.Select(u => new UnitViewModel
							{
								Id = u.Id,
								Number = u.UnitNumber,
								Floor = u.Floor.ToString(),
								Type = u.UnitType.ToString(),
							});

			return await result.ToListAsync();
		}

		public async Task<List<UnitShortViewModel>> GetUnitsShortInfoAsync(int houseOrgId)
		{
			return await context.Units
								.Where(u => u.HouseOrganizationId == houseOrgId)
								.Select(u => new UnitShortViewModel
								{
									Id = u.Id,
									Number = u.UnitNumber,
								})
								.ToListAsync();
		}
	}
}
