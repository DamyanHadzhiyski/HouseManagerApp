using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using static HouseManager.Infrastructure.Constants.EntityConstants;

namespace HouseManager.Infrastructure.Data.Models
{
	/// <summary>
	/// Entity that holds information for the president of the home organizations
	/// </summary>
	public class President
	{
		/// <summary>
		/// Primary identifier of the president
		/// </summary>
		[Key]
		[Comment("Primary identifier of the president")]
		public int Id { get; set; }

        /// <summary>
        /// President name
        /// </summary>
        [Required]
		[MaxLength(FullNameMaxLength)]
        [Comment("President full name")]
        public required string Name { get; set; }

		/// <summary>
		/// Start date of assignment to the president position
		/// </summary>
		[Required]
		[Comment("Start date of assignment to the president position")]
		public required DateTime StartDate { get; set; }

		/// <summary>
		/// Due date of assignment to the president position
		/// </summary>
		[Required]
		[Comment("Due date of assignment to the president position")]
		public required DateTime EndDate { get; set; }


		/// <summary>
		/// Phone number of the president
		/// </summary>
		[Required]
		[RegularExpression(PhoneNumberRegEx)]
		[Comment("Phone number of the president")]
        public required string PhoneNumber { get; set; }

		/// <summary>
		/// Managed by the president house organization
		/// </summary>
		[Required]
		[Comment("Managed by the president house organization")]
		public required int HouseOrganizationId { get; set; }

		/// <summary>
		/// Navigation property to the House organization
		/// </summary>
		[ForeignKey(nameof(HouseOrganizationId))]
		[Comment("Navigation property to the House organization")]
		public HouseOrganization HouseOrganization { get; set; } = null!;

		/// <summary>
		/// Current status of the president
		/// </summary>
		[Required]
		[Comment("Current status of the president")]
		public required bool IsActive { get; set; }

		/// <summary>
		/// Date on which the term of the president is terminated
		/// </summary>
		[Comment("Date on which the term is ended")]
        public DateTime? TerminationDate { get; set; }
    }
}