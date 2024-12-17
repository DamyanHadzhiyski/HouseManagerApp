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
		/// <summary>
		/// Method that adds new unit
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<int> AddAsync(UnitFormModel model);

		/// <summary>
		/// Method that edits a unit
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<int> EditAsync(UnitFormModel model);

		/// <summary>
		/// method that checks if a unit exists
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<bool> ExistsByIdAsync(int id);

		/// <summary>
		/// Method that return all units
		/// </summary>
		/// <returns></returns>
		Task<List<UnitViewModel>> GetAllAsync();

		/// <summary>
		/// Method that returns info for a specified unit
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Unit?> GetByIdAsync(int id);

		/// <summary>
		/// Method that returns detailed info for a specified unit
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<UnitDetailViewModel?> GetDetailsByIdAsync(int id);

		/// <summary>
		/// Method that returns all units in a house organization
		/// </summary>
		/// <param name="houseOrgId"></param>
		/// <returns></returns>
		Task<List<UnitViewModel>> GetAllFromHOAsync(int houseOrgId);

		/// <summary>
		/// Method that returns the unit Id and unit Number
		/// </summary>
		/// <param name="houseOrgId"></param>
		/// <returns></returns>
		Task<List<UnitShortViewModel>> GetUnitsShortInfoAsync(int houseOrgId);

		/// <summary>
		/// Method that returns all units occupied by a specific user
		/// </summary>
		/// <param name="houseOrgId"></param>
		/// <param name="occupantIds"></param>
		/// <returns></returns>
		Task<List<UnitViewModel>> GetAllByOccupantAsync(int houseOrgId, List<int> occupantIds);

		/// <summary>
		/// Method that returns information for a specific unit
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		IQueryable<UnitFormModel> GetByIdReadOnly(int id);
	}
}
