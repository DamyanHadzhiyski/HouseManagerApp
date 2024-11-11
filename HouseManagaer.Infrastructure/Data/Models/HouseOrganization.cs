using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using static HouseManager.Infrastructure.Constants.EntityConstants;

namespace HouseManager.Infrastructure.Data.Models
{
    /// <summary>
    /// Entity that holds information for the house organizations
    /// </summary>
    public class HouseOrganization
	{
		/// <summary>
		/// Primary identifier of the Home Organization
		/// </summary>
		[Key]
		[Comment("Primary identifier of the House Organization")]
		public int Id { get; set; }

		/// <summary>
		/// Name of the Home Organization
		/// </summary>
		[Required]
		[MaxLength(HouseOrganizationNameMaxLength)]
		[Comment("Name of the House Organization")]
		public required string Name { get; set; }


		/// <summary>
		/// Address of the Home Organization
		/// </summary>
		[Required]
		[MaxLength(AddressMaxLength)]
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
		/// Collection of board members(president and cashier) of the house organization
		/// </summary>
		public ICollection<BoardMember> BoardMembers { get; set; } = [];

		/// <summary>
		/// Collection of all units belonging to the house organization
		/// </summary>
		public ICollection<Unit> Units { get; set; } = [];

    }
}
