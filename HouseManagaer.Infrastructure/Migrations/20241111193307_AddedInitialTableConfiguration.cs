using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedInitialTableConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key of the expense")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Short description of the expense"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Amount of the expense"),
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
                    IncomeType = table.Column<int>(type: "int", nullable: false, comment: "Type of the Income"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Amount of the Income"),
                    IncomeDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the Income"),
                    UnitId = table.Column<int>(type: "int", nullable: false, comment: "Unit which provided the Income"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Short description of the Income")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier of the Town")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Name of the Town")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier of the UnitType")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Name of the UnitType"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Short description of the UnitType")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HouseOrganizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier of the House Organization")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Name of the House Organization"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Address of the House Organization"),
                    TownId = table.Column<int>(type: "int", nullable: false, comment: "Town of the House Organization")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseOrganizations_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier of the board member")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Board member fullname"),
                    Position = table.Column<int>(type: "int", nullable: false, comment: "Board member position"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Start date of assignment to the board member position"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Due date of assignment to the board member position"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Phone number of the board member"),
                    HouseOrganizationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardMembers_HouseOrganizations_HouseOrganizationId",
                        column: x => x.HouseOrganizationId,
                        principalTable: "HouseOrganizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier of the unit")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitTypeId = table.Column<int>(type: "int", nullable: false, comment: "Identifier of the unit type"),
                    Floor = table.Column<int>(type: "int", nullable: false, comment: "Floor on which the unit is located"),
                    UnitNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Number of the unit"),
                    TotalArea = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Total area of the unit"),
                    CommonParts = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Common parts adjacent to the unit"),
                    PetsCount = table.Column<int>(type: "int", nullable: false, comment: "Number of pets in the unit"),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The credit/debit of the unit"),
                    HouseOrganizationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_HouseOrganizations_HouseOrganizationId",
                        column: x => x.HouseOrganizationId,
                        principalTable: "HouseOrganizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Units_UnitTypes_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalTable: "UnitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Occupants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier of the occupant")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Occupant full name"),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "Occupant date of birth"),
                    IsOwner = table.Column<bool>(type: "bit", nullable: false, comment: "Flag if the occupant is owner of the unit"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Phone number of the occupant"),
                    UnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Occupants_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RegisteredOccupants",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Primary identifier of a registered user"),
                    OccupantId = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier of a occupant")
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
                name: "IX_BoardMembers_HouseOrganizationId",
                table: "BoardMembers",
                column: "HouseOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseOrganizations_TownId",
                table: "HouseOrganizations",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_Occupants_UnitId",
                table: "Occupants",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredOccupants_UserId",
                table: "RegisteredOccupants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_HouseOrganizationId",
                table: "Units",
                column: "HouseOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitTypeId",
                table: "Units",
                column: "UnitTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardMembers");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "RegisteredOccupants");

            migrationBuilder.DropTable(
                name: "Occupants");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "HouseOrganizations");

            migrationBuilder.DropTable(
                name: "UnitTypes");

            migrationBuilder.DropTable(
                name: "Towns");
        }
    }
}
