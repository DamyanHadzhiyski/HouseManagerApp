using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static HouseManager.Infrastructure.Constants.UserRoles;

namespace HouseManager.Infrastructure.Data.Configurations
{
	/// <summary>
	/// Configuration of the IdentityRole entity
	/// </summary>
	internal class IdentityRolesConfiguration : IEntityTypeConfiguration<IdentityRole>
	{
		public void Configure(EntityTypeBuilder<IdentityRole> builder)
		{
			builder
				.HasData(
					new IdentityRole(AdminRole),
					new IdentityRole(CreatorRole),
					new IdentityRole(PresidentRole),
					new IdentityRole(CashierRole),
					new IdentityRole(UserRole)
				);
		}
	}
}
