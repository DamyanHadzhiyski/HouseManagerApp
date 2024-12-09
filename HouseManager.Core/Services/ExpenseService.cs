using HouseManager.Core.Contracts;
using HouseManager.Infrastructure.Data;

namespace HouseManager.Core.Services
{
	/// <summary>
	/// Implementation of the IExpenseService
	/// </summary>
	/// <param name="context"></param>
	public class ExpenseService(
		HouseManagerDbContext context) : IExpenseService
	{
	}
}
