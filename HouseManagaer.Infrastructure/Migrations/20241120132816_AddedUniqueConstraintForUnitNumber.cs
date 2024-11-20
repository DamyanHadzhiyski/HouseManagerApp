using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUniqueConstraintForUnitNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UnitNumber",
                table: "Units",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Number of the unit",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Number of the unit");

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitNumber",
                table: "Units",
                column: "UnitNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Units_UnitNumber",
                table: "Units");

            migrationBuilder.AlterColumn<string>(
                name: "UnitNumber",
                table: "Units",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Number of the unit",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Number of the unit");
        }
    }
}
