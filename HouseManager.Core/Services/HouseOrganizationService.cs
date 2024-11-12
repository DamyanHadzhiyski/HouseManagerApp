using System.Data;

using HouseManager.Core.Contracts;
using HouseManager.Core.Models;
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

		public async Task EditHouseOrganizationAsync(HouseOrganizationModel house, int houseId)
		{
			var editHouse = GetHouseOrganizationById(houseId);


            if (editHouse == null)
			{
				throw new InvalidExpressionException("House organization does not exist");
			}

			await context.SaveChangesAsync();
			//await editHouse
			//        .Select(ho =>
			//        {
			//            ho.Name = house.Name;
			//            ho.Address = house.Address;
			//            ho.TownId = house.TownId;
			//        });

			//editHouse.

		}

		public IQueryable<HouseOrganization> GetAllReadonlyAsync()
		{
			return context.HouseOrganizations
								.AsNoTracking();
		}

		public IQueryable<HouseOrganization> GetHouseOrganizationById(int houseId)
		{
			return context.HouseOrganizations
							.Where(ho => ho.Id == houseId);
		}
	}
}
