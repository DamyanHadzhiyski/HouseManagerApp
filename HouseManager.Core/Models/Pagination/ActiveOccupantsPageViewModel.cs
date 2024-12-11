using HouseManager.Core.Models.OccupantModel;

namespace HouseManager.Core.Models.Pagination
{
	public class ActiveOccupantsPageViewModel : PageViewModel
	{
        public List<OccupantViewModel> Collection { get; set; } = [];
	} 
}
