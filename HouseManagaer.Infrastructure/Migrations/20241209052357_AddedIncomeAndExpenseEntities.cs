using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIncomeAndExpenseEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key of the expense")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Short description of the expense"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Amount of the expense"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date on which the payment is made"),
                    HouseOrganizationId = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier of the House Organization")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_HouseOrganizations_HouseOrganizationId",
                        column: x => x.HouseOrganizationId,
                        principalTable: "HouseOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier of the Income")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncomeType = table.Column<int>(type: "int", nullable: false, comment: "Type of the Income"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Amount of the Income"),
                    IncomeDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the Income"),
                    UnitId = table.Column<int>(type: "int", nullable: false, comment: "Unit which provided the Income"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Short description of the Income"),
                    HouseOrganizationId = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier of the House Organization")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_HouseOrganizations_HouseOrganizationId",
                        column: x => x.HouseOrganizationId,
                        principalTable: "HouseOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_HouseOrganizationId",
                table: "Expenses",
                column: "HouseOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_HouseOrganizationId",
                table: "Incomes",
                column: "HouseOrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44b7af10-f68c-495c-9934-d7c7fd6ce3e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "895c0b5c-7e0f-463d-a516-39a1d0f02718");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bac47003-4d82-4b63-a099-18972b660b2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db8769e1-929d-4ea7-a6be-34b3ef1d835f");

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
    }
}
