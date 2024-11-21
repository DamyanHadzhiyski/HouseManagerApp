using System.ComponentModel.DataAnnotations;

namespace HouseManager.Core.Models.HouseOrganization
{
	/// <summary>
	/// Model of a house organization used in the top level layers of the app
	/// </summary>
	public class HouseOrganizationViewModel
    {
        /// <summary>
        /// Primary identifier of the House Organization
        /// </summary>
        public int Id { get; set; }

		/// <summary>
		/// Name of the House Organization
		/// </summary>
		[Display(Name = "Name")]
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Address of the House Organization
		/// </summary>
		[Display(Name = "Address")]
		public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Name of the town in which the House Organization is located
        /// </summary>
        [Display(Name = "Town")]
        public string Town { get; set; } = string.Empty;
    }
}