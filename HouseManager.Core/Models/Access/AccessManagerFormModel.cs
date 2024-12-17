using System.ComponentModel.DataAnnotations;

using HouseManager.Infrastructure.Enums;

namespace HouseManager.Core.Models.Access
{
	/// <summary>
	/// Model that is used to confirm the user access rights as manager
	/// </summary>
	public class AccessManagerFormModel
	{
		/// <summary>
		/// User that will be provided with access
		/// </summary>
		[Required]
		public string UserId { get; set; } = string.Empty;

		/// <summary>
		/// Type of access that will be provided
		/// </summary>
		[Required]
		public ManagerPosition Position { get; set; }

		/// <summary>
		/// Code provided by the user
		/// </summary>
		[Required]
		[Display(Name = "Access Code")]
		public string AccessCode { get; set; } = string.Empty;
	}
}
