using HouseManager.Core.Contracts;
using HouseManager.Core.Models.Manager;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace HouseManager.Core.Services
{
	public class ManagerService(
		HouseManagerDbContext context) : IManagerService
	{
		public async Task AddBoardMemberAsync(ManagerViewModel model)
		{
			var newMember = new Manager
			{
				Name = model.Name,
				Position = model.Position,
				StartDate = model.StartDate,
				EndDate = model.EndDate,
				PhoneNumber = model.PhoneNumber,
				HouseOrganizationId = model.HouseOrganizationId,
				IsActive = model.IsActive
			};

			await context.Managers.AddAsync(newMember);
			await context.SaveChangesAsync();
		}

		public async Task EditBoardMemberAsync(ManagerViewModel model)
		{
			var editedMember = await GetBoardMemberByIdAsync(model.Id);

			editedMember.Name = model.Name;
			editedMember.Position = model.Position;
			editedMember.StartDate = model.StartDate;
			editedMember.EndDate = model.EndDate;
			editedMember.PhoneNumber = model.PhoneNumber;

			await context.SaveChangesAsync();
		}

		public IQueryable<Manager> GetAllReadonlyAsync()
		{
			return context.Managers
								.AsNoTracking();
		}
		
		public async Task<Manager?> GetBoardMemberByIdAsync(int id)
		{
			return await context.Managers
							.FirstOrDefaultAsync(bm => bm.Id == id);
		}
	}
}
