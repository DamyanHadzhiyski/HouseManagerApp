using System.ComponentModel.DataAnnotations;

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
    }
}
