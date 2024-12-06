
using HouseManager.Core.Contracts;
using HouseManager.Core.Models.OccupantModels;
using HouseManager.Infrastructure.Data;
using HouseManager.Infrastructure.Data.Models;

using Microsoft.EntityFrameworkCore;

using static HouseManager.Core.Constants.DataConstants;

namespace HouseManager.Core.Services
{
	public class OccupantService(
		HouseManagerDbContext context) : IOccupantService
	{
		public async Task<int> AddAsync(OccupantFormModel model)
		{
			var occupant = new Occupant
			{
				FullName = model.FullName,
				IsOwner = model.IsOwner,
				BirthDate = model.BirthDate.ToDateTime(default),
				PhoneNumber = model.PhoneNumber,
				UnitId = model.UnitId,
				OccupationDate = model.OccupationDate.ToDateTime(default)
			};

			await context.Occupants.AddAsync(occupant);
			await context.SaveChangesAsync();

			return await GetLastSavedId(model.UnitId);
		}

		private async Task<int> GetLastSavedId(int unitId)
		{
			return await context.Occupants
								.Where(o => o.UnitId == unitId)
								.OrderByDescending(o => o.Id)
								.Select(o => o.Id)
								.FirstOrDefaultAsync();
		}

		public async Task EditAsync(OccupantFormModel model)
		{
			var occupant = await context.Occupants.FindAsync(model.Id);

			occupant.FullName = model.FullName;
			occupant.PhoneNumber = model.PhoneNumber;
			occupant.BirthDate = model.BirthDate.ToDateTime(default);
			occupant.OccupationDate = model.OccupationDate.ToDateTime(default);
			occupant.IsOwner = model.IsOwner;

			await context.SaveChangesAsync();
		}

		public Task<bool> ExistsByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<OccupantViewModel> GetAllReadOnlyAsync(int unitId)
		{
			return context.Occupants
							.Where(o => o.UnitId == unitId)
							.Select(o => new OccupantViewModel
							{
								Id = o.Id,
								FullName = o.FullName,
								IsOwner = o.IsOwner ? "Yes" : "No",
								PhoneNumber = o.PhoneNumber,
								UnitId = unitId
							});
		}

		public async Task<OccupantDetailViewModel?> GetDetailsByIdAsync(int id)
		{
			return await context.Occupants
								.Where(o => o.Id == id)
								.Select(o=> new OccupantDetailViewModel
								{
									FullName = o.FullName,
									BirthDate = o.BirthDate.ToString(DateFormat),
									PhoneNumber= o.PhoneNumber,
									IsOwner	= o.IsOwner ? "Yes" : "No",
									OccupationDate = o.OccupationDate.ToString(DateFormat),
									LeaveDate = o.LeaveDate.ToString(DateFormat)
								})
								.FirstOrDefaultAsync();
		}

		public async Task<OccupantFormModel?> GetByIdAsync(int id)
		{
			return await context.Occupants
								.Where(o => o.Id == id)
								.Select(o => new OccupantFormModel
								{
									FullName = o.FullName,
									BirthDate = DateOnly.FromDateTime(o.BirthDate),
									PhoneNumber = o.PhoneNumber,
									IsOwner = o.IsOwner,
									OccupationDate = DateOnly.FromDateTime(o.OccupationDate),
									UnitId = o.UnitId
								})
								.FirstOrDefaultAsync();
		}
	}
}
