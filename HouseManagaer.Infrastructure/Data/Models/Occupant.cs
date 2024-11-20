using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using static HouseManager.Infrastructure.Constants.EntityConstants;

namespace HouseManager.Infrastructure.Data.Models
{
    /// <summary>
    /// Entity that holds information for the occupants
    /// </summary>
    public class Occupant
	{
		/// <summary>
		/// Primary identifier of the occupant
		/// </summary>
		[Key]
        [Comment("Primary identifier of the occupant")]
		public int Id { get; set; }

		/// <summary>
		/// Occupant full name
		/// </summary>
		[Required]
		[MaxLength(FullNameMaxLength)]
        [Comment("Occupant full name")]
        public required string FullName { get; set; }

		/// <summary>
		/// Occupant date of birth
		/// </summary>
		[Required]
		[Comment("Occupant date of birth")]
		public required DateOnly BirthDate { get; set; }

		/// <summary>
		/// Flag if the occupant is owner of the unit
		/// </summary>
		[Required]
		[Comment("Flag if the occupant is owner of the unit")]
        public required bool IsOwner { get; set; }

		/// <summary>
		/// Phone number of the occupant
		/// </summary>
		[RegularExpression(PhoneNumberRegEx)]
		[Comment("Phone number of the occupant")]
        public string? PhoneNumber { get; set; }

		/// <summary>
		/// House Organization of the unit
		/// </summary>
		[Required]
		[Comment("Unit to which occupant is assigned")]
        public int UnitId { get; set; }

		/// <summary>
		/// Navigation property to Units table
		/// </summary>
		[ForeignKey(nameof(UnitId))]
		public Unit Unit { get; set; } = null!;
    }
}
         