using HouseManager.Core.Models.Finances;

namespace HouseManager.Core.Models.Pagination
{
	public class IncomesPageViewModel : PageViewModel
	{
        public int ExpensesCurrentPage { get; set; }
        public List<IncomeViewModel>? Collection { get; set; } = [];
	} 
}
