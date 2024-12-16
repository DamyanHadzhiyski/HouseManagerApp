using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HouseManager.Infrastructure.Data.Models
{
	public class UserOccupant
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
		/// Occupant to which the app user is assigned to
		/// </summary>
		[Required]
		[Comment("Primary identifier of the occupant")]
		public required int OccupantId { get; set; }

		/// <summary>
		/// Navigation property to Occupants table
		/// </summary>
		[ForeignKey(nameof(OccupantId))]
		[Comment("Navigation property to the occupants table")]
		public Occupant Occupant { get; set; } = null!;
	}
}
