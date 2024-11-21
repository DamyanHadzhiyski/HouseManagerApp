using HouseManager.Infrastructure.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseManager.Infrastructure.Data.Configurations
{
	/// <summary>
	/// Configuration of the RegisteredOccupant entity
	/// </summary>
	public class RegisteredOccupantConfiguration : IEntityTypeConfiguration<RegisteredOccupant>
	{
		/// <summary>
		/// Defining primary key as combination from OccupantId and UserId
		/// </summary>
		/// <param name="builder"></param>
		public void Configure(EntityTypeBuilder<RegisteredOccupant> builder)
		{
			builder
				.HasKey(ro => new { ro.OccupantId, ro.UserId });
		}
	}
}
