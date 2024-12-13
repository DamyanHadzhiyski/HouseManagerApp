using HouseManager.Core.Models.Managers;
using HouseManager.Infrastructure.Enums;

namespace HouseManager.Core.Models.Pagination
{
	public class InactivePresidentsPageViewModel : PageViewModel
	{
        public ManagerPosition Position { get; set; } = ManagerPosition.President;

		public List<InactiveManagerViewModel> Collection { get; set; } = [];
    }
}
