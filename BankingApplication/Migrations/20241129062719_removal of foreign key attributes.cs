using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingApplication.Migrations
{
    /// <inheritdoc />
    public partial class removalofforeignkeyattributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Remove the index on AccountType, if it exists
            migrationBuilder.DropIndex(
                name: "IX_Users_accountType",
                table: "Users");

            // Remove the index on BankId, if it exists
            migrationBuilder.DropIndex(
                name: "IX_Users_BankId",
                table: "Users");

            // Remove the index on RoleId, if it exists
            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            // Drop the columns
            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            //Add columns
            migrationBuilder.AddColumn<string>(
                            name: "accountType",
                            table: "User",
                            type: "int",
                            nullable: false);          
            
            migrationBuilder.AddColumn<string>(
                            name: "bankId",
                            table: "User",
                            type: "int",
                            nullable: false);

            migrationBuilder.AddColumn<string>(
                            name: "roleId",
                            table: "User",
                            type: "int",
                            nullable: false);

            // Step 3: Recreate Foreign Key Constraints
            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_roleId",
                table: "Users",
                column: "roleId",
                principalTable: "UserRoles",
                principalColumn: "roleId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Banks_bankId",
                table: "Users",
                column: "bankId",
                principalTable: "Banks",
                principalColumn: "bankId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AccountTypes_accountType",
                table: "Users",
                column: "accountType",
                principalTable: "AccountTypes",
                principalColumn: "accountTypeId",
                onDelete: ReferentialAction.NoAction);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {


        }
    }
}
