using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangesInTheModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_HouseOrganizations_HouseOrganizationId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "BoardMembers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "UnitTypes");

            migrationBuilder.AlterColumn<int>(
                name: "HouseOrganizationId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Identifier of the unit type",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier of the board member")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Board member full name"),
                    Position = table.Column<int>(type: "int", nullable: false, comment: "Board member position"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Start date of assignment to the board member position"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Due date of assignment to the board member position"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Phone number of the board member"),
                    HouseOrganizationId = table.Column<int>(type: "int", nullable: false, comment: "Managed by the member house organization"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Current status of the manager"),
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

            migrationBuilder.CreateIndex(
                name: "IX_Managers_HouseOrganizationId",
                table: "Managers",
                column: "HouseOrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_HouseOrganizations_HouseOrganizationId",
                table: "Units",
                column: "HouseOrganizationId",
                principalTable: "HouseOrganizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Occupants_Units_UnitId1",
                table: "Occupants");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_HouseOrganizations_HouseOrganizationId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Occupants_UnitId1",
                table: "Occupants");

            migrationBuilder.DropColumn(
                name: "UnitId1",
                table: "Occupants");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UnitTypes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "Short description of the UnitType");

            migrationBuilder.AlterColumn<int>(
                name: "HouseOrganizationId",
                table: "Units",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identifier of the unit type");

            migrationBuilder.CreateTable(
                name: "BoardMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier of the board member")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Due date of assignment to the board member position"),
                    HouseOrganizationId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Board member full name"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Phone number of the board member"),
                    Position = table.Column<int>(type: "int", nullable: false, comment: "Board member position"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Start date of assignment to the board member position")
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

            migrationBuilder.CreateIndex(
                name: "IX_BoardMembers_HouseOrganizationId",
                table: "BoardMembers",
                column: "HouseOrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_HouseOrganizations_HouseOrganizationId",
                table: "Units",
                column: "HouseOrganizationId",
                principalTable: "HouseOrganizations",
                principalColumn: "Id");
        }
    }
}
