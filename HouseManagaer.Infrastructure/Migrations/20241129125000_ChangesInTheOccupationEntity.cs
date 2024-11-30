using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangesInTheOccupationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TerminationDate",
                table: "Presidents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date on which the term is ended",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Date on which the term is ended");

            migrationBuilder.AddColumn<DateTime>(
                name: "LeaveDate",
                table: "Occupants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "End date of the occupation");

            migrationBuilder.AddColumn<DateTime>(
                name: "OccupationDate",
                table: "Occupants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Start date of the occupation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TerminationDate",
                table: "Cashiers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date on which the term is ended",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Date on which the term is ended");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeaveDate",
                table: "Occupants");

            migrationBuilder.DropColumn(
                name: "OccupationDate",
                table: "Occupants");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TerminationDate",
                table: "Presidents",
                type: "datetime2",
                nullable: true,
                comment: "Date on which the term is ended",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date on which the term is ended");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TerminationDate",
                table: "Cashiers",
                type: "datetime2",
                nullable: true,
                comment: "Date on which the term is ended",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date on which the term is ended");
        }
    }
}
