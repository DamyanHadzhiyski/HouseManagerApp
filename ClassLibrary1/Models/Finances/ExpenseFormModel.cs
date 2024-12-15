using System.ComponentModel.DataAnnotations;

using HouseManager.Infrastructure.Enums;

using static HouseManager.Core.Constants.ErrorMessages;
using static HouseManager.Infrastructure.Constants.EntityConstants;

namespace HouseManager.Core.Models.Finances
{
	/// <summary>
	/// Model of an income used for visualization at the top level layers of the app
	/// </summary>
	public class ExpenseFormModel
	{
		/// <summary>
		/// Expense amount
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		public decimal Amount { get; set; }

		/// <summary>
		/// Expense date
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		public DateTime Date { get; set; }

		/// <summary>
		/// The way the expense is split
		/// </summary>
		[Required(ErrorMessage =FieldRequiredErrorMessage)]
		public ExpenseSplitType SplitType { get; set; }

		/// <summary>
		/// Information about the expense
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		[StringLength(DescriptionMaxLength,
			MinimumLength = DescriptionMinLength,
			ErrorMessage = FieldLengthErrorMessage)]
		public string Description { get; set; } = string.Empty;

		/// <summary>
		/// House Organization that made the expense
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		public int HouseOrganizationId { get; set; }
	}
}