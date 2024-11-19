using HouseManager.Infrastructure.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseManager.Infrastructure.Data.Configurations
{
	/// <summary>
	/// Configuration of the HouseOrganization entity
	/// </summary>
	public class HouseOrganizationConfiguration : IEntityTypeConfiguration<HouseOrganization>
	{
		public void Configure(EntityTypeBuilder<HouseOrganization> builder)
		{
			builder
				.HasMany(h => h.Units)
				.WithOne(u => u.HouseOrganization)
				.HasForeignKey(h => h.HouseOrganizationId);
		}
	}
}
