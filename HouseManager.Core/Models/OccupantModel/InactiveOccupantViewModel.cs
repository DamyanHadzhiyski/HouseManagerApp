using System.ComponentModel.DataAnnotations;

namespace HouseManager.Core.Models.OccupantModel
{
	/// <summary>
	/// Model of a inactive occupant used in the top level layers of the app for visualization
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
