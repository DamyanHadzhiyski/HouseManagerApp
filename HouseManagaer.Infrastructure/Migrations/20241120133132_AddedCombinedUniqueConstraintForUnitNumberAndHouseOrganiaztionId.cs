using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCombinedUniqueConstraintForUnitNumberAndHouseOrganiaztionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Units_UnitNumber",
                table: "Units");

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitNumber_HouseOrganizationId",
                table: "Units",
                columns: new[] { "UnitNumber", "HouseOrganizationId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Units_UnitNumber_HouseOrganizationId",
                table: "Units");

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitNumber",
                table: "Units",
                column: "UnitNumber",
                unique: true);
        }
    }
}
