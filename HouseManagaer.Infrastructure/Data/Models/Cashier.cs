using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using static HouseManager.Infrastructure.Constants.EntityConstants;

namespace HouseManager.Infrastructure.Data.Models
{
	/// <summary>
	/// Entity that holds information for the cashier of the home organizations
	/// </summary>
	public class Cashier
	{
		/// <summary>
		/// Primary identifier of the cashier
		/// </summary>
		[Key]
		[Comment("Primary identifier of the cashier")]
		public int Id { get; set; }

        /// <summary>
        /// Cashier name
        /// </summary>
        [Required]
		[MaxLength(FullNameMaxLength)]
        [Comment("Cashier full name")]
        public required string Name { get; set; }

		/// <summary>
		/// Start date of assignment to the cashier position
		/// </summary>
		[Required]
		[Comment("Start date of assignment to the cashier position")]
		public required DateTime StartDate { get; set; }

		/// <summary>
		/// Due date of assignment to the cashier position
		/// </summary>
		[Required]
		[Comment("Due date of assignment to the cashier position")]
		public required DateTime EndDate { get; set; }


		/// <summary>
		/// Phone number of the cashier
		/// </summary>
		[Required]
		[RegularExpression(PhoneNumberRegEx)]
		[Comment("Phone number of the cashier")]
        public required string PhoneNumber { get; set; }

		/// <summary>
		/// Managed by the cashier house organization
		/// </summary>
		[Required]
		[Comment("Managed by the cashier house organization")]
		public required int HouseOrganizationId { get; set; }

		/// <summary>
		/// Navigation property to the House organization
		/// </summary>
		[ForeignKey(nameof(HouseOrganizationId))]
		[Comment("Navigation property to the House organization")]
		public HouseOrganization HouseOrganization { get; set; } = null!;

		/// <summary>
		/// Current status of the cashier
		/// </summary>
		[Required]
		[Comment("Current status of the cashier")]
		public required bool IsActive { get; set; }

		/// <summary>
		/// Date on which the term of the cashier is terminated
		/// </summary>
		[Comment("Date on which the term is ended")]
        public DateTime? TerminationDate { get; set; }
    }
}