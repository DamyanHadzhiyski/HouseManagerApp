using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static HouseManager.Infrastructure.Constants.EntityConstants;

namespace HouseManager.Infrastructure.Data.Models
{
	/// <summary>
	/// Entity that holds the names and description of a different unit types
	/// </summary>
	public class UnitType
	{
		/// <summary>
		/// Primary identifier of the UnitType
		/// </summary>
		[Key]
		[Comment("Primary identifier of the UnitType")]
		public int Id { get; set; }

		/// <summary>
		/// Name of the UnitType
		/// </summary>
		[Required]
		[StringLength(UnitTypeNameMaxLength)]
		[Comment("Name of the UnitType")]
		public required string Name { get; set; }

		/// <summary>
		/// Short description of the UnitType
		/// </summary>
		[StringLength(DescriptionMaxLength)]
		[Comment("Short description of the UnitType")]
        public string? Description { get; set; }
    }
}