using System.ComponentModel.DataAnnotations;

namespace HouseManager.Core.Models.Manager
{
	/// <summary>
	/// Model of a active manager used for visualization at the top level layers of the app
	/// </summary>
	public class ActiveManagementViewModel
	{
		/// <summary>
		/// Primary identifier of the manager
		/// </summary>
		public int Id { get; set; }

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
		/// Currently passed period
		/// </summary>
		public string Progress { get; set; } = string.Empty;

		/// <summary>
		/// Phone number of the manager
		/// </summary>
		[Display(Name = "Phone Number")]
		public string PhoneNumber { get; set; } = string.Empty;
	}
}
