using HouseManager.Core.Models.Finances;

namespace HouseManager.Core.Models.Pagination
{
	public class IncomesPageViewModel : PageViewModel
	{
        public List<IncomeViewModel>? Collection { get; set; } = [];
	} 
}
