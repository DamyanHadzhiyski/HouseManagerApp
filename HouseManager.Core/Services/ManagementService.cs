using HouseManager.Core.Contracts;
using HouseManager.Core.Enums;
using HouseManager.Core.Models.Manager;
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
				Position = ManagerPosition.President,
				StartDate = model.StartDate,
				EndDate = GetEndDate(model.StartDate, model.TermPeriod),
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
			president.EndDate = GetEndDate(model.StartDate, model.TermPeriod);

			await context.SaveChangesAsync();
		}

		public IQueryable<InactiveManagementViewModel> GetAllInactiveReadOnlyAsync(int houseOrgId)
		{
			return context.Managers
								.AsNoTracking()
								.Where(p => p.HouseOrganizationId == houseOrgId && p.IsActive == false)
								.OrderByDescending(p => p.TerminationDate)
								.Select(p => new InactiveManagementViewModel
								{
									Name = p.Name,
									StartDate = p.StartDate.ToString(DateFormat),
									EndDate = p.EndDate.ToString(DateFormat),
									TerminationDate = DateOnly.FromDateTime(p.TerminationDate).ToString(DateFormat) ?? "NA"
								});

		}

		public IQueryable<ActiveManagementViewModel?> GetActiveReadOnlyAsync(int houseOrgId)
		{
			return context.Managers
							.AsNoTracking()
							.Where(p => p.HouseOrganizationId == houseOrgId
											&& p.IsActive == true)
							.Select(p => new ActiveManagementViewModel
							{
								Id = p.Id,
								Name = p.Name,
								StartDate = p.StartDate.ToString(DateFormat),
								EndDate = p.EndDate.ToString(DateFormat),
								PhoneNumber = p.PhoneNumber,
								Progress = GetProgress(p.StartDate, p.EndDate)
							});
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

		public async Task<bool> ActiveExistsAsync(int houseOrgId)
		{
			return await context.Managers
								.Where(p => p.HouseOrganizationId == houseOrgId)
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
			var range = (endDate - startDate).TotalDays;
			var elapsed = (DateTime.Now - startDate).TotalDays;
			var progress = (decimal)(elapsed / range) * 100m;

			return progress.ToString();
		}

		private static DateTime GetEndDate(DateTime startDate, TermPeriod termPeriod)
		{
			return startDate.AddMonths((int)termPeriod);
		}
		#endregion
	}
}
