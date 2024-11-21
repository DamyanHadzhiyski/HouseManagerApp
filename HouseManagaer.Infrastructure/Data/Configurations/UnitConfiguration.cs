using HouseManager.Infrastructure.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseManager.Infrastructure.Data.Configurations
{
	/// <summary>
	/// Configuration of the Unit entity
	/// </summary>
	public class UnitConfiguration : IEntityTypeConfiguration<Unit>
	{
		public void Configure(EntityTypeBuilder<Unit> builder)
		{
			builder
				.HasIndex(u => new { u.UnitNumber, u.HouseOrganizationId })
				.IsUnique();
		}
	}
}
