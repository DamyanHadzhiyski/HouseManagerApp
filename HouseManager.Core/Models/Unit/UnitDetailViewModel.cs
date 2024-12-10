using System.ComponentModel.DataAnnotations;

using HouseManager.Core.Models.OccupantModel;

namespace HouseManager.Core.Models.Unit
{
    /// <summary>
    /// Model that extends the UnitModel in order to 
    /// show additional details for the unit
    /// </summary>
    public class UnitDetailViewModel : UnitViewModel
	{
        /// <summary>
        /// Total area of the unit in m2
        /// </summary>
        [Display(Name = "Total Area")]
        public string TotalArea { get; set; } = string.Empty;

		/// <summary>
		/// Common parts in percentage that are adjacent ot the unit
		/// </summary>
		[Display(Name = "Common parts")]
		public string CommonParts { get; set; } = string.Empty;

		/// <summary>
		/// Number of pats that are going out in the common areas
		/// </summary>
		[Display(Name = "Occupants Count")]
		public int OccupantsCount { get; set; }

		/// <summary>
		/// The credit/debit of the unit
		/// </summary>
		public decimal Balance { get; set; }

		/// <summary>
		/// List with information for the active unit occupants
		/// </summary>
		public List<OccupantViewModel> ActiveOccupants { get; set; } = [];

		/// <summary>
		/// List with information for the inactive unit occupants
		/// </summary>
		public List<InactiveOccupantViewModel> InactiveOccupants { get; set; } = [];
	}
}
