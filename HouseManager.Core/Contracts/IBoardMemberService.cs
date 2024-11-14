using HouseManager.Core.Models.BoardMember;
using HouseManager.Infrastructure.Data.Models;

namespace HouseManager.Core.Contracts
{
	public interface IBoardMemberService
	{
		Task AddBoardMemberAsync(BoardMemberModel model);
		IQueryable<BoardMember> GetAllReadonlyAsync();
	}
}
