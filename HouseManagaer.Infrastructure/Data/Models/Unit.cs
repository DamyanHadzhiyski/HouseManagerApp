using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using static HouseManager.Infrastructure.Constants.EntityConstants;

namespace HouseManager.Infrastructure.Data.Models
{
    /// <summary>
    /// Entity that holds information about the units
    /// </summary>
    public class Unit
	{
		/// <summary>
		/// Primary identifier of the unit
		/// </summary>
		[Key]
        [Comment("Primary identifier of the unit")]
		public int Id { get; set; }

        /// <summary>
        /// Identifier of the unit type
        /// </summary>
        [Required]
        [Comment("Identifier of the unit type")]
        public required int UnitTypeId { get; set; }

        /// <summary>
        /// Navigation property to UnitTypes table
        /// </summary>
        [ForeignKey(nameof(UnitTypeId))]
        public UnitType UnitType { get; set; } = null!;

		/// <summary>
		/// Floor on which the unit is located
		/// </summary>
		[Required]
        [Comment("Floor on which the unit is located")]
        public required int Floor { get; set; }

        /// <summary>
        /// Unique number of the unit
        /// </summary>
        [Required]
        [Comment("Number of the unit")]
        public required string UnitNumber { get; set; }

        /// <summary>
        /// Total area of the unit in m2
        /// </summary>
        [Required]
        [Comment("Total area of the unit")]
        public required decimal TotalArea { get; set; }

        /// <summary>
        /// Common parts in percentage that are adjacent ot the unit
        /// </summary>
		[Required]
        [Range(typeof(decimal), UnitCommonPartsMinArea, UnitCommonPartsMaxArea)]
        [Comment("Common parts adjacent to the unit")]
		public required decimal CommonParts { get; set; }

        /// <summary>
        /// Number of pats that are taken out in the common areas
        /// </summary>
        [Comment("Number of pets in the unit")]
        public int PetsCount { get; set; }

		/// <summary>
		/// The credit/debit of the unit
		/// </summary>
        [Comment("The credit/debit of the unit")]
        public decimal Balance { get; set; }

        /// <summary>
        /// Occupants that live in the unit
        /// </summary>
        public ICollection<Occupant> Occupants { get; set; } = [];
    }
}
