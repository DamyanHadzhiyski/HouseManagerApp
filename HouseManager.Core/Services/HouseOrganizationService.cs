using System.Data;

using HouseManager.Core.Contracts;
using HouseManager.Core.Models.HouseOrganization;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace HouseManager.Core.Services
{
	public class HouseOrganizationService(
		HouseManagerDbContext context) : IHouseOrganizationService
	{
		public async Task AddHouseOrganizationAsync(HouseOrganizationFormModel houseOrg)
		{
			var newHouseOrg = new HouseOrganization()
			{
				Name = houseOrg.Name,
				TownId = houseOrg.TownId,
				Address = houseOrg.Address,
				Units = [],
				Managers = []
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
			editHouse.TownId = house.TownId;

			await context.SaveChangesAsync();
		}

		public Task<bool> ExistByIdAsync(int houseOrgId)
		{
			throw new NotImplementedException();
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
							.FirstOrDefaultAsync(ho => ho.Id == houseId);
		}
	}
}
