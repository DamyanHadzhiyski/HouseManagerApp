using HouseManager.Infrastructure.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseManager.Infrastructure.Data.Configurations
{
	/// <summary>
	/// Configuration of the UserOccupant entity
	/// </summary>
	public class UserOccupantConfiguration : IEntityTypeConfiguration<UserOccupant>
	{
		public void Configure(EntityTypeBuilder<UserOccupant> builder)
		{
			builder
				.HasKey(um => new { um.UserId, um.OccupantId });
		}
	}
}
