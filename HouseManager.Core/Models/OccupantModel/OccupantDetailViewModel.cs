using System.ComponentModel.DataAnnotations;

namespace HouseManager.Core.Models.OccupantModel
{
	/// <summary>
	/// Model that extends the OccupantViewModel in order to 
	/// show additional details for the occupant
	/// </summary>
	public class OccupantDetailViewModel : OccupantViewModel
	{ 
		/// <summary>
		/// Occupant date of birth
		/// </summary>
		[Display(Name = "Birth Date")]
		public string BirthDate { get; set; } = string.Empty;

		/// <summary>
		/// Occupation date
		/// </summary>
		[Display(Name = "Occupation Date")]
		public string OccupationDate { get; set; } = string.Empty;

		/// <summary>
		/// Leave date
		/// </summary>
		[Display(Name = "Leave Date")]
		public string LeaveDate { get; set; } = string.Empty;
	}
}
