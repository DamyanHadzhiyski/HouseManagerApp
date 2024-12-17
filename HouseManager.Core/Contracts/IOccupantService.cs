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
		/// <summary>
		/// Method that adds new occupant
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<int> AddAsync(OccupantFormModel model);

		/// <summary>
		/// Method that edits occupant
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task EditAsync(OccupantFormModel model);

		/// <summary>
		/// Method that checks if occupant exists
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<bool> ExistsByIdAsync(int id);

		/// <summary>
		/// Method that return all active occupants of a unit
		/// </summary>
		/// <param name="unitId"></param>
		/// <returns></returns>
		IQueryable<OccupantViewModel> GetAllActiveReadOnlyAsync(int unitId);

		/// <summary>
		/// Method that return all inactive occupants of a unit
		/// </summary>
		/// <param name="unitId"></param>
		/// <returns></returns>
		IQueryable<InactiveOccupantViewModel> GetAllInactiveReadOnlyAsync(int unitId);

		/// <summary>
		/// Method that returns all occupants, active or not, of a unit
		/// </summary>
		/// <param name="unitId"></param>
		/// <returns></returns>
		IQueryable<Occupant?> GetAllReadOnlyAsync(int unitId);

		/// <summary>
		/// Method that returns info for specified occupant
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Occupant?> GetByIdAsync(int id);

		/// <summary>
		/// Method that returns detailed info for specified occupant
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<OccupantDetailViewModel?> GetDetailsByIdAsync(int id);

		/// <summary>
		/// Method that checks if occupant is active
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<bool> IsActiveAsync(int id);

		/// <summary>
		/// Method that sets occupant as inactive
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<int> Leave(int id);
	}
}
