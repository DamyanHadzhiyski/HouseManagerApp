using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseManager.Infrastructure.Data.Models
{
	public class Occupant
	{
		[Key]
		public int Id { get; set; }

        [Required]
        public required string FirstName { get; set; }

        public string? MiddleName { get; set; }

		[Required]
		public required string LastName { get; set; }

        [Required]
        public required DateOnly BirthDate { get; set; }

        [Required]
        public required int UnitId { get; set; }

        [ForeignKey(nameof(UnitId))]
        public required Unit Unit { get; set; }

        [Required]
        public required bool IsOwner { get; set; }

        [Required]
        public required string PhoneNumber { get; set; }
    }
}
