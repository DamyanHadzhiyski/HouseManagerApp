using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangesInTheManagerModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4982721c-ce1b-4ff9-b998-a482beafa7ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "636bf6d7-4e69-49f5-b49f-851789dff066");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64230467-30b1-4fb5-b88a-a318dbbe5dfe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92a0f7f6-7926-44bd-bc91-614eb3f9e008");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Managers");

            migrationBuilder.AddColumn<int>(
                name: "TermPeriod",
                table: "Managers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Due date of assignment to the position");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "TermPeriod",
                table: "Managers");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Managers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Due date of assignment to the position");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4982721c-ce1b-4ff9-b998-a482beafa7ce", null, "President", null },
                    { "636bf6d7-4e69-49f5-b49f-851789dff066", null, "Administrator", null },
                    { "64230467-30b1-4fb5-b88a-a318dbbe5dfe", null, "Cashier", null },
                    { "92a0f7f6-7926-44bd-bc91-614eb3f9e008", null, "User", null }
                });
        }
    }
}
