using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using HouseManager.Infrastructure.Enums;

using Microsoft.EntityFrameworkCore;

using static HouseManager.Infrastructure.Constants.EntityConstants;

namespace HouseManager.Infrastructure.Data.Models
{
	/// <summary>
	/// Entity, that holds information for the president and cashier of the home organizations
	/// </summary>
	public class Manager
    {
        /// <summary>
        /// Primary identifier
        /// </summary>
        [Key]
        [Comment("Primary identifier")]
        public int Id { get; set; }

        /// <summary>
        /// Full name
        /// </summary>
        [Required]
        [MaxLength(FullNameMaxLength)]
        [Comment("Full name")]
        public required string Name { get; set; }

		/// <summary>
		/// Position of the manager
		/// </summary>
		[Required]
		[Comment("Position")]
		public required ManagerPosition Position { get; set; }

		/// <summary>
		/// Start date of assignment to the position
		/// </summary>
		[Required]
        [Comment("Start date of assignment to the position")]
        public required DateTime StartDate { get; set; }

        /// <summary>
        /// Due date of assignment to the position
        /// </summary>
        [Required]
        [Comment("Due date of assignment to the position")]
        public required TermPeriod TermPeriod { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [Required]
        [RegularExpression(PhoneNumberRegEx)]
        [Comment("Phone number")]
        public required string PhoneNumber { get; set; }

        /// <summary>
        /// Assigned to house organization
        /// </summary>
        [Required]
        [Comment("Assigned to house organization")]
        public required int HouseOrganizationId { get; set; }

        /// <summary>
        /// Navigation property to the House organization
        /// </summary>
        [ForeignKey(nameof(HouseOrganizationId))]
        [Comment("Navigation property to the House organization")]
        public HouseOrganization HouseOrganization { get; set; } = null!;

        /// <summary>
        /// Current status
        /// </summary>
        [Required]
        [Comment("Current status")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Date on which the term is terminated
        /// </summary>
        [Comment("Date on which the term is ended")]
        public DateTime TerminationDate { get; set; }
    }
}