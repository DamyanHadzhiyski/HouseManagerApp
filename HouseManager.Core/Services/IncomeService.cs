using HouseManager.Core.Contracts;
using HouseManager.Infrastructure.Data;

namespace HouseManager.Core.Services
{
	/// <summary>
	/// Implementation of IIncomeService
	/// </summary>
	/// <param name="context"></param>
	public class IncomeService(
		HouseManagerDbContext context) : IIncomeService
	{
	}
}
