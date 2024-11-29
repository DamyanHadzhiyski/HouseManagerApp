using System.ComponentModel.DataAnnotations;

namespace HouseManager.Core.Models.Manager
{
	/// <summary>
	/// Model of a president used in the top level layers of the app
	/// </summary>
	public class CashierViewModel
    {
		/// <summary>
		/// Primary identifier of the cashier
		/// </summary>
		public int Id { get; set; }

        /// <summary>
        /// Cashier name
        /// </summary>
        public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Start date of assignment to the cashier position
		/// </summary>
		[Display(Name = "Start Date")]
		public string StartDate { get; set; } = string.Empty;

		/// <summary>
		/// Due date of assignment to the cashier position
		/// </summary>
		[Display(Name = "End Date")]
		public string EndDate { get; set; } = string.Empty;

		/// <summary>
		/// Currently passed period
		/// </summary>
		public string Progress { get; set; } = string.Empty;


		/// <summary>
		/// Phone number of the cashier
		/// </summary>
		[Display(Name = "Phone Number")]
		public string PhoneNumber { get; set; } = string.Empty;

		/// <summary>
		/// Termination date of the cashier
		/// </summary>
		[Display(Name = "Termination Date")]
		public string TerminationDate { get; set; } = string.Empty;
	}
}