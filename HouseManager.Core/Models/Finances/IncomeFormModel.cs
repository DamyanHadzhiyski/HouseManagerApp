using System.ComponentModel.DataAnnotations;

using HouseManager.Infrastructure.Enums;

using static HouseManager.Core.Constants.ErrorMessages;
using static HouseManager.Infrastructure.Constants.EntityConstants;

namespace HouseManager.Core.Models.Finances
{
	/// <summary>
	/// Model of an income used for visualization at the top level layers of the app
	/// </summary>
	public class IncomeFormModel
	{
		/// <summary>
		/// Type of the income
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		public IncomeType Type { get; set; }

		/// <summary>
		/// Income amount
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		public decimal Amount { get; set; }

		/// <summary>
		/// UnitId, if the income is made by unit
		/// </summary>
		public int UnitId { get; set; }

		public string UnitNumber { get; set; } = string.Empty;

        /// <summary>
        /// Income date
        /// </summary>
        [Required(ErrorMessage = FieldRequiredErrorMessage)]
		public DateTime Date { get; set; }

		/// <summary>
		/// Additional info, if any
		/// </summary>
		[StringLength(DescriptionMaxLength,
			MinimumLength = DescriptionMinLength,
			ErrorMessage = FieldLengthErrorMessage)]
		public string Description { get; set; } = string.Empty;

		/// <summary>
		/// House Organization that received the income
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		public int HouseOrganizationId { get; set; }
	}
}