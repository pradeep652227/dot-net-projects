using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingApplication.Migrations
{
    /// <inheritdoc />
    public partial class accountTypecolumntypechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop dependent check constraint
            migrationBuilder.Sql("ALTER TABLE [User] DROP CONSTRAINT [CHK_User_CurrentBalance];");

            migrationBuilder.AlterColumn<int>(
                name: "AccountType",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccountType",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            // Recreate the check constraint
            migrationBuilder.Sql("ALTER TABLE [User] ADD CONSTRAINT [CHK_User_CurrentBalance] CHECK (/* your check condition here */);");

        }
    }
}
