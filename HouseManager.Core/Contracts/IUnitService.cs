using HouseManager.Core.Models.Unit;
using HouseManager.Infrastructure.Data.Models;

namespace HouseManager.Core.Contracts
{
    public interface IUnitService
    {
        //Task EditUnitAsync(UnitModel model);

        Task<List<UnitViewModel>> GetAllUnitsAsync();

        Task<Unit?> GetUnitByIdAsync(int id);
		Task<UnitDetailViewModel?> GetUnitDetailsByIdAsync(int id);

        Task<List<UnitViewModel>> GetAllUnitsFromHOAsync(int houseOrgId);
	}
}
