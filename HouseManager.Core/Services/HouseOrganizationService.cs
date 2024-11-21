using System.Data;

using HouseManager.Core.Contracts;
using HouseManager.Core.Models.HouseOrganization;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;

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
		public async Task AddHouseOrganizationAsync(HouseOrganizationFormModel houseOrg)
		{
			var newHouseOrg = new HouseOrganization()
			{
				Name = houseOrg.Name,
				Town = houseOrg.Town,
				Address = houseOrg.Address,
				Units = new List<Unit>(),
				Managers = new List<Manager>()
			};

			await context.HouseOrganizations.AddAsync(newHouseOrg);
			await context.SaveChangesAsync();
		}

		public async Task EditHouseOrganizationAsync(HouseOrganizationFormModel house)
		{
			var editHouse = await GetHouseOrganizationById(house.Id);


			if (editHouse == null)
			{
				throw new InvalidExpressionException("House organization does not exist");
			}

			editHouse.Name = house.Name;
			editHouse.Address = house.Address;
			editHouse.Town = house.Town;

			await context.SaveChangesAsync();
		}

		public async Task<bool> ExistByIdAsync(int houseOrgId)
		{
			return await context.HouseOrganizations
									.AnyAsync(ho => ho.Id == houseOrgId);
		}

		public IQueryable<HouseOrganization> GetAllReadOnly()
		{
			return context.HouseOrganizations
							  .AsNoTracking();
		}

		public IQueryable<HouseOrganization> GetByIdReadOnly(int houseOrgId)
		{
			return context.HouseOrganizations
							  .AsNoTracking();
		}

		public async Task<HouseOrganization?> GetHouseOrganizationById(int houseId)
		{
			return await context.HouseOrganizations
									.Include("Town")
									.Include(ho=>ho.Managers)
									.Include(ho=>ho.Units)
									.ThenInclude(u => u.Occupants)
									.FirstOrDefaultAsync(ho => ho.Id == houseId);
		}
	}
}
