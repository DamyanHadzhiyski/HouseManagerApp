using System.Text.RegularExpressions;

using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Finances;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;
using HouseManager.Infrastructure.Enums;

using Microsoft.EntityFrameworkCore;

using static HouseManager.Core.Constants.DataConstants;

namespace HouseManager.Core.Services
{
	public class FinanceService(
		HouseManagerDbContext context,
		IHouseOrganizationService houseService) : IFinanceService
	{

		public async Task AddIncomeAsync(IncomeFormModel model)
		{
			var income = new Income
			{
				IncomeType = model.Type,
				Description = model.Description,
				Amount = model.Amount,
				IncomeDate = model.Date,
				UnitId = model.UnitId,
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
				var units = await houseService
									.GetByIdAsync(model.HouseOrganizationId)
									.Select(ho => ho.Units)
									.FirstOrDefaultAsync();

				var splitExpense = (decimal)(model.Amount / units.Count);

				foreach (var unit in units)
				{
					//await CalculateBalanceAsync<DbSet<Unit>>(context.Units, unit.Id, (splitExpense * -1));
				}

			}
			else if (model.SplitType == ExpenseSplitType.EachOccupant)
			{
				var units = await houseService
									.GetByIdAsync(model.HouseOrganizationId)
									.Select(ho => ho.Units)
									.FirstOrDefaultAsync();

				var occupants = units.Sum(u => u.Occupants.Count);

				var splitExpense = (decimal)(model.Amount / occupants);

				foreach (var unit in units)
				{
					var unitExpense = unit.Occupants.Count * splitExpense;

					//await CalculateBalanceAsync<DbSet<Unit>>(context.Units, unit.Id, (unitExpense * -1));
				}

			}
		}

		public async Task<FinancesViewModel?> GetHouseOrgFinancesByIdAsync(int houseOrgId)
		{
			return await context.HouseOrganizations
								.Where(ho => ho.Id == houseOrgId)
								.Include(ho => ho.Incomes)
								.Include(ho => ho.Expenses)
								.Include(ho => ho.Units)
								.Select(ho => new FinancesViewModel
								{
									Incomes = ho.Incomes
													.Select(i => new IncomeViewModel
													{
														Type = GetSplitName<IncomeType>(i.IncomeType),
														Amount = i.Amount.ToString("f2"),
														Date = i.IncomeDate.ToString(AppDateFormat),
														UnitNumber = i.UnitId == 0 ? "NA" : i.UnitId.ToString(),
														Description = i.Description
													})
													.ToList(),

									Expenses = ho.Expenses
													.Select(e => new ExpenseViewModel
													{
														Amount = e.Amount.ToString("f2"),
														Date = e.PaymentDate.ToString(AppDateFormat),
														SplitType = GetSplitName<ExpenseSplitType>(e.SplitType),
														Description = e.Description
													})
													.ToList(),

									CurrentBalance = ho.Balance
								})
								.FirstOrDefaultAsync();
		}

		private static string GetSplitName<T>(Enum splitType) where T : Enum
		{
				var splited = Regex.Matches(Enum.GetName(typeof(T), splitType), "([A-Z][a-z]+)");

				return string.Join(" ", splited);
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
	}
}
