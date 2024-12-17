using Microsoft.AspNetCore.Identity;

namespace HouseManager.Core.Contracts
{
	/// <summary>
	/// Interface that will be added into the IoC and used for 
	/// retrieval and manipulation of data for the Applications users
	/// </summary>
	public interface IUserService
	{
		/// <summary>
		/// Method that adds user to a role
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="roleName"></param>
		/// <returns></returns>
		Task AddToRoleAsync(string userId, string roleName);

		/// <summary>
		/// Method that returns user info
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		Task<IdentityUser> GetByIdAsync(string userId);

		/// <summary>
		/// Method that returns all roles of a user
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		Task<ICollection<string>> GetRolesByIdAsync(string userId);

		/// <summary>
		/// Method that returns the current role of the user
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		Task<string> GetCurrentRoleAsync(string userId);

		/// <summary>
		/// Method that sets the current role of the user
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="role"></param>
		/// <returns></returns>
		Task SetCurrentRoleAsync(string userId, string role);
	}
}
