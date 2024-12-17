using HouseManager.Core.Models.Managers;
using HouseManager.Infrastructure.Enums;

namespace HouseManager.Core.Contracts
{
	/// <summary>
	/// Interface that will be added into the IoC and used for 
	/// retrieval and manipulation of data from the Managers table
	/// </summary>
	public interface IManagementService
	{
		/// <summary>
		/// Method that creates a new manager
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task AddAsync(ActiveManagerFormModel model);

		/// <summary>
		/// Method that edits specified manager
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task EditAsync(ActiveManagerFormModel model);

		/// <summary>
		/// Method that ends term of specified manager and sets it to inactive
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<int> EndTermAsync(int id);

		/// <summary>
		/// Method that returns the active manager for specified house organization
		/// </summary>
		/// <param name="houseOrgId"></param>
		/// <returns></returns>
		IQueryable<ActiveManagerViewModel> GetAllActiveReadOnlyAsync(int houseOrgId);

		/// <summary>
		/// Method that returns all previous managers for specified house organization
		/// </summary>
		/// <param name="houseOrgId"></param>
		/// <returns></returns>
		IQueryable<InactiveManagerViewModel> GetAllInactiveReadOnlyAsync(int houseOrgId);

		/// <summary>
		/// Method that checks if specified manager is active
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<bool> IsActiveAsync(int id);

		/// <summary>
		/// Method that returns info for specified manager
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<ActiveManagerFormModel?> GetByIdAsync(int id);
	}
}
