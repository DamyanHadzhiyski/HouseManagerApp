using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2841a51f-f9ea-4ce9-ab45-a1e5db6a4f77", null, "Cashier", null },
                    { "9102193c-cd5a-45fb-b76c-28cfbd96db4b", null, "User", null },
                    { "be23246c-efb3-4ef9-b56d-0c7f44b33578", null, "President", null },
                    { "d09728ea-78bc-43d4-b10d-1e10aacf8048", null, "Administrator", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2841a51f-f9ea-4ce9-ab45-a1e5db6a4f77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9102193c-cd5a-45fb-b76c-28cfbd96db4b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be23246c-efb3-4ef9-b56d-0c7f44b33578");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d09728ea-78bc-43d4-b10d-1e10aacf8048");
        }
    }
}
