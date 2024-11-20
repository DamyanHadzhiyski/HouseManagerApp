using System.Data;
using System.Linq;

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

		public async Task EditHouseOrganizationAsync(HouseOrganizationFormModel houseOrg)
		{
			var editHouseOrg = await GetHouseOrganizationById(houseOrg.Id);


            if (editHouseOrg == null)
			{
				throw new InvalidExpressionException("House organization does not exist");
			}

			editHouseOrg.Name = houseOrg.Name;
			editHouseOrg.Address = houseOrg.Address;
			editHouseOrg.TownId = houseOrg.TownId;

			await context.SaveChangesAsync();
		}

		public async Task<HouseOrganizationViewModel?> ShowHouseOrganizationAsync(int houseOrgId)
		{
			return await context.HouseOrganizations
								.AsNoTracking()
								.Where(ho => ho.Id == houseOrgId)
								.Select(ho => new HouseOrganizationViewModel
								{
									Name = ho.Name,
									Address = ho.Address,
									TownName = ho.Town.Name
								})
								.FirstOrDefaultAsync();
		}

		public async Task<HouseOrganizationDetailViewModel?> ShowHouseOrganizationDetailAsync(int houseOrgId)
		{
			return await context.HouseOrganizations
								.AsNoTracking()
								.Where(ho => ho.Id == houseOrgId)
								.Select(ho => new HouseOrganizationDetailViewModel
								{
									Name = ho.Name,
									Address = ho.Address,
									TownName = ho.Town.Name
								})
								.FirstOrDefaultAsync();
		}

		public async Task<HouseOrganization?> GetHouseOrganizationById(int houseOrgId)
		{
			return await context.HouseOrganizations
								.Where(ho => ho.Id == houseOrgId)
								.Include(ho => ho.Town)
								.Include(ho => ho.Managers)
								.Include(ho => ho.Units)
								.ThenInclude(u => u.Occupants)
								.FirstOrDefaultAsync();				
		}

		public IQueryable<HouseOrganization> GetAllReadOnly()
		{
			return context.HouseOrganizations
								.AsNoTracking();
		}

		public IQueryable<HouseOrganization> GetByIdReadOnly(int houseOrgId)
		{
			return context.HouseOrganizations
							.Where(ho => ho.Id == houseOrgId)
							.AsNoTracking();
		}

		public async Task<bool> ExistByIdAsync(int houseOrgId)
		{
			return await context.HouseOrganizations.AnyAsync(ho => ho.Id == houseOrgId);
		}
	}
}
