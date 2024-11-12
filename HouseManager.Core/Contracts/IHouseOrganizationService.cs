using HouseManager.Core.Models;
using HouseManager.Infrastructure.Data.Models;

namespace HouseManager.Core.Contracts
{
    public interface IHouseOrganizationService
    {
        Task AddHouseOrganizationAsync(HouseOrganizationModel house);

        Task EditHouseOrganizationAsync(HouseOrganizationModel house, int houseId);

        IQueryable<HouseOrganization> GetHouseOrganizationById(int houseId);

		IQueryable<HouseOrganization> GetAllReadonlyAsync();
	}
}
