using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Access;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace HouseManager.Core.Services
{
	public class AccessService(
		HouseManagerDbContext context) : IAccessService
	{
		public string GenerateAccessCode()
		{
			string accessCode = Guid.NewGuid().ToString("N").Substring(0, 10);

			return accessCode;
		}

		public async Task<int> ProvideManagerAccess(AccessManagerFormModel model)
		{
			var manager = await context.Managers
										.Where(m => m.Position == model.Position
														&& m.IsActive
															&& m.AccessCode == model.AccessCode)
										.Select(m => new
										{
											m.Id
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

				return 1;
			}

			return 0;
		}

		public async Task<int> ProvideOccupantAccess(AccessOccupantFormModel model)
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

				return 1;
			}

			return 0;
		}

		public async Task AddAccessCodeToOccupant(int occupantId, string accessCode)
		{
			var occupant = await context.Occupants
											.FirstOrDefaultAsync(o => o.Id == occupantId);

			occupant.AccessCode = accessCode;

			await context.SaveChangesAsync();
		}

		public async Task AddAccessCodeToManager(int managerId, string accessCode)
		{
			var manager = await context.Managers
											.FirstOrDefaultAsync(m => m.Id == managerId);

			manager.AccessCode = accessCode;

			await context.SaveChangesAsync();
		}
	}
}
