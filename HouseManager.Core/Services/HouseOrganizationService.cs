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
				CreatorId = houseOrg.CreatorId,
				Units = [],
				Managers = []
			};

			await context.HouseOrganizations.AddAsync(newHouseOrg);
			await context.SaveChangesAsync();

			return await GetIdByNameAsync(newHouseOrg.Name);
		}

		public async Task EditAsync(HouseOrganizationFormModel houseOrg)
		{
			var editHouse = await GetByIdAsync(houseOrg.Id).FirstOrDefaultAsync();

			editHouse.Name = houseOrg.Name;
			editHouse.Address = houseOrg.Address;
			editHouse.Town = houseOrg.Town;

			await context.SaveChangesAsync();
		}

		public async Task<bool> ExistByIdAsync(int houseOrgId)
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
								  Town = ho.Town,
								  CreatorId = ho.CreatorId
							  })
							  .AsNoTracking();
		}

		public IQueryable<HouseOrganizationDetailViewModel> GetDetailsByIdReadOnly(int houseOrgId)
		{
			return context.HouseOrganizations
							  .Include(ho => ho.Units)
							  .ThenInclude(u => u.Occupants)
							  .Where(ho => ho.Id == houseOrgId)
							  .Select(ho => new HouseOrganizationDetailViewModel
							  {
								  Id = ho.Id,
								  Name = ho.Name,
								  Address = ho.Address,
								  Town = ho.Town,
								  PresidentName = GetManagerName(ho.Managers, ManagerPosition.President),
								  CashierName = GetManagerName(ho.Managers, ManagerPosition.Cashier),
								  UnitsCount = ho.Units.Count.ToString(),
								  OccupantsCount = GetOccupantsCount(ho.Units).ToString()
							  })
							  .AsNoTracking();
		}

		public IQueryable<HouseOrganization?> GetByIdAsync(int houseOrgId)
		{
			return context.HouseOrganizations
									.Where(ho => ho.Id == houseOrgId)
									.Include(ho => ho.Managers)
									.Include(ho => ho.Units)
									.ThenInclude(u => u.Occupants);
		}

		public async Task<string> GetNameByIdAsync(int houseOrgId)
		{
				return await context.HouseOrganizations
									.Where(ho => ho.Id == houseOrgId)
									.Select(ho => ho.Name)
									.FirstOrDefaultAsync();
		}

		public IQueryable<HouseOrganizationViewModel> GetAllByCreatorIdAsync(string creatorId)
		{
			return context.HouseOrganizations
							.Where(ho => ho.CreatorId == creatorId)
							.Select(h => new HouseOrganizationViewModel
							{
								Id = h.Id,
								Name = h.Name,
								Address = h.Address,
								Town = h.Town
							})
							.AsNoTracking();
		}

		public IQueryable<HouseOrganizationViewModel> GetAllManagedByAsync(List<int> id)
		{
			var result = context.HouseOrganizations
							.Select(h => new
							{
								h.Id,
								h.Name,
								h.Address,
								h.Town,
								Managers = h.Managers
													.Select(m => new { m.Id, m.IsActive })
													.Where(m => id.Contains(m.Id) && m.IsActive)
													.ToList()
							});

			return result
				.Where(r => r.Managers.Any())
				   .Select(r => new HouseOrganizationViewModel
				   {
					   Id = r.Id,
					   Name = r.Name,
					   Address = r.Address,
					   Town = r.Town
				   });
		}

		public IQueryable<HouseOrganizationViewModel> GetAllOccupiedByAsync(List<int> id)
		{
			var result = context.Units
							.Select(u => new
							{
								u.HouseOrganization,
								Occupants = u.Occupants
												.Where(o => id.Contains(o.Id) && o.IsActive)
												.ToList()
							});

			return result
					.Where(u => u.Occupants.Any())
					.Select(u => new HouseOrganizationViewModel
					{
						Id = u.HouseOrganization.Id,
						Name = u.HouseOrganization.Name,
						Address = u.HouseOrganization.Address,
						Town = u.HouseOrganization.Town
					});
		}

		#region Private Methods
		private async Task<int> GetIdByNameAsync(string name)
		{
			return await context.HouseOrganizations
				.Where(ho => ho.Name == name)
				.Select(ho => ho.Id)
				.FirstOrDefaultAsync();
		}

		private static int GetOccupantsCount(ICollection<Unit> units)
		{
			return units
					.Sum(u => u.Occupants.Count(o => o.IsActive));
		}

		private static string GetManagerName(ICollection<Manager> managers, ManagerPosition position)
		{
			var result = managers
							.Where(m => m.Position == position && m.IsActive)
							.Select(m => m.Name)
							.FirstOrDefault();

			return result?.ToString() ?? "Not assigned";
		}
		#endregion
	}
}
