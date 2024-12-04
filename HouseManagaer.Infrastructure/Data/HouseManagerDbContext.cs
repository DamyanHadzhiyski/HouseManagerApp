using HouseManager.Infrastructure.Constants;
using HouseManager.Infrastructure.Data.Configurations;
using HouseManager.Infrastructure.Data.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseManager.Infrastructure.Data
{
    public class HouseManagerDbContext : IdentityDbContext<IdentityUser>
	{
		public HouseManagerDbContext(DbContextOptions<HouseManagerDbContext> options) 
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			//builder
			//	.ApplyConfiguration(new RegisteredOccupantConfiguration());

			builder
				.ApplyConfiguration(new HouseOrganizationConfiguration());

			builder
				.ApplyConfiguration(new UnitConfiguration());

			builder
				.ApplyConfiguration(new IdentityRolesConfiguration());
		}

		public DbSet<President> Presidents { get; set; }
		public DbSet<Cashier> Cashiers { get; set; }
		//public DbSet<Expense> Expenses { get; set; }
		public DbSet<HouseOrganization> HouseOrganizations { get; set; }
		//public DbSet<Income> Incomes { get; set; }
		public DbSet<Occupant> Occupants { get; set; }
		//public DbSet<RegisteredOccupant> RegisteredOccupants { get; set; }
		public DbSet<Unit> Units { get; set; }
	}
}
