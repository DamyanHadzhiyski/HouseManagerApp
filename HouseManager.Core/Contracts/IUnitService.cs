using HouseManager.Core.Models.Unit;
using HouseManager.Infrastructure.Data.Models;

namespace HouseManager.Core.Contracts
{
	/// <summary>
	/// Interface that will be added into the IoC and used for 
	/// retrieval and manipulation of data from the Units table
	/// </summary>
	public interface IUnitService
    {
		Task<int> AddAsync(UnitFormModel model);

		Task<int> EditAsync(UnitFormModel model);

		Task<bool> ExistsByIdAsync(int id);

		Task<List<UnitViewModel>> GetAllAsync();

        Task<Unit?> GetByIdAsync(int id);

		Task<UnitDetailViewModel?> GetDetailsByIdAsync(int id);

        Task<List<UnitViewModel>> GetAllFromHOAsync(int houseOrgId);

		Task<List<UnitShortViewModel>> GetUnitsShortInfoAsync(int houseOrgId);

		Task<List<UnitViewModel>> GetAllByOccupantAsync(int houseOrgId, List<int> occupantIds);

		IQueryable<UnitFormModel> GetByIdReadOnly(int id);
	}
}
