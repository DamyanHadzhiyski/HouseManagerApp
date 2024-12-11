using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Finances;
using HouseManager.Core.Models.Pagination;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using static HouseManager.Core.Constants.DataConstants;
namespace HouseManager.Controllers
{
	public class FinancesController(
		IUnitService unitService,
		IFinanceService financeService) : BaseController
	{
		#region Index
		public async Task<IActionResult> Index(int houseOrgId, int incomesCurrentPage = 1, int expensesCurrentPage = 1)
		{
			var incomes = await financeService.GetHouseOrgIncomesByIdAsync(houseOrgId)
													.ToListAsync();

			var expenses = await financeService.GetHouseOrgExpensesByIdAsync(houseOrgId)
													.ToListAsync();

			var balance = await financeService.GetHouseOrgBalanceByIdAsync(houseOrgId);

			var model = new FinancesViewModel();

			model.CurrentBalance = balance;
			model.Incomes = new IncomesPageViewModel
			{
				CurrentPage = incomesCurrentPage,
				ElementsPerPage = ElementsOnPage,
				TotalElements = incomes.Count,
				Collection = incomes
								.Skip((incomesCurrentPage - 1) * ElementsOnPage)
								.Take(ElementsOnPage)
								.ToList()
			};

			model.Expenses = new ExpensesPageViewModel
			{
				CurrentPage = expensesCurrentPage,
				ElementsPerPage = ElementsOnPage,
				TotalElements = expenses.Count,
				Collection = expenses
								.Skip((expensesCurrentPage - 1) * ElementsOnPage)
								.Take(ElementsOnPage)
								.ToList()
			};

			ViewBag.ViewName = "Finances";

			return View(model);
		}
		#endregion

		#region New Income
		[HttpGet]
		public async Task<IActionResult> NewIncome(int houseOrgId)
		{
			var model = new IncomeFormModel();

			model.HouseOrganizationId = houseOrgId;

			var unitsList = await unitService.GetUnitsShortInfoAsync(houseOrgId);

			List<SelectListItem> unitSelectList = unitsList
								.Select(u => new SelectListItem
								{
									Text = u.Number,
									Value = u.Id.ToString()
								})
								.ToList();

			unitSelectList.Insert(0, new SelectListItem("NA", "0"));

			ViewBag.Units = unitSelectList;

			ViewBag.ViewName = "New Income";

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> NewIncome(IncomeFormModel model)
		{
			await financeService.AddIncomeAsync(model);

			if(model.UnitId != 0)
			{
				await financeService.CalculateUnitBalanceAsync(model.UnitId, (model.Amount * -1));
			}

			await financeService.CalculateHouseOrgBalanceAsync(model.HouseOrganizationId, model.Amount);

			return RedirectToAction("Index", "Finances", new {houseOrgId = model.HouseOrganizationId });
		}
		#endregion

		#region New Expense
		[HttpGet]
		public IActionResult NewExpense(int houseOrgId)
		{
			var model = new ExpenseFormModel();

			model.HouseOrganizationId = houseOrgId;

			ViewBag.ViewName = "New Expense";

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> NewExpense(ExpenseFormModel model)
		{
			await financeService.AddExpenseAsync(model);

			await financeService.CalculateHouseOrgBalanceAsync(model.HouseOrganizationId, (model.Amount * -1));

			return RedirectToAction("Index", "Finances", new { houseOrgId = model.HouseOrganizationId });
		}
		#endregion
	}
}
