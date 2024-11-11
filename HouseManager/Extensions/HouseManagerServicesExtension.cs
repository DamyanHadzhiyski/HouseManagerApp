using HouseManager.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class HouseManagerServicesExtension
	{
		public static IServiceCollection AddHouseManagerDbContext(this IServiceCollection services, IConfiguration config)
		{
			string connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
			services.AddDbContext<HouseManagerDbContext>(options =>
				options.UseSqlServer(connectionString)
			);

			services.AddDatabaseDeveloperPageExceptionFilter();

			return services;
		}

		public static IServiceCollection AddHouseManagerIdentity(this IServiceCollection services, IConfiguration config)
		{
			services.AddDefaultIdentity<IdentityUser>(options =>
			{
				options.SignIn.RequireConfirmedAccount = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireDigit = false;
			})
			.AddEntityFrameworkStores<HouseManagerDbContext>();

			return services;
		}
	}
}

