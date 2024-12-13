using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04b77698-7eb7-4b7d-8290-39b806deab03", null, "Cashier", null },
                    { "2c2056d8-831b-4e12-bb26-cd798de87444", null, "President", null },
                    { "3427962b-3f31-4b66-a5b0-95b35f6693b9", null, "Administrator", null },
                    { "72d5fb73-8429-4574-80ad-9f8166144253", null, "Creator", null },
                    { "aecfce69-2d09-49a6-87e7-9f6c636fe875", null, "User", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04b77698-7eb7-4b7d-8290-39b806deab03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c2056d8-831b-4e12-bb26-cd798de87444");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3427962b-3f31-4b66-a5b0-95b35f6693b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72d5fb73-8429-4574-80ad-9f8166144253");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aecfce69-2d09-49a6-87e7-9f6c636fe875");

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
    }
}
