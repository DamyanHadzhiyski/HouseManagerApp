using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HouseManager.Infrastructure.Data.Models
{
    /// <summary>
    /// Entity that holds the connection between occupants and users that have app registration
    /// </summary>
    public class RegisteredOccupant
	{
		/// <summary>
		/// Primary identifier of a registered user
		/// </summary>
		[Required]
        [Comment("Primary identifier of a registered user")]
        public required string UserId { get; set; }

		/// <summary>
		/// Navigation property to the IdentityUsers table
		/// </summary>
        [ForeignKey(nameof(UserId))]
        public required IdentityUser User { get; set; }

		/// <summary>
		/// Primary identifier of a occupant
		/// </summary>
		[Required]
		[Comment("Primary identifier of a occupant")]
		public required int OccupantId { get; set; }

		/// <summary>
		/// Navigation property to the Occupants table
		/// </summary>
		[ForeignKey(nameof(OccupantId))]
        public required Occupant Occupant { get; set; }
    }
}
