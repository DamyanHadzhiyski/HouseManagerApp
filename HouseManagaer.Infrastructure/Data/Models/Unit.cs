using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseManager.Infrastructure.Data.Models
{
	public class Unit
	{
		[Key] 
		public int Id { get; set; }

        [Required]
        public required int UnitTypeId { get; set; }

        [Required]
        [ForeignKey(nameof(UnitTypeId))]
        public required UnitType UnitType { get; set; }

        [Required]
        public required int Floor { get; set; }

        [Required]
        public required string UnitNumber { get; set; }

        [Required]
        public required decimal TotalArea { get; set; }

		[Required]
		public required decimal CommonParts { get; set; }

        public int PetsCount { get; set; }

        [Required]
        public required decimal Saldo { get; set; }

        [Required]
        public required int HomeOrganizationId { get; set; }

        [ForeignKey(nameof(HomeOrganizationId))]
        public required HomeOrganization HomeOrganization { get; set; }
    }
}
