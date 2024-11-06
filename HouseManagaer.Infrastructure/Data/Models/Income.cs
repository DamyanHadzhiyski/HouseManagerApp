using HouseManager.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;

namespace HouseManager.Infrastructure.Data.Models
{
	public class Income
	{
		[Key]
		public int Id { get; set; }

        [Required]
        public required IncomeType IncomeType { get; set; }

        [Required]
        public required decimal Amount { get; set; }

        [Required]
        public required DateTime IncomeDate { get; set; }

        public int UnitId { get; set; }

        public string? Description { get; set; }
    }
}
