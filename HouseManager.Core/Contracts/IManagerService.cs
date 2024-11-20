using HouseManager.Core.Models.Manager;
using HouseManager.Infrastructure.Data.Models;

namespace HouseManager.Core.Contracts
{
	public interface IManagerService
	{
		Task AddBoardMemberAsync(ManagerViewModel model);

		Task EditBoardMemberAsync(ManagerViewModel model);

		IQueryable<Manager> GetAllReadonlyAsync();

		Task<Manager?> GetBoardMemberByIdAsync(int id);
	}
}
