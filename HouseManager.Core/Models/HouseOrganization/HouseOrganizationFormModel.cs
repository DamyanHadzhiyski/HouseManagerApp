﻿using System.ComponentModel.DataAnnotations;

using static HouseManager.Core.Constants.ErrorMessages;
using static HouseManager.Infrastructure.Constants.EntityConstants;

namespace HouseManager.Core.Models.HouseOrganization
{
	/// <summary>
	/// Model of a house organization used in the top level layers of the app
	/// </summary>
	public class HouseOrganizationFormModel
    {
        /// <summary>
        /// Primary identifier of the House Organization
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the House Organization
        /// </summary>
        [Required(ErrorMessage = FieldRequiredErrorMessage)]
        [StringLength(HouseOrganizationNameMaxLength,
            MinimumLength = HouseOrganizationNameMinLength,
            ErrorMessage = FieldLengthErrorMessage)]
        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;


        /// <summary>
        /// Address of the House Organization
        /// </summary>
        [Required(ErrorMessage = FieldRequiredErrorMessage)]
        [StringLength(AddressMaxLength,
            MinimumLength = AddressMinLength,
            ErrorMessage = FieldLengthErrorMessage)]
        [Display(Name = "Address")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Name of the town in which the House Organization is located
        /// </summary>
        [Required(ErrorMessage = FieldRequiredErrorMessage)]
        [Display(Name = "Town")]
        public string Town{ get; set; } = string.Empty;

		/// <summary>
		/// Id of the user that created the House Organization
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		[Display(Name = "Created By")]
		public string CreatorId { get; set; } = string.Empty;
	}
}