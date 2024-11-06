using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseManager.Infrastructure.Data.Models
{
	public class HomeOrganization
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public required string Name { get; set; }

        [Required]
        public required string Address { get; set; }

        [Required]
        public required int TownId { get; set; }

        [ForeignKey(nameof(TownId))]
        public required Town Town { get; set; }

        [Required]
        public required int LandlordId { get; set; }

        [ForeignKey(nameof(LandlordId))]
        public required Management Landlord { get; set; }
		
		[Required]
		public required int CashierId { get; set; }

		[ForeignKey(nameof(CashierId))]
		public required Management Cashier { get; set; }

	}
}
