using HouseManager.Core.Contracts;
using HouseManager.Core.Models.BoardMember;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace HouseManager.Core.Services
{
	public class BoardMemberService(
		HouseManagerDbContext context,
		IHouseOrganizationService houseOrganizationService) : IBoardMemberService
	{
		public async Task AddBoardMemberAsync(BoardMemberModel model)
		{
			var newMember = new BoardMember
			{
				Name = model.Name,
				Position = model.Position,
				StartDate = model.StartDate,
				EndDate = model.EndDate,
				PhoneNumber = model.PhoneNumber
			};

			await context.BoardMembers.AddAsync(newMember);
			await context.SaveChangesAsync();
		}

		public IQueryable<BoardMember> GetAllReadonlyAsync()
		{
			return context.BoardMembers
								.AsNoTracking();
		}
	}
}
