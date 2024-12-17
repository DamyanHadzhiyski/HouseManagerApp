using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using static HouseManager.Infrastructure.Constants.EntityConstants;

namespace HouseManager.Infrastructure.Data.Models
{
	/// <summary>
	/// Entity that holds information for the incomes of the house organizations
	/// </summary>
	public class Income
	{
		/// <summary>
		/// Primary identifier of the Income
		/// </summary>
		[Key]
        [Comment("Primary identifier of the Income")]
		public int Id { get; set; }

		/// <summary>
		/// Amount of the Income
		/// </summary>
		[Required]
        [Comment("Amount of the Income")]
        public required decimal Amount { get; set; }

		/// <summary>
		/// Date of the Income
		/// </summary>
		[Required]
        [Comment("Date of the Income")]
        public required DateTime IncomeDate { get; set; }

		/// <summary>
		/// Unit which provided the Income, if any
		/// </summary>
		[Comment("Unit which provided the Income")]
        public int UnitId { get; set; }

		/// <summary>
		/// Navigation Property to Units Table
		/// </summary>
		[ForeignKey(nameof(UnitId))]
		public Unit Unit { get; set; } = null!;

		public string UnitNumber { get; set; } = string.Empty;

        /// <summary>
        /// Short description of the Income
        /// </summary>
        [MaxLength(DescriptionMaxLength)]
		[Comment("Short description of the Income")]
		public string Description { get; set; } = string.Empty;

		/// <summary>
		/// Primary identifier of the House Organization that received the income
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
