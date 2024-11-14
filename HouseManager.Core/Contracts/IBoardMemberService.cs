using HouseManager.Core.Models.BoardMember;
using HouseManager.Infrastructure.Data.Models;

namespace HouseManager.Core.Contracts
{
	public interface IBoardMemberService
	{
		Task AddBoardMemberAsync(BoardMemberModel model);

		Task EditBoardMemberAsync(BoardMemberModel model);

		IQueryable<BoardMember> GetAllReadonlyAsync();

		Task<BoardMember?> GetBoardMemberByIdAsync(int id);
	}
}
