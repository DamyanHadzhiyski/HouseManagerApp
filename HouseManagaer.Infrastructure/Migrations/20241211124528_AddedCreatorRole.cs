using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseManager.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class AddedCreatorRole : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
				table: "AspNetRoles",
				columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
				values: new object[,]
				{
					{ "ab3bbf84-ffc1-4c65-8949-a2b748eec3f4", null, "Creator", null }
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: "58a98ce9-4a69-452c-bb0b-5cd08ed915f0");

			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: "937ebfbc-2695-4885-92d2-6e9f9e804354");

			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: "a65d8a29-a73d-4f94-be12-106dc44f961f");

			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: "ab3bbf84-ffc1-4c65-8949-a2b748eec3f4");

			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: "b42bcf11-50fe-420d-9185-04a0f319ca5e");

			migrationBuilder.InsertData(
				table: "AspNetRoles",
				columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
				values: new object[,]
				{
					{ "0607a741-12a0-452e-8bc5-6ac54e965fec", null, "Cashier", null },
					{ "30c3906e-978a-4df9-b293-67b3c5e39741", null, "President", null },
					{ "8a65a600-12a9-48d5-a1b2-26e167b0b50f", null, "User", null },
					{ "d8917865-a98d-411a-8a3b-2d1c126b0363", null, "Administrator", null }
				});
		}
	}
}
