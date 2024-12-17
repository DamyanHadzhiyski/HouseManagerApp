using System.ComponentModel.DataAnnotations;

namespace HouseManager.Core.Models.Access
{
	/// <summary>
	/// Model that is used to confirm the user access rights as occupant
	/// </summary>
	public class AccessOccupantFormModel
    {
        /// <summary>
        /// User that will be provided with access
        /// </summary>
        [Required]
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Code provided by the user
        /// </summary>
        [Required]
		[Display(Name = "Access Code")]
		public string AccessCode { get; set; } = string.Empty;
    }
}
