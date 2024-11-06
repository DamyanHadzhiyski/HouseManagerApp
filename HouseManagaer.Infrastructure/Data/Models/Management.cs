using HouseManager.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseManager.Infrastructure.Data.Models
{
	public class Management
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public required ManagementPosition Position { get; set; }

		[Required]
		public required int HomeOrganizationId { get; set; }

		[ForeignKey(nameof(HomeOrganizationId))]
		public required HomeOrganization HomeOrganization { get; set; }

		[Required]
		public required DateTime StartDate { get; set; }

		[Required]
		public required DateTime EndDate { get; set; }

        [Required]
        public required string PhoneNumber { get; set; }
    }
}