namespace HouseManager.Core.Models.Unit
{
	/// <summary>
	/// Model used to show only the id and the number of a unit
	/// </summary>
	public class UnitShortViewModel
	{
		/// <summary>
		/// Primary identifier of the unit
		/// </summary>
        public int Id { get; set; }

		/// <summary>
		/// Number of the unit
		/// </summary>
		public string Number { get; set; } = string.Empty;
    }
}
