using HouseManager.Core.Models.HouseOrganization;

namespace HouseManager.Core.Models.Pagination
{
	public class HouseOrganizationsPageViewModel : PageViewModel
	{
        public List<HouseOrganizationViewModel>? Collection { get; set; } = [];
	} 
}
