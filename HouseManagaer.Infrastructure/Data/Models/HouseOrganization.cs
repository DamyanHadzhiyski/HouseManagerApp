﻿using System.ComponentModel.DataAnnotations;

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
        /// Primary identifier of the House Organization
        /// </summary>
        [Key]
		[Comment("Primary identifier of the House Organization")]
		public int Id { get; set; }

        /// <summary>
        /// Name of the House Organization
        /// </summary>
        [Required]
		[MaxLength(HouseOrganizationNameMaxLength)]
		[Comment("Name of the House Organization")]
		public required string Name { get; set; }


        /// <summary>
        /// Address of the House Organization
        /// </summary>
        [Required]
		[MaxLength(AddressMaxLength)]
		[Comment("Address of the House Organization")]
        public required string Address { get; set; }

        /// <summary>
        /// Town in which the House Organization is located
        /// </summary>
        [Required]
		[MaxLength(TownNameMaxLength)]
		[Comment("Town of the House Organization")]
        public required string Town { get; set; }

		/// <summary>
		/// Presidents (active/inactive) of the house organization
		/// </summary>
		public ICollection<President> Presidents { get; set; } = [];

		/// <summary>
		/// Cashier (active/inactive) of the house organization
		/// </summary>
		public ICollection<Cashier> Cashiers { get; set; } = [];

		/// <summary>
		/// Collection of all units belonging to the house organization
		/// </summary>
		public ICollection<Unit> Units { get; set; } = [];

    }
}
