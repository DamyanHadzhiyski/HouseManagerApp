namespace HouseManager.Core.Models.Finances
{
	public class FinancesViewModel
	{
		public decimal CurrentBalance { get; set; }

		public ICollection<IncomeViewModel> Incomes { get; set; } = [];

		public ICollection<ExpenseViewModel> Expenses { get; set; } = [];
	}
}
