using HouseManager.Core.Models.HouseOrganization;
using HouseManager.Infrastructure.Data.Models;

namespace HouseManager.Core.Contracts
{
    public interface IHouseOrganizationService
    {
        Task AddHouseOrganizationAsync(HouseOrganizationModel house);

        Task EditHouseOrganizationAsync(HouseOrganizationModel house);

        Task<HouseOrganization?> GetHouseOrganizationById(int houseId);

		IQueryable<HouseOrganization> GetAllReadonlyAsync();
	}
}
