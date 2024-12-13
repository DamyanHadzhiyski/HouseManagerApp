using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RecreateIncomeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51fd8700-87f3-4906-b5e9-7f079dffa8b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "713de118-cde2-49c4-9ecd-d2023f3ebabc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8350f0b1-5203-42e9-966d-02aa8eed0323");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "904e8c35-a04b-43a8-86d1-0fb82ee821d9");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "057e247d-2f41-40e1-8640-39a6fd9574e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fdbd792-67f4-4ab2-9c12-1f464c3f3c68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b90c83fd-225f-4d00-a1ed-1428d2bed7a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb6a2091-914f-4de0-8fc2-70213e699490");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "51fd8700-87f3-4906-b5e9-7f079dffa8b0", null, "President", null },
                    { "713de118-cde2-49c4-9ecd-d2023f3ebabc", null, "Administrator", null },
                    { "8350f0b1-5203-42e9-966d-02aa8eed0323", null, "User", null },
                    { "904e8c35-a04b-43a8-86d1-0fb82ee821d9", null, "Cashier", null }
                });
        }
    }
}
