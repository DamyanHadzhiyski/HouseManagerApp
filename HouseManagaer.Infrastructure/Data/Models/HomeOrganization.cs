using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HouseManager.Infrastructure.Constants.EntityConstants;

namespace HouseManager.Infrastructure.Data.Models
{
	/// <summary>
	/// Entity that holds information for the home organizations
	/// </summary>
	public class HomeOrganization
	{
		/// <summary>
		/// Primary identifier of the Home Organization
		/// </summary>
		[Key]
		[Comment("Primary identifier of the Home Organization")]
		public int Id { get; set; }

		/// <summary>
		/// Name of the Home Organization
		/// </summary>
		[Required]
		[StringLength(HomeOrganizationNameMaxLength)]
		[Comment("Name of the Home Organization")]
		public required string Name { get; set; }


		/// <summary>
		/// Address of the Home Organization
		/// </summary>
		[Required]
		[StringLength(AddressMaxLength)]
		[Comment("Address of the Home Organization")]
        public required string Address { get; set; }

		/// <summary>
		/// Town of the Home Organization
		/// </summary>
		[Required]
		[Comment("Town of the Home Organization")]
        public required int TownId { get; set; }

		/// <summary>
		/// Navigation property to Towns table
		/// </summary>
        [ForeignKey(nameof(TownId))]
        public required Town Town { get; set; }


		/// <summary>
		/// Landlord of the Home Organization
		/// </summary>
		[Required]
		[Comment("President of the Home Organization")]
        public required int PresidentId { get; set; }

		/// <summary>
		/// Navigation property to Management table
		/// </summary>
		[ForeignKey(nameof(PresidentId))]
        public required BoardMember President { get; set; }


		/// <summary>
		/// Cashier of the Home Organization
		/// </summary>
		[Required]
		[Comment("Cashier of the Home Organization")]
		public required int CashierId { get; set; }

		/// <summary>
		/// Navigation property to Management table
		/// </summary>
		[ForeignKey(nameof(CashierId))]
		public required BoardMember Cashier { get; set; }

	}
}
