using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedBalancefieldToHouseOrganizationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "HouseOrganizations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Total balance");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28278e25-0f03-4f6b-ae77-1a32da8495cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2af15985-90bf-4ce9-958e-7785dfe20cc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cdfe428-2a1a-42b7-9e5a-34c02be71e2a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9508d58c-4aaa-4c93-956b-c40cdcbd5334");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "HouseOrganizations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44b7af10-f68c-495c-9934-d7c7fd6ce3e8", null, "User", null },
                    { "895c0b5c-7e0f-463d-a516-39a1d0f02718", null, "Administrator", null },
                    { "bac47003-4d82-4b63-a099-18972b660b2b", null, "Cashier", null },
                    { "db8769e1-929d-4ea7-a6be-34b3ef1d835f", null, "President", null }
                });
        }
    }
}
