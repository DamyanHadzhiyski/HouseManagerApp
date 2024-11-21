using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedTownAndUnitTypeEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseOrganizations_Towns_TownId",
                table: "HouseOrganizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_UnitTypes_UnitTypeId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.DropTable(
                name: "UnitTypes");

            migrationBuilder.DropIndex(
                name: "IX_Units_UnitTypeId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_HouseOrganizations_TownId",
                table: "HouseOrganizations");

            migrationBuilder.DropColumn(
                name: "UnitTypeId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "TownId",
                table: "HouseOrganizations");

            migrationBuilder.AddColumn<int>(
                name: "UnitType",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Type of the unit");

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "HouseOrganizations",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                comment: "Town of the House Organization");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitType",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "HouseOrganizations");

            migrationBuilder.AddColumn<int>(
                name: "UnitTypeId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Identifier of the unit type");

            migrationBuilder.AddColumn<int>(
                name: "TownId",
                table: "HouseOrganizations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Town of the House Organization");

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
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Name of the UnitType")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitTypeId",
                table: "Units",
                column: "UnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseOrganizations_TownId",
                table: "HouseOrganizations",
                column: "TownId");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseOrganizations_Towns_TownId",
                table: "HouseOrganizations",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_UnitTypes_UnitTypeId",
                table: "Units",
                column: "UnitTypeId",
                principalTable: "UnitTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
