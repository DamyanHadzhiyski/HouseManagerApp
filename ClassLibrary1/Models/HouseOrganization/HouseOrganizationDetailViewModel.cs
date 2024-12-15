using System.ComponentModel.DataAnnotations;

using HouseManager.Core.Models.Unit;

namespace HouseManager.Core.Models.HouseOrganization
{
	/// <summary>
	/// Model that extends the HouseOrganizationViewModel in order to 
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
		[Display(Name = "Units Count")]
		public string UnitsCount { get; set; } = string.Empty;

		/// <summary>
		/// Number of occupants of the House Organization
		/// </summary>
		[Display(Name = "Occupants Count")]
		public string OccupantsCount { get; set; } = string.Empty;

		/// <summary>
		/// Information for the units in the house organization
		/// </summary>
		public ICollection<UnitViewModel> Units { get; set; } = [];
	}
}
