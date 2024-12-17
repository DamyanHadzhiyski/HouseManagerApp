using HouseManager.Core.Models.Pagination;

namespace HouseManager.Core.Models.Finances
{
	/// <summary>
	/// Model used for visualization of the finances of a house organization at the top level layers of the app
	/// </summary>
	public class FinancesViewModel
	{
		/// <summary>
		/// Current balance of the house organization
		/// </summary>
		public decimal CurrentBalance { get; set; }

		/// <summary>
		/// All incomes of the house organization
		/// </summary>
		public IncomesPageViewModel Incomes { get; set; } = null!;

		/// <summary>
		/// All expenses of the house organization
		/// </summary>
		public ExpensesPageViewModel Expenses { get; set; } = null!;
	}
}
