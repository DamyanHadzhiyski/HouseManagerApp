using HouseManager.Core.Models.Access;
using HouseManager.Infrastructure.Enums;

namespace HouseManager.Core.Contracts
{
    public interface IAccessService
    {
		Task AddAccessCodeToManager(int managerId, string accessCode);

		Task AddAccessCodeToOccupant(int occupantId, string accessCode);

		string GenerateAccessCode();

        Task<int> ProvideManagerAccess(AccessManagerFormModel model);

        Task<int> ProvideOccupantAccess(AccessOccupantFormModel model);
    }
}