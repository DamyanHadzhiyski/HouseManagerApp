using System.Data;

using HouseManager.Core.Contracts;
using HouseManager.Core.Models.HouseOrganization;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace HouseManager.Core.Services
{
    public class HouseOrganizationService(
		HouseManagerDbContext context) : IHouseOrganizationService
	{
		public async Task AddHouseOrganizationAsync(HouseOrganizationModel house)
		{
			var newHouse = new HouseOrganization()
			{
				Name = house.Name,
				TownId = house.TownId,
				Address = house.Address,
				Units = [],
				BoardMembers = []
			};

			await context.HouseOrganizations.AddAsync(newHouse);
			await context.SaveChangesAsync();
		}

		public async Task EditHouseOrganizationAsync(HouseOrganizationModel house)
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

		public IQueryable<HouseOrganization> GetAllReadonlyAsync()
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
