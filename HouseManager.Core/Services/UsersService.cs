
using HouseManager.Core.Contracts;
using HouseManager.Infrastructure.Data;

using Microsoft.AspNetCore.Identity;

namespace HouseManager.Core.Services
{
	public class UsersService(
		HouseManagerDbContext context,
		UserManager<IdentityUser> userManager) : IUsersService
	{
		public async Task AddToRole(IdentityUser user, string roleName)
		{
			await userManager.AddToRoleAsync(user, roleName);
		}

		public async Task ChangeRole(IdentityUser user, string oldRoleName, string newRoleName)
		{
			await userManager.RemoveFromRoleAsync(user, oldRoleName);

			await AddToRole(user, newRoleName);
		}
	}
}
