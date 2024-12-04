using HouseManager.Core.Contracts;
using HouseManager.Core.Enums;
using HouseManager.Core.Models.Manager;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;

using Microsoft.EntityFrameworkCore;

using static HouseManager.Core.Constants.DataConstants;

namespace HouseManager.Core.Services
{
	public class CashierService(
		HouseManagerDbContext context) : ICashierService
	{
		public async Task AddAsync(CashierFormModel model)
		{
			var newCashier = new Cashier
			{
				Name = model.Name,
				PhoneNumber = model.PhoneNumber,
				StartDate = model.StartDate,
				EndDate = GetEndDate(model.StartDate, model.TermPeriod),
				HouseOrganizationId = model.HouseOrganizationId,
				IsActive = true
			};

			await context.Cashiers.AddAsync(newCashier);
			await context.SaveChangesAsync();
		}

		public async Task EditAsync(CashierFormModel model)
		{
			var cashier = await GetByIdAsync(model.Id);

			cashier.Name = model.Name;
			cashier.PhoneNumber = model.PhoneNumber;
			cashier.StartDate = model.StartDate;
			cashier.EndDate = GetEndDate(model.StartDate, model.TermPeriod);

			await context.SaveChangesAsync();
		}

		public IQueryable<CashierViewModel> GetAllInactiveReadOnlyAsync(int houseOrgId)
		{
			return context.Cashiers
								.AsNoTracking()
								.Where(p => p.HouseOrganizationId == houseOrgId && p.IsActive == false)
								.OrderByDescending(p => p.TerminationDate)
								.Select(p => new CashierViewModel
								{
									Id = p.Id,
									Name = p.Name,
									StartDate = p.StartDate.ToString(DateFormat),
									EndDate = p.EndDate.ToString(DateFormat),
									PhoneNumber = p.PhoneNumber,
									TerminationDate = DateOnly.FromDateTime(p.TerminationDate).ToString(DateFormat) ?? "NA"
								});

		}

		public IQueryable<CashierViewModel?> GetActiveReadOnlyAsync(int houseOrgId)
		{
			return context.Cashiers
							.AsNoTracking()
							.Where(p => p.HouseOrganizationId == houseOrgId
											&& p.IsActive == true)
							.Select(p => new CashierViewModel
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
			var cashier = await GetByIdAsync(id);

			cashier.IsActive = false;
			cashier.TerminationDate = DateTime.Now;

			await context.SaveChangesAsync();

			return cashier.HouseOrganizationId;
		}

		public async Task<bool> ExistsByIdAsync(int id)
		{
			return await context.Cashiers
								.AnyAsync(p => p.Id == id);
		}

		private async Task<Cashier?> GetByIdAsync(int id)
		{
			return await context.Cashiers.FindAsync(id);
		}

		public async Task<bool> ActiveExistsAsync(int houseOrgId)
		{
			return await context.Cashiers
								.Where(p => p.HouseOrganizationId == houseOrgId)
								.AnyAsync(p => p.IsActive == true);
		}

		public async Task<bool> IsActiveAsync(int id)
		{
			return await context.Cashiers
								.AnyAsync(p => p.Id == id && p.IsActive == true);
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
