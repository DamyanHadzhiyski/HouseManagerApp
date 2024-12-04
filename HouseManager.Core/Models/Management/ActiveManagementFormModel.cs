using System.ComponentModel.DataAnnotations;

using HouseManager.Core.Enums;
using HouseManager.Infrastructure.Enums;

using static HouseManager.Core.Constants.ErrorMessages;
using static HouseManager.Infrastructure.Constants.EntityConstants;

namespace HouseManager.Core.Models.Manager
{
	/// <summary>
	/// Model of a manager used for add/edit functionalities on the top level layers of the app
	/// </summary>
	public class ActiveManagementFormModel
    {
        /// <summary>
        /// Primary identifier of the manager
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

        [Display(Name="Manager Position")]
        public ManagerPosition Position { get; set; }

        /// <summary>
        /// Start date of assignment to the management position
        /// </summary>
        [Required(ErrorMessage = FieldRequiredErrorMessage)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

		/// <summary>
		/// Due date of assignment to the management position
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
        [Display(Name = "Term Period")]
		public TermPeriod TermPeriod { get; set; }

        /// <summary>
        /// Phone number of the manager
        /// </summary>
        [Required(ErrorMessage = FieldRequiredErrorMessage)]
        [RegularExpression(PhoneNumberRegEx)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

		/// <summary>
		/// House organization managed by the manager
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		public int HouseOrganizationId { get; set; }
	}
}