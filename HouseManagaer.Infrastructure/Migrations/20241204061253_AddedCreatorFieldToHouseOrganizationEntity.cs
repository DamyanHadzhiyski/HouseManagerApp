using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCreatorFieldToHouseOrganizationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Occupants",
                type: "datetime2",
                nullable: false,
                comment: "Occupant date of birth",
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldComment: "Occupant date of birth");

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "HouseOrganizations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                comment: "Creator of the House Organization");

            migrationBuilder.CreateIndex(
                name: "IX_HouseOrganizations_CreatorId",
                table: "HouseOrganizations",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseOrganizations_AspNetUsers_CreatorId",
                table: "HouseOrganizations",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseOrganizations_AspNetUsers_CreatorId",
                table: "HouseOrganizations");

            migrationBuilder.DropIndex(
                name: "IX_HouseOrganizations_CreatorId",
                table: "HouseOrganizations");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "HouseOrganizations");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "BirthDate",
                table: "Occupants",
                type: "date",
                nullable: false,
                comment: "Occupant date of birth",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Occupant date of birth");
        }
    }
}
