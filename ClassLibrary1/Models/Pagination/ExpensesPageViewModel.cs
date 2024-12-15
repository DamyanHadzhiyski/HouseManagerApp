using HouseManager.Core.Models.Finances;

namespace HouseManager.Core.Models.Pagination
{
	public class ExpensesPageViewModel : PageViewModel
	{
        public List<ExpenseViewModel> Collection { get; set; } = [];
	} 
}
