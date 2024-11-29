using HouseManager.Core.Models.Manager;

namespace HouseManager.Core.Contracts
{
    public interface ICashierService
	{
		Task<bool> ActiveExistsAsync(int houseOrgId);

		Task AddAsync(CashierFormModel model);

		Task EditAsync(CashierFormModel model);

		Task EndTermAsync(int id);

		Task<bool> ExistsByIdAsync(int id);

		IQueryable<CashierViewModel?> GetActiveReadOnlyAsync(int houseOrgId);

		IQueryable<CashierViewModel> GetAllInactiveReadOnlyAsync(int houseOrgId);

		Task<bool> IsActiveAsync(int id);
	}
}
