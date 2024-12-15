using System.ComponentModel.DataAnnotations;

namespace HouseManager.Core.Models.Unit
{
    /// <summary>
    /// Model of a unit used in the top level layers of the app
    /// </summary>
    public class UnitViewModel
	{
		/// <summary>
		/// Primary identifier of the unit
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Unique number of the unit
		/// </summary>
		[Display(Name = "Unit number")]
		public string Number { get; set; } = string.Empty;

		/// <summary>
		/// Floor on which the unit is located
		/// </summary>
		[Display(Name = "Floor")]
		public string Floor { get; set; } = string.Empty;

		/// <summary>
		/// Type of the unit
		/// </summary>
		[Display(Name = "Unit type")]
		public string Type { get; set; } = string.Empty;
	}
}
