using HouseManager.Core.Models.HouseOrganization;
using HouseManager.Infrastructure.Data.Models;

namespace HouseManager.Core.Contracts
{
	public interface IHouseOrganizationService
    {
        Task AddHouseOrganizationAsync(HouseOrganizationFormModel houseOrg);

        Task EditHouseOrganizationAsync(HouseOrganizationFormModel houseOrg);

        IQueryable<HouseOrganization> GetAllReadOnly();

        IQueryable<HouseOrganization> GetByIdReadOnly(int houseOrgId);

        Task<bool> ExistByIdAsync(int houseOrgId);

		Task<HouseOrganization?> GetHouseOrganizationById(int houseOrgId);
	}
}
