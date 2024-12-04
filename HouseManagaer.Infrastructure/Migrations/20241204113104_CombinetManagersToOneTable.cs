using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CombinetManagersToOneTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cashiers");

            migrationBuilder.DropTable(
                name: "Presidents");

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

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Full name"),
                    Position = table.Column<int>(type: "int", nullable: false, comment: "Position"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Start date of assignment to the position"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Due date of assignment to the position"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Phone number"),
                    HouseOrganizationId = table.Column<int>(type: "int", nullable: false, comment: "Assigned to house organization"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Current status"),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date on which the term is ended")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managers_HouseOrganizations_HouseOrganizationId",
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
                    { "4982721c-ce1b-4ff9-b998-a482beafa7ce", null, "President", null },
                    { "636bf6d7-4e69-49f5-b49f-851789dff066", null, "Administrator", null },
                    { "64230467-30b1-4fb5-b88a-a318dbbe5dfe", null, "Cashier", null },
                    { "92a0f7f6-7926-44bd-bc91-614eb3f9e008", null, "User", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Managers_HouseOrganizationId",
                table: "Managers",
                column: "HouseOrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Managers");

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

            migrationBuilder.CreateTable(
                name: "Cashiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseOrganizationId = table.Column<int>(type: "int", nullable: false, comment: "Assigned to house organization"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Due date of assignment to the position"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Current status"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Full name"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Phone number"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Start date of assignment to the position"),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date on which the term is ended")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cashiers_HouseOrganizations_HouseOrganizationId",
                        column: x => x.HouseOrganizationId,
                        principalTable: "HouseOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Presidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseOrganizationId = table.Column<int>(type: "int", nullable: false, comment: "Assigned to house organization"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Due date of assignment to the position"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Current status"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Full name"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Phone number"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Start date of assignment to the position"),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date on which the term is ended")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Presidents_HouseOrganizations_HouseOrganizationId",
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
                    { "2841a51f-f9ea-4ce9-ab45-a1e5db6a4f77", null, "Cashier", null },
                    { "9102193c-cd5a-45fb-b76c-28cfbd96db4b", null, "User", null },
                    { "be23246c-efb3-4ef9-b56d-0c7f44b33578", null, "President", null },
                    { "d09728ea-78bc-43d4-b10d-1e10aacf8048", null, "Administrator", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cashiers_HouseOrganizationId",
                table: "Cashiers",
                column: "HouseOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Presidents_HouseOrganizationId",
                table: "Presidents",
                column: "HouseOrganizationId");
        }
    }
}
