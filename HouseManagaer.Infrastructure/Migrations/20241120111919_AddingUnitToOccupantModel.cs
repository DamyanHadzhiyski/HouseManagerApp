using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingUnitToOccupantModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Occupants_Units_UnitId",
                table: "Occupants");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Occupants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Unit to which occupant is assigned",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Occupants_Units_UnitId",
                table: "Occupants",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Occupants_Units_UnitId",
                table: "Occupants");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Occupants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Unit to which occupant is assigned");

            migrationBuilder.AddColumn<int>(
                name: "UnitId1",
                table: "Occupants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Occupants_UnitId1",
                table: "Occupants",
                column: "UnitId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Occupants_Units_UnitId",
                table: "Occupants",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Occupants_Units_UnitId1",
                table: "Occupants",
                column: "UnitId1",
                principalTable: "Units",
                principalColumn: "Id");
        }
    }
}
