using HouseManager.Core.Models.Unit;

namespace HouseManager.Core.Models.Pagination
{
	public class UnitsPageViewModel : PageViewModel
	{
        public List<UnitViewModel>? Collection { get; set; } = [];
	} 
}
