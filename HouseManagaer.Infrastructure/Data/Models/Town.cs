using System.ComponentModel.DataAnnotations;

namespace HouseManager.Infrastructure.Data.Models
{
	public class Town
	{
		[Key] 
		public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

    }
}