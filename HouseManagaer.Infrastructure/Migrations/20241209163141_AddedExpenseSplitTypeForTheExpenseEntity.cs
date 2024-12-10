using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedExpenseSplitTypeForTheExpenseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {   migrationBuilder.AddColumn<int>(
                name: "SplitType",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "How the expense is spread");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23092eb6-d76d-4fac-86d8-fdaa501179ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24385294-0d30-4ef7-a46d-816b710bb12d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3704462e-49d4-4b56-a34f-b1564e9049e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8382b703-5091-4508-93fb-322039109c04");

            migrationBuilder.DropColumn(
                name: "SplitType",
                table: "Expenses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28278e25-0f03-4f6b-ae77-1a32da8495cd", null, "Cashier", null },
                    { "2af15985-90bf-4ce9-958e-7785dfe20cc2", null, "User", null },
                    { "4cdfe428-2a1a-42b7-9e5a-34c02be71e2a", null, "Administrator", null },
                    { "9508d58c-4aaa-4c93-956b-c40cdcbd5334", null, "President", null }
                });
        }
    }
}
