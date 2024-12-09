using System.ComponentModel.DataAnnotations;

using static HouseManager.Core.Constants.ErrorMessages;
using static HouseManager.Infrastructure.Constants.EntityConstants;

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
        public string Unit { get; set; } =string.Empty;

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