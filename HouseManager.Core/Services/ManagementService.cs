using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Management;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;
using HouseManager.Infrastructure.Enums;

using Microsoft.EntityFrameworkCore;

using static HouseManager.Core.Constants.DataConstants;

namespace HouseManager.Core.Services
{
	public class ManagementService(
		HouseManagerDbContext context) : IManagementService
	{
		public async Task AddAsync(ActiveManagementFormModel model)
		{
			var newPresident = new Manager
			{
				Name = model.Name,
				PhoneNumber = model.PhoneNumber,
				Position = model.Position,
				StartDate = model.StartDate,
				TermPeriod = model.TermPeriod,
				HouseOrganizationId = model.HouseOrganizationId,
				IsActive = true
			};

			await context.Managers.AddAsync(newPresident);
			await context.SaveChangesAsync();
		}

		public async Task EditAsync(ActiveManagementFormModel model)
		{
			var president = await GetByIdAsync(model.Id);

			president.Name = model.Name;
			president.PhoneNumber = model.PhoneNumber;
			president.StartDate = model.StartDate;
			president.TermPeriod = model.TermPeriod;

			await context.SaveChangesAsync();
		}

		public IQueryable<ActiveManagementViewModel?> GetActiveReadOnlyAsync(int houseOrgId)
		{
			var test = context.Managers
							.AsNoTracking()
							.Where(p => p.HouseOrganizationId == houseOrgId
											&& p.IsActive == true)
							.Select(p => new ActiveManagementViewModel
							{
								Id = p.Id,
								Name = p.Name,
								Position = p.Position,
								StartDate = p.StartDate.ToString(DateFormat),
								EndDate = GetEndDate(p.StartDate, p.TermPeriod).ToString(DateFormat),
								PhoneNumber = p.PhoneNumber,
								Progress = GetProgress(p.StartDate, GetEndDate(p.StartDate, p.TermPeriod))
							});

			return test;
		}

		public IQueryable<InactiveManagementViewModel?> GetAllInactiveReadOnlyAsync(int houseOrgId)
		{
			var test = context.Managers
								.AsNoTracking()
								.Where(p => p.HouseOrganizationId == houseOrgId && p.IsActive == false)
								.OrderByDescending(p => p.TerminationDate)
								.Select(p => new InactiveManagementViewModel
								{
									Name = p.Name,
									Position = p.Position,
									StartDate = p.StartDate.ToString(DateFormat),
									EndDate = GetEndDate(p.StartDate, p.TermPeriod).ToString(DateFormat),
									TerminationDate = DateOnly.FromDateTime(p.TerminationDate).ToString(DateFormat) ?? "NA"
								});
			return test;
		}

		public async Task<int> EndTermAsync(int id)
		{
			var president = await GetByIdAsync(id);

			president.IsActive = false;
			president.TerminationDate = DateTime.Now;

			await context.SaveChangesAsync();

			return president.HouseOrganizationId;
		}

		public async Task<bool> ExistsByIdAsync(int id)
		{
			return await context.Managers
								.AnyAsync(p => p.Id == id);
		}

		public async Task<bool> ActiveExistsAsync(int houseOrgId, ManagerPosition position)
		{
			return await context.Managers
								.Where(p => p.HouseOrganizationId == houseOrgId 
												&& p.Position == position)
								.AnyAsync(p => p.IsActive == true);
		}

		public async Task<bool> IsActiveAsync(int id)
		{
			return await context.Managers
								.AnyAsync(p => p.Id == id && p.IsActive == true);
		}

		public async Task<Manager?> GetByIdAsync(int id)
		{
			return await context.Managers.FindAsync(id);
		}

		#region Private Methods
		private static string GetProgress(DateTime startDate, DateTime endDate)
		{
			decimal progress = 100;
			var range = (endDate - startDate).TotalDays;
			var elapsed = (DateTime.Now - startDate).TotalDays;

			if (elapsed < range)
			{
				progress = (decimal)(elapsed / range) * 100m;
			}
			

			return progress.ToString("f2");
		}

		private static DateTime GetEndDate(DateTime startDate, TermPeriod termPeriod)
		{
			return startDate.AddMonths((int)termPeriod);
		}
		#endregion
	}
}
