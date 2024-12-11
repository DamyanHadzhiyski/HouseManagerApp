using System.ComponentModel.DataAnnotations;

using HouseManager.Infrastructure.Enums;

namespace HouseManager.Core.Models.Management
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
		public ManagerPosition Position { get; set; }

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
