using System.Text.RegularExpressions;

using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Finances;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;
using HouseManager.Infrastructure.Enums;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

using static HouseManager.Core.Constants.DataConstants;

namespace HouseManager.Core.Services
{
	/// <summary>
	/// Implementation of the IFinanceService
	/// </summary>
	/// <param name="context"></param>
	public class FinanceService(
		HouseManagerDbContext context) : IFinanceService
	{
		public async Task AddIncomeAsync(IncomeFormModel model)
		{
			var income = new Income
			{
				Description = model.Description,
				Amount = model.Amount,
				IncomeDate = model.Date,
				UnitId = model.UnitId,
				UnitNumber = model.UnitNumber,
				HouseOrganizationId = model.HouseOrganizationId
			};

			await context.Incomes.AddAsync(income);
			await context.SaveChangesAsync();
		}

		public async Task AddExpenseAsync(ExpenseFormModel model)
		{
			var expense = new Expense
			{
				Description = model.Description,
				Amount = model.Amount,
				SplitType = model.SplitType,
				PaymentDate = model.Date,
				HouseOrganizationId = model.HouseOrganizationId
			};

			await context.Expenses.AddAsync(expense);
			await context.SaveChangesAsync();

			if (model.SplitType == ExpenseSplitType.EachUnit)
			{
				await SplitExpenseToEachUnit(model.HouseOrganizationId, model.Amount);

			}
			else if (model.SplitType == ExpenseSplitType.EachOccupant)
			{
				await SplitExpenseToEachOccupant(model.HouseOrganizationId, model.Amount);
			}
		}

		public async Task<List<IncomeViewModel>> GetHouseOrgIncomesByIdAsync(int houseOrgId)
		{
			return await context.Incomes
								.Where(i => i.HouseOrganizationId == houseOrgId)
								.Select(i => new IncomeViewModel
								{
									Amount = i.Amount.ToString("f2"),
									Date = i.IncomeDate.ToString(AppDateFormat),
									UnitNumber = i.UnitNumber,
									Description = i.Description
								})
								.ToListAsync();
		}

		public IQueryable<ExpenseViewModel> GetHouseOrgExpensesByIdAsync(int houseOrgId)
		{
			return context.Expenses
								.Where(e => e.HouseOrganizationId == houseOrgId)
								.Select(e => new ExpenseViewModel
								{
									Amount = e.Amount.ToString("f2"),
									Date = e.PaymentDate.ToString(AppDateFormat),
									SplitType = FormatTypeName<ExpenseSplitType>(e.SplitType),
									Description = e.Description
								});
		}

		public async Task<decimal> GetHouseOrgBalanceByIdAsync(int houseOrgId)
		{
			return await context.HouseOrganizations
								.Where(ho => ho.Id == houseOrgId)
								.Select(ho => ho.Balance)
								.FirstOrDefaultAsync();
		}

		public async Task CalculateUnitBalanceAsync(int id, decimal amount)
		{
			var unit = await context.Units
										.FirstOrDefaultAsync(u => u.Id == id);

			unit.Balance += amount;

			await context.SaveChangesAsync();
		}

		public async Task CalculateHouseOrgBalanceAsync(int id, decimal amount)
		{
			var houseOrg = await context.HouseOrganizations
										.FirstOrDefaultAsync(u => u.Id == id);

			houseOrg.Balance += amount;

			await context.SaveChangesAsync();
		}

		#region Private Methods
		private static string FormatTypeName<T>(Enum splitType) where T : Enum
		{
			var splited = Regex.Matches(Enum.GetName(typeof(T), splitType), "([A-Z][a-z]+)");

			return string.Join(" ", splited);
		}

		private async Task<List<Unit>> GetUnits(int houseOrgId)
		{
			return await context.Units
								.Where(ho => ho.Id == houseOrgId)
								.ToListAsync();
		}

		private async Task SplitExpenseToEachOccupant(int houseOrgId, decimal amount)
		{
			var units = await GetUnits(houseOrgId);

			var occupants = units.Sum(u => u.Occupants.Count(o => o.IsActive && DateAndTime.DateDiff("Year", DateTime.Now,o.BirthDate) > 18));

			var amountEach = (decimal)(amount / occupants);

			foreach (var unit in units)
			{
				var unitExpense = unit.Occupants.Count * amountEach;

				await CalculateUnitBalanceAsync(unit.Id, (unitExpense * -1));
			}
		}

		private async Task SplitExpenseToEachUnit(int houseOrgId, decimal amount)
		{
			var units = await GetUnits(houseOrgId);

			var amountEach = (decimal)(amount / units.Count);

			foreach (var unit in units)
			{
				await CalculateUnitBalanceAsync(unit.Id, (amountEach * -1));
			}
		}
		#endregion
	}
}
