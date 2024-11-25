using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SplitManagersInTwoSeparateEnities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_HouseOrganizations_HouseOrganizationId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "RegisteredOccupants");

            migrationBuilder.CreateTable(
                name: "Cashiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier of the cashier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Cashier full name"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Start date of assignment to the cashier position"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Due date of assignment to the cashier position"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Phone number of the cashier"),
                    HouseOrganizationId = table.Column<int>(type: "int", nullable: false, comment: "Managed by the cashier house organization"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Current status of the cashier"),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date on which the term is ended")
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
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier of the president")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "President full name"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Start date of assignment to the president position"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Due date of assignment to the president position"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Phone number of the president"),
                    HouseOrganizationId = table.Column<int>(type: "int", nullable: false, comment: "Managed by the president house organization"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Current status of the president"),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date on which the term is ended")
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

            migrationBuilder.CreateIndex(
                name: "IX_Cashiers_HouseOrganizationId",
                table: "Cashiers",
                column: "HouseOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Presidents_HouseOrganizationId",
                table: "Presidents",
                column: "HouseOrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_HouseOrganizations_HouseOrganizationId",
                table: "Units",
                column: "HouseOrganizationId",
                principalTable: "HouseOrganizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_HouseOrganizations_HouseOrganizationId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "Cashiers");

            migrationBuilder.DropTable(
                name: "Presidents");

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key of the expense")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Amount of the expense"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Short description of the expense"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date on which the payment is made")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier of the Income")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Amount of the Income"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Short description of the Income"),
                    IncomeDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the Income"),
                    IncomeType = table.Column<int>(type: "int", nullable: false, comment: "Type of the Income"),
                    UnitId = table.Column<int>(type: "int", nullable: false, comment: "Unit which provided the Income")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier of the board member")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseOrganizationId = table.Column<int>(type: "int", nullable: false, comment: "Managed by the member house organization"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Due date of assignment to the board member position"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Current status of the manager"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Board member full name"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Phone number of the board member"),
                    Position = table.Column<int>(type: "int", nullable: false, comment: "Board member position"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Start date of assignment to the board member position"),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date on which the term is ended")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managers_HouseOrganizations_HouseOrganizationId",
                        column: x => x.HouseOrganizationId,
                        principalTable: "HouseOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredOccupants",
                columns: table => new
                {
                    OccupantId = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier of a occupant"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Primary identifier of a registered user")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredOccupants", x => new { x.OccupantId, x.UserId });
                    table.ForeignKey(
                        name: "FK_RegisteredOccupants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisteredOccupants_Occupants_OccupantId",
                        column: x => x.OccupantId,
                        principalTable: "Occupants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Managers_HouseOrganizationId",
                table: "Managers",
                column: "HouseOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredOccupants_UserId",
                table: "RegisteredOccupants",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_HouseOrganizations_HouseOrganizationId",
                table: "Units",
                column: "HouseOrganizationId",
                principalTable: "HouseOrganizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
