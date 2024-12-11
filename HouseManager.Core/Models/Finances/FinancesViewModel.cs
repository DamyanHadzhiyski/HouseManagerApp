using HouseManager.Core.Models.Pagination;

namespace HouseManager.Core.Models.Finances
{
	public class FinancesViewModel
	{
		public decimal CurrentBalance { get; set; }

		public IncomesPageViewModel Incomes { get; set; } = null!;

		public ExpensesPageViewModel Expenses { get; set; } = null!;
	}
}
