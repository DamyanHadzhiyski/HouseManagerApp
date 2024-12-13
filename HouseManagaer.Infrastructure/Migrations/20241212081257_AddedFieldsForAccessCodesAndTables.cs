using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedFieldsForAccessCodesAndTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccessCode",
                table: "Occupants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Occupant access code");

            migrationBuilder.AddColumn<string>(
                name: "AccessCode",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Managers access code");

            migrationBuilder.CreateTable(
                name: "UsersManagers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Primary identifier of the user"),
                    ManagerId = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier of the manager")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersManagers", x => new { x.UserId, x.ManagerId });
                    table.ForeignKey(
                        name: "FK_UsersManagers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersManagers_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersOccupants",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Primary identifier of the user"),
                    OccupantId = table.Column<int>(type: "int", nullable: false, comment: "Primary identifier of the occupant")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersOccupants", x => new { x.UserId, x.OccupantId });
                    table.ForeignKey(
                        name: "FK_UsersOccupants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersOccupants_Occupants_OccupantId",
                        column: x => x.OccupantId,
                        principalTable: "Occupants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersManagers_ManagerId",
                table: "UsersManagers",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersOccupants_OccupantId",
                table: "UsersOccupants",
                column: "OccupantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersManagers");

            migrationBuilder.DropTable(
                name: "UsersOccupants");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24642d07-45fb-4ebc-9b4b-477173a178db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dc5caf8-e6d4-4f32-93f0-9ead8e6c1552");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cd6d070-055b-419b-8993-abe47e5f7223");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "825e908c-a201-4ed9-b8c9-bd88d7f4d05d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e09e4abd-c1e2-4056-a7ec-7d594c164a49");

            migrationBuilder.DropColumn(
                name: "AccessCode",
                table: "Occupants");

            migrationBuilder.DropColumn(
                name: "AccessCode",
                table: "Managers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04b77698-7eb7-4b7d-8290-39b806deab03", null, "Cashier", null },
                    { "2c2056d8-831b-4e12-bb26-cd798de87444", null, "President", null },
                    { "3427962b-3f31-4b66-a5b0-95b35f6693b9", null, "Administrator", null },
                    { "72d5fb73-8429-4574-80ad-9f8166144253", null, "Creator", null },
                    { "aecfce69-2d09-49a6-87e7-9f6c636fe875", null, "User", null }
                });
        }
    }
}
