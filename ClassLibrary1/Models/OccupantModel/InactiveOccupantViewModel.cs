using System.ComponentModel.DataAnnotations;

namespace HouseManager.Core.Models.OccupantModel
{
	/// <summary>
	/// Model of a occupant used in the top level layers of the app for visualization
	/// of occupant information
	/// </summary>
	public class InactiveOccupantViewModel : OccupantViewModel
	{
		/// <summary>
		/// Date on which the occupant left the unit
		/// </summary>
		[Display(Name = "Left On")]		
		public string LeaveDate { get; set; } = string.Empty;
	}
}
