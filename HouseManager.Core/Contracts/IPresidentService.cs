using HouseManager.Core.Models.Manager;
using HouseManager.Infrastructure.Data.Models;

namespace HouseManager.Core.Contracts
{
    public interface IPresidentService
	{
		Task<bool> ActiveExistsAsync(int houseOrgId);

		Task AddAsync(PresidentFormModel model);

		Task EditAsync(PresidentFormModel model);

		Task<int> EndTermAsync(int id);

		Task<bool> ExistsByIdAsync(int id);

		Task<President?> GetByIdAsync(int id);

		IQueryable<PresidentViewModel?> GetActiveReadOnlyAsync(int houseOrgId);

		IQueryable<PresidentViewModel> GetAllInactiveReadOnlyAsync(int houseOrgId);

		Task<bool> IsActiveAsync(int id);
	}
}
