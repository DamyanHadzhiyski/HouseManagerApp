using HouseManager.Core.Contracts;
using HouseManager.Core.Models.BoardMember;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace HouseManager.Core.Services
{
	public class BoardMemberService(
		HouseManagerDbContext context) : IBoardMemberService
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

		public async Task EditBoardMemberAsync(BoardMemberModel model)
		{
			var editedMember = await GetBoardMemberByIdAsync(model.Id);

			editedMember.Name = model.Name;
			editedMember.Position = model.Position;
			editedMember.StartDate = model.StartDate;
			editedMember.EndDate = model.EndDate;
			editedMember.PhoneNumber = model.PhoneNumber;

			await context.SaveChangesAsync();
		}

		public IQueryable<BoardMember> GetAllReadonlyAsync()
		{
			return context.BoardMembers
								.AsNoTracking();
		}
		
		public async Task<BoardMember?> GetBoardMemberByIdAsync(int id)
		{
			return await context.BoardMembers				
							.FirstOrDefaultAsync(bm => bm.Id == id);
		}
	}
}
