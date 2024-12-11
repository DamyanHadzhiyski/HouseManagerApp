using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsActiveStatusOfOccupants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e2c67b8-eaba-4fa5-900c-fb4b6b74d8fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c9f2183-5d14-4d9f-813c-046bb2c0e8a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6288568-b9a5-44b9-b47f-b18d482cd654");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4db9481-30a5-4eb5-80fe-0ec4ce95d19e");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Occupants",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Occupation status");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "053db2f3-be07-4478-814a-7952bdf73bff", null, "User", null },
                    { "9da17556-4f15-4c85-ba89-a799bb1df881", null, "Administrator", null },
                    { "b6c7eae3-fd8e-42be-9477-af0cd482d5e3", null, "President", null },
                    { "e5bf1170-bd3d-468f-b5a9-fee36c90fe49", null, "Cashier", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "053db2f3-be07-4478-814a-7952bdf73bff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9da17556-4f15-4c85-ba89-a799bb1df881");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6c7eae3-fd8e-42be-9477-af0cd482d5e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5bf1170-bd3d-468f-b5a9-fee36c90fe49");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Occupants");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e2c67b8-eaba-4fa5-900c-fb4b6b74d8fd", null, "User", null },
                    { "3c9f2183-5d14-4d9f-813c-046bb2c0e8a2", null, "Cashier", null },
                    { "c6288568-b9a5-44b9-b47f-b18d482cd654", null, "Administrator", null },
                    { "f4db9481-30a5-4eb5-80fe-0ec4ce95d19e", null, "President", null }
                });
        }
    }
}
