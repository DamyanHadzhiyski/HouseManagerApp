using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HouseManager.Infrastructure.Data.Models
{
	public class UnitType
	{
		[Key] 
		public int Id { get; set; }

		[Required] 
		public required string Name { get; set; }

        public string? Description { get; set; }
    }
}