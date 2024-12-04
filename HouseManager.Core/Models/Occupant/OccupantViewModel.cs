using System.ComponentModel.DataAnnotations;

namespace HouseManager.Core.Models.OccupantModels
{
	/// <summary>
	/// Model of a occupant used in the top level layers of the app for visualization
	/// of occupant information
	/// </summary>
	public class OccupantViewModel
	{
		/// <summary>
		/// Primary identifier of the occupant
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Occupant full name
		/// </summary>
		[Display(Name = "Full Name")]
		public string FullName { get; set; } = string.Empty;

		/// <summary>
		/// Flag if the occupant is owner of the unit
		/// </summary>
		public string IsOwner { get; set; } = string.Empty;

		/// <summary>
		/// Phone number of the occupant
		/// </summary>
		[Display(Name = "Phone Number")]
		public string? PhoneNumber { get; set; }
	}
}
