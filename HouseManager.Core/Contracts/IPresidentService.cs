using HouseManager.Core.Models.Manager;

namespace HouseManager.Core.Contracts
{
    public interface IPresidentService
	{
		Task<bool> ActiveExistsAsync(int houseOrgId);

		Task AddAsync(PresidentFormModel model);

		Task EditAsync(PresidentFormModel model);

		Task EndTermAsync(int id);

		Task<bool> ExistsByIdAsync(int id);

		IQueryable<PresidentViewModel?> GetActiveReadOnlyAsync(int houseOrgId);

		IQueryable<PresidentViewModel> GetAllInactiveReadOnlyAsync(int houseOrgId);

		Task<bool> IsActiveAsync(int id);
	}
}
