using System.ComponentModel.DataAnnotations;

using HouseManager.Infrastructure.Enums;

using Microsoft.EntityFrameworkCore;

using static HouseManager.Infrastructure.Constants.EntityConstants;

namespace HouseManager.Infrastructure.Data.Models
{
    /// <summary>
    /// Entity that holds information for the incomes of the home orgaznizations
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
		/// Type of the Income
		/// </summary>
		[Required]
        [Comment("Type of the Income")]
        public required IncomeType IncomeType { get; set; }

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
		/// Short description of the Income
		/// </summary>
		[MaxLength(DescriptionMaxLength)]
		[Comment("Short description of the Income")]
        public string? Description { get; set; }
    }
}
