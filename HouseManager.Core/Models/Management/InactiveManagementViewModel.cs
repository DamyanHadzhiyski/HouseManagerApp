using System.ComponentModel.DataAnnotations;

namespace HouseManager.Core.Models.Manager
{
	/// <summary>
	/// Model of a inactive manager used for visualization at the top level layers of the app
	/// </summary>
	public class InactiveManagementViewModel
	{
		/// <summary>
		/// Manager name
		/// </summary>
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Position of the manager
		/// </summary>
		[Display(Name = "Manager Position")]
		public string Position { get; set; } = string.Empty;

		/// <summary>
		/// Start date of assignment to the position
		/// </summary>
		[Display(Name = "Start Date")]
		public string StartDate { get; set; } = string.Empty;

		/// <summary>
		/// Due date of assignment to the position
		/// </summary>
		[Display(Name = "End Date")]
		public string EndDate { get; set; } = string.Empty;

		/// <summary>
		/// Termination date
		/// </summary>
		[Display(Name = "Termination Date")]
		public string TerminationDate { get; set; } = string.Empty;
	}
}
