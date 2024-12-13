using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "85487697-7737-4f88-be1b-e4effbddf1d4", null, "Cashier", null },
                    { "8cadc3b5-555a-43ce-81c9-bd91df45de52", null, "Administrator", null },
                    { "99f35d92-333e-4eda-908f-d0d00025c2c9", null, "Creator", null },
                    { "b30165df-7928-4423-beb0-e03181d6ca65", null, "User", null },
                    { "d15fa353-0772-4c1b-8791-964a30b7d1e4", null, "President", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85487697-7737-4f88-be1b-e4effbddf1d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cadc3b5-555a-43ce-81c9-bd91df45de52");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99f35d92-333e-4eda-908f-d0d00025c2c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b30165df-7928-4423-beb0-e03181d6ca65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d15fa353-0772-4c1b-8791-964a30b7d1e4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "58a98ce9-4a69-452c-bb0b-5cd08ed915f0", null, "Administrator", null },
                    { "937ebfbc-2695-4885-92d2-6e9f9e804354", null, "User", null },
                    { "a65d8a29-a73d-4f94-be12-106dc44f961f", null, "Cashier", null },
                    { "ab3bbf84-ffc1-4c65-8949-a2b748eec3f4", null, "Creator", null },
                    { "b42bcf11-50fe-420d-9185-04a0f319ca5e", null, "President", null }
                });
        }
    }
}
