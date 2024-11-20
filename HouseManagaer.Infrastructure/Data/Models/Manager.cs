using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using HouseManager.Infrastructure.Enums;

using Microsoft.EntityFrameworkCore;

using static HouseManager.Infrastructure.Constants.EntityConstants;

namespace HouseManager.Infrastructure.Data.Models
{
	/// <summary>
	/// Entity that holds information for the board members of the home organizations
	/// </summary>
	public class Manager
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
		public required ManagerPosition Position { get; set; }

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

		/// <summary>
		/// Navigation property to the House organization
		/// </summary>
		[ForeignKey(nameof(HouseOrganizationId))]
		[Comment("Navigation property to the House organization")]
		public HouseOrganization HouseOrganization { get; set; } = null!;

		/// <summary>
		/// Current status of the manager
		/// </summary>
		[Required]
		[Comment("Current status of the manager")]
		public required bool IsActive { get; set; }

		/// <summary>
		/// Date on which the term of the manager is terminated
		/// </summary>
        [Comment("Date on which the term is ended")]
        public DateTime? TerminationDate { get; set; }
    }
}