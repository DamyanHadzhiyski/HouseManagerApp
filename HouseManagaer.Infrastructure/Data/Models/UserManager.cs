using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HouseManager.Infrastructure.Data.Models
{
	public class UserManager
	{
		/// <summary>
		/// App User to which the managers position is assigned
		/// </summary>
		[Required]
		[Comment("Primary identifier of the user")]
		public required string UserId { get; set; }

		/// <summary>
		/// Navigation property to Users table
		/// </summary>
		[ForeignKey(nameof(UserId))]
		[Comment("Navigation property ot the Identity Users table")]
		public IdentityUser User { get; set; } = null!;

		/// <summary>
		/// Manager to which the app user is assigned to
		/// </summary>
		[Required]
		[Comment("Primary identifier of the manager")]
		public required int ManagerId { get; set; }

		/// <summary>
		/// Navigation property to Managers table
		/// </summary>
		[ForeignKey(nameof(ManagerId))]
		[Comment("Navigation property ot the managers table")]
		public Manager Manager { get; set; } = null!;
	}
}
