using System.ComponentModel.DataAnnotations;

using HouseManager.Infrastructure.Enums;

using Microsoft.EntityFrameworkCore;

using static HouseManager.Infrastructure.Constants.EntityConstants;

namespace HouseManager.Infrastructure.Data.Models
{
    /// <summary>
    /// Entity that holds information for the board members of the home organizations
    /// </summary>
    public class BoardMember
	{
		/// <summary>
		/// Primary identifier of the board member
		/// </summary>
		[Key]
		[Comment("Primary identifier of the board member")]
		public int Id { get; set; }

        /// <summary>
        /// Board member name
        /// </summary>
        [Required]
		[MaxLength(FullNameMaxLength)]
        [Comment("Board member full name")]
        public required string Name { get; set; }

        /// <summary>
        /// Board member position
        /// </summary>
        [Required]
		[Comment("Board member position")]
		public required BoardMemberPosition Position { get; set; }

		/// <summary>
		/// Start date of assignment to the board member position
		/// </summary>
		[Required]
		[Comment("Start date of assignment to the board member position")]
		public required DateTime StartDate { get; set; }

		/// <summary>
		/// Due date of assignment to the board member position
		/// </summary>
		[Required]
		[Comment("Due date of assignment to the board member position")]
		public required DateTime EndDate { get; set; }


		/// <summary>
		/// Phone number of the board member
		/// </summary>
		[Required]
		[RegularExpression(PhoneNumberRegEx)]
		[Comment("Phone number of the board member")]
        public required string PhoneNumber { get; set; }

		/// <summary>
		/// Managed by the member house organization
		/// </summary>
		[Required]
		[Comment("Managed by the member house organization")]
		public required int HouseOrganizationId { get; set; }
	}
}