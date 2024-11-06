using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseManager.Infrastructure.Data.Models
{
	public class RegisteredOccupant
	{
		[Key] 
		public int Id { get; set; }

        [Required]
        public required int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public required IdentityUser User { get; set; }

        [Required]
		public required int OccupantId { get; set; }

        [ForeignKey(nameof(OccupantId))]
        public required Occupant Occupant { get; set; }
    }
}
