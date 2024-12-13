using Microsoft.AspNetCore.Identity;

namespace HouseManager.Core.Contracts
{
	public interface IUsersService
	{
		Task AddToRole(IdentityUser user, string roleName);
		
		Task ChangeRole(IdentityUser user, string oldRoleName, string newRoleName);
	}
}
