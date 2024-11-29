using System.ComponentModel.DataAnnotations;

using static HouseManager.Core.Constants.ErrorMessages;
using static HouseManager.Infrastructure.Constants.EntityConstants;

namespace HouseManager.Core.Models.Manager
{
	/// <summary>
	/// Model of a board member used in the top level layers of the app
	/// </summary>
	public class ActiveManagementFormModel : IValidatableObject
    {
        /// <summary>
        /// Primary identifier of the board member
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Manager name
        /// </summary>
        [Required(ErrorMessage = FieldRequiredErrorMessage)]
        [StringLength(FullNameMaxLength,
            MinimumLength = FullNameMinLength,
            ErrorMessage = FieldLengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        public string ManagerPosition { get; set; } = string.Empty;

        /// <summary>
        /// Start date of assignment to the management position
        /// </summary>
        [Required(ErrorMessage = FieldRequiredErrorMessage)]
        public DateTime StartDate { get; set; }

		/// <summary>
		/// Due date of assignment to the management position
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		public DateTime EndDate { get; set; }

        /// <summary>
        /// Phone number of the manager
        /// </summary>
        [Required(ErrorMessage = FieldRequiredErrorMessage)]
        [RegularExpression(PhoneNumberRegEx)]
        public string PhoneNumber { get; set; } = string.Empty;

		/// <summary>
		/// House organization managed by the manager
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		public int HouseOrganizationId { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			
			if(StartDate > EndDate)
			{
				yield return new ValidationResult("End Date cannot be before Start Date");
			}
		}
	}
}