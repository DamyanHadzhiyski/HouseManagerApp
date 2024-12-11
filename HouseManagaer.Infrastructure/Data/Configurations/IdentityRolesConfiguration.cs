using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static HouseManager.Infrastructure.Constants.UserRoles;

namespace HouseManager.Infrastructure.Data.Configurations
{
	internal class IdentityRolesConfiguration : IEntityTypeConfiguration<IdentityRole>
	{
		public void Configure(EntityTypeBuilder<IdentityRole> builder)
		{
			builder
				.HasData(
					new IdentityRole(AdminRoleName),
					new IdentityRole(PresidentRoleName),
					new IdentityRole(CashierRoleName),
					new IdentityRole(UserRoleName)
				);
		}
	}
}
