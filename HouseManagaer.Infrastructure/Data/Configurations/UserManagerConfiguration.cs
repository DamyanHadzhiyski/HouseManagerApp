﻿using HouseManager.Infrastructure.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseManager.Infrastructure.Data.Configurations
{
	/// <summary>
	/// Configuration of the UserManager entity
	/// </summary>
	public class UserManagerConfiguration : IEntityTypeConfiguration<UserManager>
	{
		public void Configure(EntityTypeBuilder<UserManager> builder)
		{
			builder
				.HasKey(um => new {um.UserId, um.ManagerId});
		}
	}
}
