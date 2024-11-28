using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SplitManagersInTwoSeparateEnitiesBasedOnCommonModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Presidents",
                type: "datetime2",
                nullable: false,
                comment: "Start date of assignment to the position",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Start date of assignment to the president position");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Presidents",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Phone number",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Phone number of the president");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Presidents",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Full name",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "President full name");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Presidents",
                type: "bit",
                nullable: false,
                comment: "Current status",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Current status of the president");

            migrationBuilder.AlterColumn<int>(
                name: "HouseOrganizationId",
                table: "Presidents",
                type: "int",
                nullable: false,
                comment: "Assigned to house organization",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Managed by the president house organization");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Presidents",
                type: "datetime2",
                nullable: false,
                comment: "Due date of assignment to the position",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Due date of assignment to the president position");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Presidents",
                type: "int",
                nullable: false,
                comment: "Primary identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Primary identifier of the president")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Cashiers",
                type: "datetime2",
                nullable: false,
                comment: "Start date of assignment to the position",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Start date of assignment to the cashier position");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Cashiers",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Phone number",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Phone number of the cashier");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cashiers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Full name",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Cashier full name");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Cashiers",
                type: "bit",
                nullable: false,
                comment: "Current status",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Current status of the cashier");

            migrationBuilder.AlterColumn<int>(
                name: "HouseOrganizationId",
                table: "Cashiers",
                type: "int",
                nullable: false,
                comment: "Assigned to house organization",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Managed by the cashier house organization");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Cashiers",
                type: "datetime2",
                nullable: false,
                comment: "Due date of assignment to the position",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Due date of assignment to the cashier position");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Cashiers",
                type: "int",
                nullable: false,
                comment: "Primary identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Primary identifier of the cashier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Presidents",
                type: "datetime2",
                nullable: false,
                comment: "Start date of assignment to the president position",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Start date of assignment to the position");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Presidents",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Phone number of the president",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Phone number");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Presidents",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "President full name",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Full name");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Presidents",
                type: "bit",
                nullable: false,
                comment: "Current status of the president",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Current status");

            migrationBuilder.AlterColumn<int>(
                name: "HouseOrganizationId",
                table: "Presidents",
                type: "int",
                nullable: false,
                comment: "Managed by the president house organization",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Assigned to house organization");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Presidents",
                type: "datetime2",
                nullable: false,
                comment: "Due date of assignment to the president position",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Due date of assignment to the position");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Presidents",
                type: "int",
                nullable: false,
                comment: "Primary identifier of the president",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Primary identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Cashiers",
                type: "datetime2",
                nullable: false,
                comment: "Start date of assignment to the cashier position",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Start date of assignment to the position");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Cashiers",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Phone number of the cashier",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Phone number");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cashiers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Cashier full name",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Full name");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Cashiers",
                type: "bit",
                nullable: false,
                comment: "Current status of the cashier",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Current status");

            migrationBuilder.AlterColumn<int>(
                name: "HouseOrganizationId",
                table: "Cashiers",
                type: "int",
                nullable: false,
                comment: "Managed by the cashier house organization",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Assigned to house organization");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Cashiers",
                type: "datetime2",
                nullable: false,
                comment: "Due date of assignment to the cashier position",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Due date of assignment to the position");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Cashiers",
                type: "int",
                nullable: false,
                comment: "Primary identifier of the cashier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Primary identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
