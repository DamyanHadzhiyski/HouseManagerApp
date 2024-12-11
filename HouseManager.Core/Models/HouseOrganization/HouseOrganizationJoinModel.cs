using System.ComponentModel.DataAnnotations;

namespace HouseManager.Core.Models.HouseOrganization
{
    /// <summary>
    /// Model that is used to confirm the user access rights
    /// </summary>
	public class HouseOrganizationJoinModel
	{
		/// <summary>
		/// House organization to which user will be joined
		/// </summary>
		[Required]
		public int HouseOrganizationId { get; set; }

		/// <summary>
		/// Code provided by house organization president
		/// </summary>
		[Required]
        public string ConfirmationCode { get; set; } = string.Empty;
    }
}
