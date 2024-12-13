
using HouseManager.Core.Contracts;
using HouseManager.Core.Models.OccupantModel;
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
				OccupationDate = model.OccupationDate.ToDateTime(default),
				IsActive = true
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

		public IQueryable<Occupant?> GetAllReadOnlyAsync(int unitId)
		{
			return context.Occupants
							.Where(o => o.UnitId == unitId);
		}

		public IQueryable<OccupantViewModel> GetAllActiveReadOnlyAsync(int unitId)
		{
			return GetAllReadOnlyAsync(unitId)
							.Where(o => o.IsActive)
							.Select(o => new OccupantViewModel
							{
								Id = o.Id,
								FullName = o.FullName,
								PhoneNumber = o.PhoneNumber,
								IsOwner = o.IsOwner ? "Yes" : "No"
							});
		}

		public IQueryable<InactiveOccupantViewModel> GetAllInactiveReadOnlyAsync(int unitId)
		{
			return GetAllReadOnlyAsync(unitId)
							.Where(o => o.IsActive == false)
							.OrderByDescending(o => o.LeaveDate)
							.Select(o => new InactiveOccupantViewModel
							{
								Id = o.Id,
								FullName = o.FullName,
								PhoneNumber = o.PhoneNumber,
								IsOwner = o.IsOwner ? "Yes" : "No",
								LeaveDate = o.LeaveDate.ToString(AppDateFormat)
							});
		}

		public async Task<OccupantDetailViewModel?> GetDetailsByIdAsync(int id)
		{
			return await context.Occupants
								.Where(o => o.Id == id)
								.Select(o=> new OccupantDetailViewModel
								{
									Id=o.Id,
									FullName = o.FullName,
									BirthDate = o.BirthDate.ToString(AppDateFormat),
									PhoneNumber= o.PhoneNumber,
									IsOwner	= o.IsOwner ? "Yes" : "No",
									OccupationDate = o.OccupationDate.ToString(AppDateFormat),
									LeaveDate = o.IsActive ? "NA" : o.LeaveDate.ToString(AppDateFormat),
									UnitId = o.UnitId
								})
								.FirstOrDefaultAsync();
		}

		public async Task<Occupant?> GetByIdAsync(int id)
		{
			return await context.Occupants
								.FindAsync(id);
		}

		public async Task<bool> IsActiveAsync(int id)
		{
			return await context.Occupants
								.AnyAsync(p => p.Id == id && p.IsActive == true);
		}

		public async Task<int> Leave(int id)
		{
			var occupant = await GetByIdAsync(id);

			occupant.IsActive = false;
			occupant.LeaveDate = DateTime.Now;

			await context.SaveChangesAsync();

			return occupant.UnitId;
		}
	}
}
