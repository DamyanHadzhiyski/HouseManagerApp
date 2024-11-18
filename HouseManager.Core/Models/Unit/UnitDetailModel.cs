using System.ComponentModel.DataAnnotations;

using HouseManager.Infrastructure.Data.Models;

namespace HouseManager.Core.Models.Unit
{
	/// <summary>
	/// Model that extends the UnitModel in order to 
	/// show additional details for the unit
	/// </summary>
	public class UnitDetailModel : UnitModel
	{


		/// <summary>
		/// Number of pats that are going out in the common areas
		/// </summary>
		public int PetsCount { get; set; }

		/// <summary>
		/// The credit/debit of the unit
		/// </summary>
		[Required]
		public required decimal Balance { get; set; }

		/// <summary>
		/// Occupants that live in the unit
		/// </summary>
		public ICollection<Occupant> Occupants { get; set; } = [];
	}
}
