using HouseManager.Core.Models.OccupantModel;
using HouseManager.Infrastructure.Data.Models;

namespace HouseManager.Core.Contracts
{
	/// <summary>
	/// Interface that will be added into the IoC and used for 
	/// retrieval and manipulation of data from the Occupants table
	/// </summary>
	public interface IOccupantService
	{
		Task<int> AddAsync(OccupantFormModel model);

		Task EditAsync(OccupantFormModel model);

		Task<bool> ExistsByIdAsync(int id);

		IQueryable<OccupantViewModel> GetAllActiveReadOnlyAsync(int unitId);

		IQueryable<InactiveOccupantViewModel> GetAllInactiveReadOnlyAsync(int unitId);

		IQueryable<Occupant?> GetAllReadOnlyAsync(int unitId);

		Task<Occupant?> GetByIdAsync(int id);

		Task<OccupantDetailViewModel?> GetDetailsByIdAsync(int id);

		Task<bool> IsActiveAsync(int id);

		Task<int> Leave(int id);
	}
}
