using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Access;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace HouseManager.Core.Services
{
	/// <summary>
	/// Implementation of the IAccessService
	/// </summary>
	/// <param name="context"></param>
	public class AccessService(
		HouseManagerDbContext context) : IAccessService
	{
		public async Task ProvideManagerAccess(AccessManagerFormModel model)
		{
			var manager = await context.Managers
										.Where(m => m.Position == model.Position
														&& m.IsActive
															&& m.AccessCode == model.AccessCode)
										.Select(m => new
										{
											m.Id,
										})
										.FirstOrDefaultAsync();

			if (manager != null)
			{
				var userManager = new UserManager
				{
					UserId = model.UserId,
					ManagerId = manager.Id
				};

				await context.UsersManagers.AddAsync(userManager);
				await context.SaveChangesAsync();
			}
		}

		public async Task ProvideOccupantAccess(AccessOccupantFormModel model)
		{
			var occupant = await context.Occupants
										.Where(o => o.IsActive
														&& o.AccessCode == model.AccessCode)
										.Select(o => new
										{
											o.Id
										})
										.FirstOrDefaultAsync();

			if (occupant != null)
			{
				var userOccupant = new UserOccupant
				{
					UserId = model.UserId,
					OccupantId = occupant.Id
				};

				await context.UsersOccupants.AddAsync(userOccupant);
				await context.SaveChangesAsync();
			}
		}

		public async Task<string> AddAccessCodeToOccupant(int occupantId)
		{
			var occupant = await context.Occupants
											.FirstOrDefaultAsync(o => o.Id == occupantId);

			occupant.AccessCode = GenerateAccessCode();

			await context.SaveChangesAsync();

			return occupant.AccessCode;
		}

		public async Task<string> AddAccessCodeToManager(int managerId)
		{
			var manager = await context.Managers
											.FirstOrDefaultAsync(m => m.Id == managerId);

			manager.AccessCode = GenerateAccessCode();

			await context.SaveChangesAsync();

			return manager.AccessCode;
		}

		#region Private Methods
		private static string GenerateAccessCode()
		{
			string accessCode = Guid.NewGuid().ToString("N").Substring(0, 10);

			return accessCode;
		}
		#endregion
	}
}
