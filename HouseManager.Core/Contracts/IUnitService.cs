using HouseManager.Core.Models.Unit;
using HouseManager.Infrastructure.Data.Models;

namespace HouseManager.Core.Contracts
{
    public interface IUnitService
    {
        //Task EditUnitAsync(UnitModel model);

        Task<List<UnitModel>> GetAllUnitsAsync();

        Task<Unit?> GetUnitByIdAsync(int id);
    }
}
