using System.ComponentModel.DataAnnotations;

using HouseManager.Infrastructure.Enums;

using static HouseManager.Infrastructure.Constants.EntityConstants;
using static HouseManager.Core.Constants.ErrorMessages;

namespace HouseManager.Core.Models.BoardMember
{
    /// <summary>
    /// Model of a board member used in the top level layers of the app
    /// </summary>
    public class BoardMemberModel
    {

        /// <summary>
        /// Primary identifier of the board member
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Board member name
        /// </summary>
        [Required(ErrorMessage = FieldRequiredErrorMessage)]
        [StringLength(FullNameMaxLength,
            MinimumLength = FullNameMinLength,
            ErrorMessage = FieldLengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Board member position
        /// </summary>
        [Required(ErrorMessage = FieldRequiredErrorMessage)]
        public BoardMemberPosition Position { get; set; }

        /// <summary>
        /// Start date of assignment to the board member position
        /// </summary>
        [Required(ErrorMessage = FieldRequiredErrorMessage)]
		[DisplayFormat(DataFormatString = "dd/MM/yyyy")]
		public DateTime StartDate { get; set; }

        /// <summary>
        /// Due date of assignment to the board member position
        /// </summary>
        [Required(ErrorMessage = FieldRequiredErrorMessage)]
        public DateTime EndDate { get; set; }


        /// <summary>
        /// Phone number of the board member
        /// </summary>
        [Required(ErrorMessage = FieldRequiredErrorMessage)]
        [RegularExpression(PhoneNumberRegEx)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}