using HouseManager.Core.Models.Finances;

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
		/// Method that calculates the current financial balance for the house organization after new income or expense
		/// </summary>
		/// <param name="houseOrgId"></param>
		/// <param name="amount"></param>
		/// <returns></returns>
		Task CalculateHouseOrgBalanceAsync(int houseOrgId, decimal amount);

		/// <summary>
		/// Method that calculates the current financial balance a unit after new income or expense
		/// </summary>
		/// <param name="unitId"></param>
		/// <param name="amount"></param>
		/// <returns></returns>
		Task CalculateUnitBalanceAsync(int unitId, decimal amount);

		/// <summary>
		/// Method that returns all incomes of a specified house organization
		/// </summary>
		/// <param name="houseOrgId"></param>
		/// <returns></returns>
		Task<List<IncomeViewModel>> GetHouseOrgIncomesByIdAsync(int houseOrgId);

		/// <summary>
		/// Method that returns all expenses of a specified house organization
		/// </summary>
		/// <param name="houseOrgId"></param>
		/// <returns></returns>
		IQueryable<ExpenseViewModel> GetHouseOrgExpensesByIdAsync(int houseOrgId);

		/// <summary>
		/// Method that return current balance of a specified house organization
		/// </summary>
		/// <param name="houseOrgId"></param>
		/// <returns></returns>
		Task<decimal> GetHouseOrgBalanceByIdAsync(int houseOrgId);
	}
}
