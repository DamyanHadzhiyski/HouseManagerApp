using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedPetsCountFromUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetsCount",
                table: "Units");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_UnitId",
                table: "Incomes",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_Units_UnitId",
                table: "Incomes",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_Units_UnitId",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Incomes_UnitId",
                table: "Incomes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "197dd126-b897-4fe4-b3d2-87167478513e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "614a391e-56ae-45c1-93ce-f9f1107b9d77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "922709d0-1897-4329-a22e-f7c0ec567655");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e99a4168-541e-43ad-974e-235c14c9f42a");

            migrationBuilder.AddColumn<int>(
                name: "PetsCount",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Number of pets in the unit");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23092eb6-d76d-4fac-86d8-fdaa501179ba", null, "President", null },
                    { "24385294-0d30-4ef7-a46d-816b710bb12d", null, "User", null },
                    { "3704462e-49d4-4b56-a34f-b1564e9049e4", null, "Cashier", null },
                    { "8382b703-5091-4508-93fb-322039109c04", null, "Administrator", null }
                });
        }
    }
}
