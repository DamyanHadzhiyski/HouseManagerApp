using HouseManager.Core.Models.Finances;

namespace HouseManager.Core.Models.Pagination
{
	public class ExpensesPageViewModel : PageViewModel
	{
        public int IncomesCurrentPager { get; set; }
        public List<ExpenseViewModel>? Collection { get; set; } = [];
	} 
}
