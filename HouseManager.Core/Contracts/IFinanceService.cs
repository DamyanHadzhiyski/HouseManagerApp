using HouseManager.Core.Models.Finances;

using Microsoft.EntityFrameworkCore;

namespace HouseManager.Core.Contracts
{
	/// <summary>
	/// Interface that will be added into the IoC and used for 
	/// retrieval and manipulation data related to the house organization finances
	/// </summary>
	public interface IFinanceService
	{
		/// <summary>
		/// Method that creates new income record
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task AddIncomeAsync(IncomeFormModel model);

		/// <summary>
		/// Method that creates new expense record
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task AddExpenseAsync(ExpenseFormModel model);

		/// <summary>
		/// Method that returns current finances information for the house organization
		/// </summary>
		/// <param name="houseOrgId"></param>
		/// <returns></returns>
		Task<FinancesViewModel?> GetHouseOrgFinancesByIdAsync(int houseOrgId);

		/// <summary>
		/// Method that calculates the current financial balance for the house organization after new income or expense
		/// </summary>
		/// <param name="houseOrgId"></param>
		/// <param name="amount"></param>
		/// <returns></returns>
		//Task CalculateBalanceAsync(int houseOrgId, decimal amount);
		Task CalculateHouseOrgBalanceAsync(int id, decimal amount);
		Task CalculateUnitBalanceAsync(int id, decimal amount);
	}
}
