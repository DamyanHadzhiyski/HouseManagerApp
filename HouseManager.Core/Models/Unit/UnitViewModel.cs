namespace HouseManager.Core.Models.Unit
{
    /// <summary>
    /// Model of a house organization used in the top level layers of the app
    /// </summary>
    public class UnitViewModel
	{/// <summary>
	 /// Primary identifier of the unit
	 /// </summary>

		public int Id { get; set; }

		/// <summary>
		/// Type of the unit
		/// </summary>
		public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Floor on which the unit is located
        /// </summary>
		public string Floor { get; set; } = string.Empty;

        /// <summary>
        /// Unique number of the unit
        /// </summary>
        public string Number { get; set; } = string.Empty;
	}
}
