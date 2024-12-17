using HouseManager.Core.Contracts;
using HouseManager.Infrastructure.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using static HouseManager.Infrastructure.Constants.UserClaims;

namespace HouseManager.Core.Services
{
	/// <summary>
	/// Implementation of the IUserService
	/// </summary>
	/// <param name="context"></param>

	public class UserService(
		HouseManagerDbContext context,
		UserManager<IdentityUser> userManager) : IUserService
	{
		public async Task AddToRoleAsync(string userId, string roleName)
		{
			var user = await GetByIdAsync(userId);

			var assignedRoles = await GetRolesByIdAsync(userId);

			if (!assignedRoles.Contains(roleName))
			{
				await userManager.AddToRoleAsync(user, roleName);
			}
			else
			{
				return;
			}
		}

		public async Task<IdentityUser> GetByIdAsync(string id)
		{
			return await context.Users.FindAsync(id);
		}

		public async Task<string> GetCurrentRoleAsync(string userId)
		{
			return await context.UserClaims
							.Where(uc => uc.UserId == userId
											&& uc.ClaimType == CurrentRole)
							.Select(uc => uc.ClaimValue)
							.FirstOrDefaultAsync();
		}

		public async Task<ICollection<string>> GetRolesByIdAsync(string userId)
		{
			var user = await GetByIdAsync(userId);

			return await userManager.GetRolesAsync(user);
		}

		public async Task SetCurrentRoleAsync(string userId, string role)
		{
			var userClaim = await context.UserClaims
							.Where(uc => uc.UserId == userId
											&& uc.ClaimType == CurrentRole)
							.FirstOrDefaultAsync();

			userClaim.ClaimValue = role;

			await context.SaveChangesAsync();
		}
	}
}
