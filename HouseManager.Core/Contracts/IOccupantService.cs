using HouseManager.Core.Models.OccupantModels;

namespace HouseManager.Core.Contracts
{
    public interface IOccupantService
	{
		Task<int> AddAsync(OccupantFormModel model);

		Task EditAsync(OccupantFormModel model);

		Task<bool> ExistsByIdAsync(int id);

		IQueryable<OccupantViewModel> GetAllReadOnlyAsync(int unitId);

		Task<OccupantFormModel?> GetByIdAsync(int id);

		Task<OccupantDetailViewModel?> GetDetailsByIdAsync(int id);
	}
}
