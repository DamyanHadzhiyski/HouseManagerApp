using System.Text.RegularExpressions;

using Azure;

using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Finances;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;
using HouseManager.Infrastructure.Enums;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

using static HouseManager.Core.Constants.DataConstants;

namespace HouseManager.Core.Services
{
	public class FinanceService(
		HouseManagerDbContext context) : IFinanceService
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
				UnitNumber = model.UnitNumber,
				HouseOrganizationId = model.HouseOrganizationId
			};

			await context.Incomes.AddAsync(income);
			await context.SaveChangesAsync();
		}

		//TODO: Separate split type in methods
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
				var units = await GetUnits(model.HouseOrganizationId);

				var splitExpense = (decimal)(model.Amount / units.Count);

				foreach (var unit in units)
				{
					await CalculateUnitBalanceAsync(unit.Id, (splitExpense * -1));
				}

			}
			else if (model.SplitType == ExpenseSplitType.EachOccupant)
			{
				var units = await GetUnits(model.HouseOrganizationId);

				var occupants = units.Sum(u => u.Occupants.Count);

				var splitExpense = (decimal)(model.Amount / occupants);

				foreach (var unit in units)
				{
					var unitExpense = unit.Occupants.Count * splitExpense;

					await CalculateUnitBalanceAsync(unit.Id, (unitExpense * -1));
				}

			}
		}

		public async Task<List<IncomeViewModel>> GetHouseOrgIncomesByIdAsync(int houseOrgId)
		{
			return await context.Incomes
								.Where(i => i.HouseOrganizationId == houseOrgId)
								.Select(i => new IncomeViewModel
								{
									Type = FormatTypeName<IncomeType>(i.IncomeType),
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
		#endregion
	}
}
