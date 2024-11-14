namespace HouseManager.Core.Models.HouseOrganization
{
    /// <summary>
    /// Model that extends the HouseOrganizationModel in order to 
    /// show additional details for the House Organization
    /// </summary>
    public class HouseOrganizationDetailModel : HouseOrganizationModel
    {
        public string PresidentName { get; set; } = string.Empty;

        public string CashierName { get; set; } = string.Empty;

        public int UnitsCount { get; set; }

        public int OccupantsCount { get; set; }
    }
}
