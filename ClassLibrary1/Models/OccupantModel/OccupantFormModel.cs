using System.ComponentModel.DataAnnotations;

using static HouseManager.Infrastructure.Constants.EntityConstants;
using static HouseManager.Core.Constants.ErrorMessages;
using Microsoft.EntityFrameworkCore;

namespace HouseManager.Core.Models.OccupantModel
{
	/// <summary>
	/// Model of a occupant used in the top level layers of the app for creation and edit
	/// </summary>
	public class OccupantFormModel
	{
		/// <summary>
		/// Primary identifier of the occupant
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Occupant full name
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		[StringLength(FullNameMaxLength,
			MinimumLength = FullNameMinLength,
			ErrorMessage = FieldLengthErrorMessage)]
		[Display(Name = "Full Name")]
		public string FullName { get; set; } =string.Empty;

		/// <summary>
		/// Occupant date of birth
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		[Display(Name = "Birth Date")]
		public DateOnly BirthDate { get; set; }

		/// <summary>
		/// Flag if the occupant is owner of the unit
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		[Display(Name = "Owner")]
		public bool IsOwner { get; set; }

		/// <summary>
		/// Phone number of the occupant
		/// </summary>
		[RegularExpression(PhoneNumberRegEx)]
		[Display(Name = "Phone Number")]
		public string? PhoneNumber { get; set; }

		/// <summary>
		/// Unit occupied by the occupant
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		public int UnitId { get; set; }

		/// <summary>
		/// Occupation date
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		[Display(Name = "Occupation Date")]
		public DateOnly OccupationDate { get; set; }
	}
}
