using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

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
		[MaxLength(UnitTypeNameMaxLength)]
		[Comment("Name of the UnitType")]
		public required string Name { get; set; }

		/// <summary>
		/// Short description of the UnitType
		/// </summary>
		[MaxLength(DescriptionMaxLength)]
		[Comment("Short description of the UnitType")]
        public string? Description { get; set; }
    }
}