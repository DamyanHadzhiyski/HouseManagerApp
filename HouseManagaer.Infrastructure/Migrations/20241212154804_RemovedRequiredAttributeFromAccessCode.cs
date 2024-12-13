using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedRequiredAttributeFromAccessCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15fd604d-63fc-4078-a15b-15f724d2363e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b64d2a8-8648-4730-86aa-0689dde68240");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f8c80e4-e48d-4682-ada8-cfa0d9c86597");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88270e49-9be5-4ad7-ad1b-1b802e263eca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98635cee-82bb-4227-9306-bdd2eb914843");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "24642d07-45fb-4ebc-9b4b-477173a178db", null, "User", null },
                    { "2dc5caf8-e6d4-4f32-93f0-9ead8e6c1552", null, "Creator", null },
                    { "6cd6d070-055b-419b-8993-abe47e5f7223", null, "Cashier", null },
                    { "825e908c-a201-4ed9-b8c9-bd88d7f4d05d", null, "President", null },
                    { "e09e4abd-c1e2-4056-a7ec-7d594c164a49", null, "Administrator", null }
                });
        }
    }
}
