using System.ComponentModel.DataAnnotations;

namespace HouseManager.Core.Models.Finances
{
	/// <summary>
	/// Model of an income used for visualization at the top level layers of the app
	/// </summary>
	public class IncomeViewModel
	{
		/// <summary>
		/// Type of the income
		/// </summary>
        public string Type { get; set; } =string.Empty;

		/// <summary>
		/// Income amount
		/// </summary>
		public string Amount { get; set; } =string.Empty;

		/// <summary>
		/// Unit number, if the income is made by unit
		/// </summary>
		[Display(Name = "Unit")]
        public string UnitNumber { get; set; } = string.Empty;

		/// <summary>
		/// Income date
		/// </summary>
		public string Date { get; set; } =string.Empty;

		/// <summary>
		/// Addition info, if any
		/// </summary>
        public string Description { get; set; } =string.Empty;
    }
}