using HouseManager.Infrastructure.Data.Configurations;
using HouseManager.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseManager.Infrastructure.Data
{
	public class HouseManagerDbContext(DbContextOptions<HouseManagerDbContext> options) : IdentityDbContext<IdentityUser>(options)
	{
		protected override void OnModelCreating(ModelBuilder builder)
		{ 
			builder
				.ApplyConfiguration(new RegisteredOccupantConfiguration());
		}

		public DbSet<BoardMember> BoardMembers { get; set;}
		public DbSet<Expense> Expenses { get; set;}
		public DbSet<HomeOrganization> HomeOrganizations { get; set;}
		public DbSet<Income> Incomes { get; set;}
		public DbSet<Occupant> Occupants { get; set;}
		public DbSet<RegisteredOccupant> RegisteredOccupants { get; set;}
		public DbSet<Town> Towns { get; set;}
		public DbSet<Unit> Units { get; set;}
		public DbSet<UnitType> UnitTypes { get; set;}
	}
}
