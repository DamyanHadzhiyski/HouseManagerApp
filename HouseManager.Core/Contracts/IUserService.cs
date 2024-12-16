using Microsoft.AspNetCore.Identity;

namespace HouseManager.Core.Contracts
{
	public interface IUserService
	{
		Task AddToRoleAsync(string userId, string roleName);

		Task<IdentityUser> GetByIdAsync(string id);

		Task<ICollection<string>> GetRolesByIdAsync(string userId);

		Task<string> GetCurrentRoleAsync(string userId);

		Task SetCurrentRoleAsync(string userId, string role);
	}
}
