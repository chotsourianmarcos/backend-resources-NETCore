using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SecurityUserItem2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_UserItem_OwnerUserId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserItem",
                table: "UserItem");

            migrationBuilder.RenameTable(
                name: "UserItem",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_OwnerUserId",
                table: "Products",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_OwnerUserId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserItem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserItem",
                table: "UserItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UserItem_OwnerUserId",
                table: "Products",
                column: "OwnerUserId",
                principalTable: "UserItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
