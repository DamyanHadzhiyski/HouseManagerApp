using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HouseManager.Infrastructure.Data.Models
{
	public class UserManager
	{
		[Required]
		[Comment("Primary identifier of the user")]
		public required string UserId { get; set; }

		[ForeignKey(nameof(UserId))]
		[Comment("Navigation property ot the Identity Users table")]
		public IdentityUser User { get; set; } = null!;

		[Required]
		[Comment("Primary identifier of the manager")]
		public required int ManagerId { get; set; }

		[ForeignKey(nameof(ManagerId))]
		[Comment("Navigation property ot the managers table")]
		public Manager Manager { get; set; } = null!;
	}
}
