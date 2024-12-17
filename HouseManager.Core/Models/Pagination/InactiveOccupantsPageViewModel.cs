using HouseManager.Core.Models.OccupantModel;

namespace HouseManager.Core.Models.Pagination
{
	public class InactiveOccupantsPageViewModel : PageViewModel
	{
        public List<InactiveOccupantViewModel>? Collection { get; set; } = [];
	} 
}
