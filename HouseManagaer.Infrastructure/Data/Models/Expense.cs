using System.ComponentModel.DataAnnotations;

namespace HouseManager.Infrastructure.Data.Models
{
	public class Expense
	{
		[Key]
		public int Id { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        public required decimal Amount { get; set; }

        [Required]
        public required DateTime PaymentDate { get; set; }
    }
}
