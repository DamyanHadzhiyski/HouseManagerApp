using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Managers;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;
using HouseManager.Infrastructure.Enums;

using Microsoft.EntityFrameworkCore;

using static HouseManager.Core.Constants.DataConstants;

namespace HouseManager.Core.Services
{
	/// <summary>
	/// Implementation of the IManagementService
	/// </summary>
	/// <param name="context"></param>
	public class ManagementService(
		HouseManagerDbContext context) : IManagementService
	{
		public async Task AddAsync(ActiveManagerFormModel model)
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

		public async Task EditAsync(ActiveManagerFormModel model)
		{
			var president = await context.Managers.FindAsync(model.Id);

			president.Name = model.Name;
			president.PhoneNumber = model.PhoneNumber;
			president.StartDate = model.StartDate;
			president.TermPeriod = model.TermPeriod;

			await context.SaveChangesAsync();
		}

		public async Task<ActiveManagerFormModel?> GetByIdAsync(int id)
		{
			return await context.Managers
							.Where(m => m.Id == id)
							.Select(m => new ActiveManagerFormModel
							{
								Id = m.Id,
								Name = m.Name,
								Position = m.Position,
								StartDate = m.StartDate,
								TermPeriod = m.TermPeriod,
								PhoneNumber = m.PhoneNumber
							})
							.FirstOrDefaultAsync();
		}

		public IQueryable<ActiveManagerViewModel> GetAllActiveReadOnlyAsync(int houseOrgId)
		{
			return context.Managers
							.AsNoTracking()
							.Where(p => p.HouseOrganizationId == houseOrgId
											&& p.IsActive == true)
							.Select(p => new ActiveManagerViewModel
							{
								Id = p.Id,
								Name = p.Name,
								Position = p.Position,
								StartDate = p.StartDate.ToString(AppDateFormat),
								EndDate = CalculateEndDate(p.StartDate, p.TermPeriod).ToString(AppDateFormat),
								PhoneNumber = p.PhoneNumber,
								Progress = GetProgress(p.StartDate, CalculateEndDate(p.StartDate, p.TermPeriod))
							});
		}

		public IQueryable<InactiveManagerViewModel> GetAllInactiveReadOnlyAsync(int houseOrgId)
		{
			return context.Managers
								.AsNoTracking()
								.Where(p => p.HouseOrganizationId == houseOrgId && p.IsActive == false)
								.OrderByDescending(p => p.TerminationDate)
								.Select(p => new InactiveManagerViewModel
								{
									Name = p.Name,
									Position = p.Position,
									StartDate = p.StartDate.ToString(AppDateFormat),
									EndDate = CalculateEndDate(p.StartDate, p.TermPeriod).ToString(AppDateFormat),
									TerminationDate = DateOnly.FromDateTime(p.TerminationDate).ToString(AppDateFormat) ?? "NA"
								});
		}

		public async Task<int> EndTermAsync(int id)
		{
			var manager = await context.Managers.FindAsync(id);

			manager.IsActive = false;
			manager.TerminationDate = DateTime.Now;

			await context.SaveChangesAsync();

			return manager.HouseOrganizationId;
		}

		public async Task<bool> IsActiveAsync(int id)
		{
			return await context.Managers
								.AnyAsync(p => p.Id == id && p.IsActive == true);
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

		private static DateTime CalculateEndDate(DateTime startDate, TermPeriod termPeriod)
		{
			return startDate.AddMonths((int)termPeriod);
		}
		#endregion
	}
}
