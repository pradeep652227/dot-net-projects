using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingApplication.Migrations
{
    /// <inheritdoc />
    public partial class _3newrelationsaddfromuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_AccountType",
                table: "User",
                column: "AccountType");

            migrationBuilder.CreateIndex(
                name: "IX_User_BankId",
                table: "User",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_AccountType_AccountType",
                table: "User",
                column: "AccountType",
                principalTable: "AccountType",
                principalColumn: "AccoutnTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Bank_BankId",
                table: "User",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserRole_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "UserRole",
                principalColumn: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_AccountType_AccountType",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Bank_BankId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserRole_RoleId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_AccountType",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_BankId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RoleId",
                table: "User");
        }
    }
}
