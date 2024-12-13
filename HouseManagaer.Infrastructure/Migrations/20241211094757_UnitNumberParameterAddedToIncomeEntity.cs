using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UnitNumberParameterAddedToIncomeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UnitNumber",
                table: "Incomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0607a741-12a0-452e-8bc5-6ac54e965fec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30c3906e-978a-4df9-b293-67b3c5e39741");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a65a600-12a9-48d5-a1b2-26e167b0b50f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8917865-a98d-411a-8a3b-2d1c126b0363");

            migrationBuilder.DropColumn(
                name: "UnitNumber",
                table: "Incomes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "057e247d-2f41-40e1-8640-39a6fd9574e9", null, "Administrator", null },
                    { "7fdbd792-67f4-4ab2-9c12-1f464c3f3c68", null, "President", null },
                    { "b90c83fd-225f-4d00-a1ed-1428d2bed7a1", null, "Cashier", null },
                    { "fb6a2091-914f-4de0-8fc2-70213e699490", null, "User", null }
                });
        }
    }
}
