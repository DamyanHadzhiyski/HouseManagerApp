using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
		/// Occupant first name
		/// </summary>
		[Required]
		[StringLength(FirstNameMaxLength)]
        [Comment("Occupant first name")]
        public required string FirstName { get; set; }

		/// <summary>
		/// Occupant middle name
		/// </summary>
		[Comment("Occupant middle name")]
		[StringLength(MiddleNameMaxLength)]
		public string? MiddleName { get; set; }

		/// <summary>
		/// Occupant last name
		/// </summary>
		[Required]
		[StringLength(LastNameMaxLength)]
		[Comment("Occupant last name")]
		public required string LastName { get; set; }

		/// <summary>
		/// Occupant date of birth
		/// </summary>
		[Required]
		[Comment("Occupant date of birth")]
		public required DateOnly BirthDate { get; set; }

		/// <summary>
		/// Unit occupied
		/// </summary>
		[Required]
		[Comment("Unit occupied")]
		public required int UnitId { get; set; }

		/// <summary>
		/// Navigation property to the Units table
		/// </summary>
        [ForeignKey(nameof(UnitId))]
        public required Unit Unit { get; set; }

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
    }
}
