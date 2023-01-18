using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SecurityUserItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestMigration",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TestMigrationWithAPI",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "OwnerUserId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdWeb = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserItem", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_OwnerUserId",
                table: "Products",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UserItem_OwnerUserId",
                table: "Products",
                column: "OwnerUserId",
                principalTable: "UserItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_UserItem_OwnerUserId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "UserItem");

            migrationBuilder.DropIndex(
                name: "IX_Products_OwnerUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "TestMigration",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TestMigrationWithAPI",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
