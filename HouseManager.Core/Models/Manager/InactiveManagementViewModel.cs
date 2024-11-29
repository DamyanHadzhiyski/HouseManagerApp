using System.ComponentModel.DataAnnotations;

namespace HouseManager.Core.Models.Manager
{
	public class InactiveManagementViewModel
	{
		/// <summary>
		/// President name
		/// </summary>
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Start date of assignment to the president position
		/// </summary>
		[Display(Name = "Start Date")]
		public string StartDate { get; set; } = string.Empty;

		/// <summary>
		/// Due date of assignment to the president position
		/// </summary>
		[Display(Name = "End Date")]
		public string EndDate { get; set; } = string.Empty;

		/// <summary>
		/// Termination date of the president
		/// </summary>
		[Display(Name = "Termination Date")]
		public string TerminationDate { get; set; } = string.Empty;
	}
}
