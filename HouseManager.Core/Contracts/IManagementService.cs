using HouseManager.Core.Models.Manager;
using HouseManager.Infrastructure.Data.Models;

namespace HouseManager.Core.Contracts
{
	public interface IManagementService
	{
		Task<bool> ActiveExistsAsync(int houseOrgId);

		Task AddAsync(ActiveManagementFormModel model);

		Task EditAsync(ActiveManagementFormModel model);

		Task<int> EndTermAsync(int id);

		Task<bool> ExistsByIdAsync(int id);

		Task<Manager?> GetByIdAsync(int id);

		IQueryable<ActiveManagementViewModel?> GetActiveReadOnlyAsync(int houseOrgId);

		IQueryable<InactiveManagementViewModel> GetAllInactiveReadOnlyAsync(int houseOrgId);

		Task<bool> IsActiveAsync(int id);
	}
}
