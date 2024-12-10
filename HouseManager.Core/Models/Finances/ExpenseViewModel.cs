namespace HouseManager.Core.Models.Finances
{
	/// <summary>
	/// Model of an income used for visualization at the top level layers of the app
	/// </summary>
	public class ExpenseViewModel
	{
		/// <summary>
		/// Expense amount
		/// </summary>
		public string Amount { get; set; } = string.Empty;

		/// <summary>
		/// The way the expense is split
		/// </summary>
		public string SplitType { get; set; } = string.Empty;

		/// <summary>
		/// Expense date
		/// </summary>
		public string Date { get; set; } = string.Empty;

		/// <summary>
		/// Information about the expense
		/// </summary>
		public string Description { get; set; } = string.Empty;
	}
}