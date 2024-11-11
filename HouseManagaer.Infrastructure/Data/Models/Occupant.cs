using System.ComponentModel.DataAnnotations;

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
		[MaxLength(OccupantFullNameMaxLength)]
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
    }
}
         