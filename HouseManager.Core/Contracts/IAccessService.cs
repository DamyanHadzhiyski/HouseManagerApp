using HouseManager.Core.Models.Access;

namespace HouseManager.Core.Contracts
{
	public interface IAccessService
    {
		Task<string> AddAccessCodeToManager(int managerId);

		Task<string> AddAccessCodeToOccupant(int occupantId);

        Task ProvideManagerAccess(AccessManagerFormModel model);

        Task ProvideOccupantAccess(AccessOccupantFormModel model);
    }
}