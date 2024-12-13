using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UnitNumberParameterRemovedFromIncomeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitNumber",
                table: "Incomes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "UnitNumber",
                table: "Incomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "218ae66b-4c59-4b45-ba2d-30b976d861a7", null, "User", null },
                    { "59d321bd-443b-4822-b916-4bf7f6588061", null, "Administrator", null },
                    { "74cb5c69-a835-40d0-82d8-34bf975eb764", null, "President", null },
                    { "f7d6cf27-3a70-4285-8b89-34a24e6ce98b", null, "Cashier", null }
                });
        }
    }
}
