using System.ComponentModel.DataAnnotations;

namespace HouseManager.Core.Models.HouseOrganization
{
	/// <summary>
	/// Model that extends the HouseOrganizationModel in order to 
	/// show additional details for the House Organization
	/// </summary>
	public class HouseOrganizationDetailViewModel : HouseOrganizationViewModel
    {
		/// <summary>
		/// Name of the president of the House Organization
		/// </summary>
		[Display(Name = "President")]
        public string PresidentName { get; set; } = string.Empty;

		/// <summary>
		/// Name of the cashier of the House Organization
		/// </summary>
		[Display(Name = "Cashier")]
		public string CashierName { get; set; } = string.Empty;

		/// <summary>
		/// Number of units in the House Organization
		/// </summary>
		public string UnitsCount { get; set; } = string.Empty;

		/// <summary>
		/// Number of occupants of the House Organization
		/// </summary>
		public string OccupantsCount { get; set; } = string.Empty;
	}
}
