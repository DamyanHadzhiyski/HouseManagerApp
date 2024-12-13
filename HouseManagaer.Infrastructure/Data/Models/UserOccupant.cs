using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HouseManager.Infrastructure.Data.Models
{
	public class UserOccupant
	{
		[Required]
        [Comment("Primary identifier of the user")]
        public required string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
		[Comment("Navigation property ot the Identity Users table")]
		public IdentityUser User { get; set; } = null!;

		[Required]
		[Comment("Primary identifier of the occupant")]
		public required int OccupantId { get; set; }

		[ForeignKey(nameof(OccupantId))]
		[Comment("Navigation property ot the occupants table")]
		public Occupant Occupant { get; set; } = null!;
	}
}
