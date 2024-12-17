using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Unit;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;

using Microsoft.EntityFrameworkCore;


namespace HouseManager.Core.Services
{
	/// <summary>
	/// Implementation of the IUnitService
	/// </summary>
	/// <param name="context"></param>
	public class UnitService(
		HouseManagerDbContext context) : IUnitService
	{
		public async Task<int> AddAsync(UnitFormModel model)
		{
			var unit = new Unit
			{
				UnitNumber = model.Number,
				Floor = model.Floor,
				UnitType = model.Type,
				CommonParts = model.CommonParts,
				TotalArea = model.TotalArea,
				HouseOrganizationId = model.HouseOrganizationId

			};

			await context.Units.AddAsync(unit);
			await context.SaveChangesAsync();

			return await GetUnitIdByNumber(model.HouseOrganizationId, model.Number);
		}

		public async Task<int> EditAsync(UnitFormModel model)
		{
			var unit = await GetByIdAsync(model.Id);

			unit.UnitNumber = model.Number;
			unit.Floor = model.Floor;
			unit.UnitType = model.Type;
			unit.TotalArea = model.TotalArea;
			unit.CommonParts = model.CommonParts;

			await context.SaveChangesAsync();

			return unit.Id;
		}

		public Task<bool> ExistsByIdAsync(int id)
		{
			return context.Units.AnyAsync(x => x.Id == id);
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

		public IQueryable<UnitFormModel> GetByIdReadOnly(int id)
		{
			return context.Units
							  .Where(u => u.Id == id)
							  .Select(u => new UnitFormModel
							  {
								  Id = u.Id,
								  Number = u.UnitNumber,
								  Floor = u.Floor,
								  Type = u.UnitType,
								  TotalArea = u.TotalArea,
								  CommonParts = u.CommonParts,
								  HouseOrganizationId = u.HouseOrganizationId
							  })
							  .AsNoTracking();
		}

		public IQueryable<UnitViewModel> GetAllFromHOAsync(int houseOrgId)
		{
			return context.Units
								.Where(u => u.HouseOrganizationId == houseOrgId)
								.Select(u => new UnitViewModel
								{
									Id = u.Id,
									Number = u.UnitNumber,
									Floor = u.Floor.ToString(),
									Type = u.UnitType.ToString(),
								})
								.OrderBy(u => u.Floor)
								.ThenBy(u => u.Number);
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

		#region Private Methods
		private async Task<int> GetUnitIdByNumber(int houseOrgId, string unitNumber)
		{
			return await context.Units
								.Where(u => u.HouseOrganizationId == houseOrgId
												&& u.UnitNumber == unitNumber)
								.OrderByDescending(u => u.Id)
								.Select(u => u.Id)
								.FirstOrDefaultAsync();
		}
		#endregion
	}
}
