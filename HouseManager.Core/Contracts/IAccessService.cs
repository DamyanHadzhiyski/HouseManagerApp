using HouseManager.Core.Models.Access;

namespace HouseManager.Core.Contracts
{
	/// <summary>
	/// Interface that will be added into the IoC and used for 
	/// providing different access to the app users
	/// </summary>
	public interface IAccessService
    {
        /// <summary>
        /// Method that adds access code to specified manager
        /// </summary>
        /// <param name="managerId"></param>
        /// <returns></returns>
		Task<string> AddAccessCodeToManager(int managerId);

		/// <summary>
		/// Method that adds access code to specified occupant
		/// </summary>
		/// <param name="occupantId"></param>
		/// <returns></returns>
		Task<string> AddAccessCodeToOccupant(int occupantId);

        /// <summary>
        /// Method that gives manager access to specific user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task ProvideManagerAccess(AccessManagerFormModel model);

		/// <summary>
		/// Method that gives occupant access to specific user
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task ProvideOccupantAccess(AccessOccupantFormModel model);
    }
}