using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

using static HouseManager.Infrastructure.Constants.EntityConstants;

namespace HouseManager.Infrastructure.Data.Models
{
    /// <summary>
    /// Entity that holds the towns names
    /// </summary>
    public class Town
	{
		/// <summary>
		/// Primary identifier of the Town
		/// </summary>
		[Key]
		[Comment("Primary identifier of the Town")]
		public int Id { get; set; }

		/// <summary>
		/// Name of the Town
		/// </summary>
		[Required]
		[MaxLength(TownNameMaxLength)]
		[Comment("Name of the Town")]
        public required string Name { get; set; }

    }
}