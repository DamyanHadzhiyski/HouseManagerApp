namespace HouseManager.Core.Models.Unit
{
    /// <summary>
    /// Model that extends the UnitModel in order to 
    /// show additional details for the unit
    /// </summary>
    public class UnitDetailViewModel : UnitViewModel
	{
        /// <summary>
        /// Total area of the unit in m2
        /// </summary>
        public string TotalArea { get; set; } = string.Empty;

        /// <summary>
        /// Common parts in percentage that are adjacent ot the unit
        /// </summary>
        public string CommonParts { get; set; } = string.Empty;

        /// <summary>
        /// Number of pats that are going out in the common areas
        /// </summary>
        public string PetsCount { get; set; } = string.Empty;

        /// <summary>
        /// The credit/debit of the unit
        /// </summary>
        public string Balance { get; set; } = string.Empty;

		//TODO: Add details for the occupants
	}
}
