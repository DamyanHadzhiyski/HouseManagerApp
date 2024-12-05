using HouseManager.Core.Models.Management;
using HouseManager.Infrastructure.Data.Models;
using HouseManager.Infrastructure.Enums;

namespace HouseManager.Core.Contracts
{
	public interface IManagementService
	{
		Task<bool> ActiveExistsAsync(int houseOrgId, ManagerPosition position);

		Task AddAsync(ActiveManagementFormModel model);

		Task EditAsync(ActiveManagementFormModel model);

		Task<int> EndTermAsync(int id);

		Task<bool> ExistsByIdAsync(int id);

		Task<Manager?> GetByIdAsync(int id);

		IQueryable<ActiveManagementViewModel?> GetActiveReadOnlyAsync(int houseOrgId);

		IQueryable<InactiveManagementViewModel?> GetAllInactiveReadOnlyAsync(int houseOrgId);

		Task<bool> IsActiveAsync(int id);
	}
}
