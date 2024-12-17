using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using HouseManager.Infrastructure.Enums;

using Microsoft.EntityFrameworkCore;

using static HouseManager.Infrastructure.Constants.EntityConstants;

namespace HouseManager.Infrastructure.Data.Models
{
	/// <summary>
	/// Entity that holds information for made expenses
	/// </summary>
	public class Expense
	{
		/// <summary>
		/// Primary key of the expense
		/// </summary>
		[Key]
        [Comment("Primary key of the expense")]
		public int Id { get; set; }

		/// <summary>
		/// Short description of the expense
		/// </summary>
		[Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Short description of the expense")]
        public required string Description { get; set; }

		/// <summary>
		/// Amount of the expense
		/// </summary>
		[Required]
		[Comment("Amount of the expense")]
		public required decimal Amount { get; set; }

		/// <summary>
		/// Date on which the payment is made
		/// </summary>
		[Required]
        [Comment("Date on which the payment is made")]
        public required DateTime PaymentDate { get; set; }

		/// <summary>
		/// How the expense is spread inside of the house organization
		/// </summary>
		[Required]
		[Comment("How the expense is spread")]
		public ExpenseSplitType SplitType { get; set; }

		/// <summary>
		/// Primary identifier of the House Organization that made the expense
		/// </summary>
		[Required]
		[Comment("Primary identifier of the House Organization")]
		public required int HouseOrganizationId { get; set; }

		/// <summary>
		/// Navigation property to the HouseOrganizations table
		/// </summary>
		[ForeignKey(nameof(HouseOrganizationId))]
		public HouseOrganization HouseOrganization { get; set; } = null!;
	}
}
