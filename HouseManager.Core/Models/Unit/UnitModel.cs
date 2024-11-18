using System.ComponentModel.DataAnnotations;

using HouseManager.Infrastructure.Data.Models;

using static HouseManager.Infrastructure.Constants.EntityConstants;

namespace HouseManager.Core.Models.Unit
{
	/// <summary>
	/// Model of a house organization used in the top level layers of the app
	/// </summary>
	public class UnitModel
	{/// <summary>
	 /// Primary identifier of the unit
	 /// </summary>

		public int Id { get; set; }

		/// <summary>
		/// Identifier of the unit type
		/// </summary>
		[Required]
		public int TypeId { get; set; }

		public UnitType Type { get; set; } = null!;

        /// <summary>
        /// Floor on which the unit is located
        /// </summary>
        [Required]
		public int Floor { get; set; }

		/// <summary>
		/// Unique number of the unit
		/// </summary>
		[Required]
		public string Number { get; set; } = string.Empty;

		/// <summary>
		/// Total area of the unit in m2
		/// </summary>
		[Required]
		public decimal TotalArea { get; set; }

		/// <summary>
		/// Common parts in percentage, that are adjacent to the unit
		/// </summary>
		[Required]
		[Range(typeof(decimal), UnitCommonPartsMinArea, UnitCommonPartsMaxArea)]
		public decimal CommonParts { get; set; }
	}
}
