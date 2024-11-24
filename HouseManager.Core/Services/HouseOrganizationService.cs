using System.Data;

using HouseManager.Core.Contracts;
using HouseManager.Core.Models.HouseOrganization;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;
using HouseManager.Infrastructure.Enums;

using Microsoft.EntityFrameworkCore;

namespace HouseManager.Core.Services
{
	/// <summary>
	/// Implementation of the IHouseOrganizationService
	/// </summary>
	/// <param name="context"></param>
	public class HouseOrganizationService(
		HouseManagerDbContext context) : IHouseOrganizationService
	{
		public async Task<int> AddAsync(HouseOrganizationFormModel houseOrg)
		{
			var newHouseOrg = new HouseOrganization()
			{
				Name = houseOrg.Name,
				Town = houseOrg.Town,
				Address = houseOrg.Address,
				Units = [],
				Managers = []
			};

			await context.HouseOrganizations.AddAsync(newHouseOrg);
			await context.SaveChangesAsync();

			var someId = await GetIdByNameAsync(newHouseOrg.Name);
			return someId;
		}

		private async Task<int> GetIdByNameAsync(string name)
		{
			return await context.HouseOrganizations
				.Where(ho => ho.Name == name)
				.Select(ho => ho.Id)
				.FirstOrDefaultAsync();
		}

		public async Task EditAsync(HouseOrganizationFormModel houseOrg)
		{
			var editHouse = await GetByIdAsync(houseOrg.Id);

			editHouse.Name = houseOrg.Name;
			editHouse.Address = houseOrg.Address;
			editHouse.Town = houseOrg.Town;

			await context.SaveChangesAsync();
		}

		public async Task<bool> ExistById(int houseOrgId)
		{
			return await context.HouseOrganizations
									.AnyAsync(ho => ho.Id == houseOrgId);
		}

		public IQueryable<HouseOrganizationViewModel> GetAllReadOnly()
		{
			return context.HouseOrganizations
							.Select(h => new HouseOrganizationViewModel
							{
								Id = h.Id,
								Name = h.Name,
								Address = h.Address,
								Town = h.Town
							})
							.AsNoTracking();
		}

		public IQueryable<HouseOrganizationFormModel> GetByIdReadOnly(int houseOrgId)
		{
			return context.HouseOrganizations
							  .Where(ho => ho.Id == houseOrgId)
							  .Select(ho => new HouseOrganizationFormModel
							  {
								  Id = ho.Id,
								  Name = ho.Name,
								  Address = ho.Address,
								  Town = ho.Town
							  })
							  .AsNoTracking();
		}

		public IQueryable<HouseOrganizationDetailViewModel> GetDetailsByIdReadOnly(int houseOrgId)
		{
			return context.HouseOrganizations
							  .Where(ho => ho.Id == houseOrgId)
							  .Select(ho => new HouseOrganizationDetailViewModel
							  {
								  Id = ho.Id,
								  Name = ho.Name,
								  Address = ho.Address,
								  Town = ho.Town,
								  PresidentName = GetPresidentName(ho.Managers),
								  CashierName = GetCashierName(ho.Managers),
								  UnitsCount = ho.Units.Count.ToString(),
								  OccupantsCount = GetOccupantsCount(ho.Units).ToString()
							  })
							  .AsNoTracking();
		}

		private static int GetOccupantsCount(ICollection<Unit> units)
		{
			return units.Sum(u => u.Occupants.Count);
		}

		private static string GetPresidentName(ICollection<Manager> managers)
		{
			return managers
					.Where(m => m.IsActive && m.Position.Equals(ManagerPosition.President))
					.Select(m => m.Name).FirstOrDefault() ?? "Not Assigned";
		}

		private static string GetCashierName(ICollection<Manager> managers)
		{
			return managers
					.Where(m => m.IsActive && m.Position.Equals(ManagerPosition.Cashier))
					.Select(m => m.Name).FirstOrDefault() ?? "Not Assigned";
		}

		public async Task<HouseOrganization?> GetByIdAsync(int houseOrgId)
		{
			return await context.HouseOrganizations
									.Include(ho => ho.Managers)
									.Include(ho => ho.Units)
									.ThenInclude(u => u.Occupants)
									.FirstOrDefaultAsync(ho => ho.Id == houseOrgId);
		}
	}
}
