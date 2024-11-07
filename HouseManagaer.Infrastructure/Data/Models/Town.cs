using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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
		[StringLength(TownNameMaxLength)]
		[Comment("Name of the Town")]
        public required string Name { get; set; }

    }
}