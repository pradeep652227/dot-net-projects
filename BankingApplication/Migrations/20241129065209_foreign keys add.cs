using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingApplication.Migrations
{
    /// <inheritdoc />
    public partial class foreignkeysadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Add columns
            migrationBuilder.AddColumn<string>(
                            name: "accountType",
                            table: "Users",
                            type: "int",
                            nullable: false);

            migrationBuilder.AddColumn<string>(
                            name: "bankId",
                            table: "Users",
                            type: "int",
                            nullable: false);

            migrationBuilder.AddColumn<string>(
                            name: "roleId",
                            table: "Users",
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
            //Add columns
            migrationBuilder.DropColumn(
                table: "Users",
                name: "roleId"
                );           
            migrationBuilder.DropColumn(
                table: "Users",
                name: "accountType"
                );
            migrationBuilder.DropColumn(
                table: "Users",
                name: "bankId"
                );

            migrationBuilder.AddColumn<string>(
                            name: "bankId",
                            table: "Users",
                            type: "int",
                            nullable: false);

            migrationBuilder.AddColumn<string>(
                            name: "roleId",
                            table: "Users",
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
    }
}
