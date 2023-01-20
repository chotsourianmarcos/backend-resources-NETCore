using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FKExampleFixedIV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_OwnerUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OwnerUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ExampleGitSasasa",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdWeb",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Employees");

            migrationBuilder.AddColumn<Guid>(
                name: "IdWeb",
                table: "Persons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "IdWeb",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdWeb",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "IdWeb",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "ExampleGitSasasa",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "IdWeb",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "OwnerUserId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OwnerUserId",
                table: "Products",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_OwnerUserId",
                table: "Products",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
