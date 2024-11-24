using System.ComponentModel.DataAnnotations;

using HouseManager.Infrastructure.Data.Models;
using HouseManager.Infrastructure.Enums;

using static HouseManager.Infrastructure.Constants.EntityConstants;
using static HouseManager.Core.Constants.ErrorMessages;

namespace HouseManager.Core.Models.Unit
{
	public class UnitFormModel
	{
		/// <summary>
		/// Identifier of the unit type
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		public UnitType Type { get; set; }

		/// <summary>
		/// Floor on which the unit is located
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		public int Floor { get; set; }

		/// <summary>
		/// Unique number of the unit
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		public string Number { get; set; } = string.Empty;

		/// <summary>
		/// Total area of the unit in m2
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		[Display(Name = "Total Area")]
		public decimal TotalArea { get; set; }

		/// <summary>
		/// Common parts in percentage that are adjacent ot the unit
		/// </summary>
		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		[Range(typeof(decimal),
			UnitCommonPartsMinArea,
			UnitCommonPartsMaxArea,
			ErrorMessage = FieldInRangeErrorMessage)]
		[Display(Name = "Common Parts")]
		public decimal CommonParts { get; set; }

		/// <summary>
		/// Number of pets that are taken out in the common areas
		/// </summary>
		[Display(Name = "Pets Count")]
		public int PetsCount { get; set; }

		[Required(ErrorMessage = FieldRequiredErrorMessage)]
		public int HouseOrganizationId { get; set; }

		/// <summary>
		/// Occupants that live in the unit
		/// </summary>
		public ICollection<Occupant> Occupants { get; set; } = [];
	}
}
