using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SomeChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a5f676e-5252-4e26-9e5e-ce43bd9bf9ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "848cd9c9-77fc-41cc-b195-96094e8dd2be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92d1ffa6-b81c-48e3-b6a5-830ecb45da81");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae1fc968-6257-4e90-8c34-2c5d55abace4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a5f676e-5252-4e26-9e5e-ce43bd9bf9ac", null, "President", null },
                    { "848cd9c9-77fc-41cc-b195-96094e8dd2be", null, "Cashier", null },
                    { "92d1ffa6-b81c-48e3-b6a5-830ecb45da81", null, "Administrator", null },
                    { "ae1fc968-6257-4e90-8c34-2c5d55abace4", null, "User", null }
                });
        }
    }
}
