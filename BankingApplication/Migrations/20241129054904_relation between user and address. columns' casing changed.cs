using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingApplication.Migrations
{
    /// <inheritdoc />
    public partial class relationbetweenuserandaddresscolumnscasingchanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AccountTypes_AccountType",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Banks_BankId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_RoleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Users",
                newName: "roleId");

            migrationBuilder.RenameColumn(
                name: "PaymentUpdatedOn",
                table: "Users",
                newName: "paymentUpdatedOn");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "CurrentBalance",
                table: "Users",
                newName: "currentBalance");

            migrationBuilder.RenameColumn(
                name: "BankId",
                table: "Users",
                newName: "bankId");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Users",
                newName: "addressId");

            migrationBuilder.RenameColumn(
                name: "AccountType",
                table: "Users",
                newName: "accountType");

            migrationBuilder.RenameColumn(
                name: "AccountStatus",
                table: "Users",
                newName: "accountStatus");

            migrationBuilder.RenameColumn(
                name: "AccountCreatedOn",
                table: "Users",
                newName: "accountCreatedOn");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "userId");

            //migrationBuilder.RenameColumn(
            //    name: "Address",
            //    table: "Users",
            //    newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                newName: "IX_Users_roleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_BankId",
                table: "Users",
                newName: "IX_Users_bankId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_AccountType",
                table: "Users",
                newName: "IX_Users_accountType");

            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "UserRoles",
                newName: "roleName");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "UserRoles",
                newName: "roleId");

            migrationBuilder.RenameColumn(
                name: "TransactionTypeName",
                table: "TransactionTypes",
                newName: "transactionTypeName");

            migrationBuilder.RenameColumn(
                name: "TransactionTypeId",
                table: "TransactionTypes",
                newName: "transactionTypeId");

            migrationBuilder.RenameColumn(
                name: "TransactionTypeId",
                table: "Transactions",
                newName: "transactionTypeId");

            migrationBuilder.RenameColumn(
                name: "ToUserCurrentBalance",
                table: "Transactions",
                newName: "toUserCurrentBalance");

            migrationBuilder.RenameColumn(
                name: "ToUser",
                table: "Transactions",
                newName: "toUser");

            migrationBuilder.RenameColumn(
                name: "Remarks",
                table: "Transactions",
                newName: "remarks");

            migrationBuilder.RenameColumn(
                name: "FromUserCurrentBalance",
                table: "Transactions",
                newName: "fromUserCurrentBalance");

            migrationBuilder.RenameColumn(
                name: "FromUser",
                table: "Transactions",
                newName: "fromUser");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Transactions",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "Transactions",
                newName: "transactionId");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Banks",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "PINCode",
                table: "Banks",
                newName: "pinCode");

            migrationBuilder.RenameColumn(
                name: "LandMark",
                table: "Banks",
                newName: "landMark");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Banks",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Banks",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "BankName",
                table: "Banks",
                newName: "bankName");

            migrationBuilder.RenameColumn(
                name: "BankId",
                table: "Banks",
                newName: "bankId");

            migrationBuilder.RenameColumn(
                name: "AccountTypeName",
                table: "AccountTypes",
                newName: "accountTypeName");

            migrationBuilder.RenameColumn(
                name: "AccoutnTypeId",
                table: "AccountTypes",
                newName: "accountTypeId");

            //migrationBuilder.AddColumn<int>(
            //    name: "AccountType",
            //    table: "Users",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "BankId",
            //    table: "Users",
            //    type: "int",
            //    nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_addressId",
                table: "Users",
                column: "addressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AccountTypes_accountType",
                table: "Users",
                column: "accountType",
                principalTable: "AccountTypes",
                principalColumn: "accountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Addresses_addressId",
                table: "Users",
                column: "addressId",
                principalTable: "Addresses",
                principalColumn: "addressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Banks_bankId",
                table: "Users",
                column: "bankId",
                principalTable: "Banks",
                principalColumn: "bankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_roleId",
                table: "Users",
                column: "roleId",
                principalTable: "UserRoles",
                principalColumn: "roleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AccountTypes_accountType",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Addresses_addressId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Banks_bankId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_roleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_addressId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "Users",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "paymentUpdatedOn",
                table: "Users",
                newName: "PaymentUpdatedOn");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "currentBalance",
                table: "Users",
                newName: "CurrentBalance");

            migrationBuilder.RenameColumn(
                name: "bankId",
                table: "Users",
                newName: "BankId");

            migrationBuilder.RenameColumn(
                name: "addressId",
                table: "Users",
                newName: "AddressId");

            migrationBuilder.RenameColumn(
                name: "accountType",
                table: "Users",
                newName: "AccountType");

            migrationBuilder.RenameColumn(
                name: "accountStatus",
                table: "Users",
                newName: "AccountStatus");

            migrationBuilder.RenameColumn(
                name: "accountCreatedOn",
                table: "Users",
                newName: "AccountCreatedOn");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Users",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Users_roleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_bankId",
                table: "Users",
                newName: "IX_Users_BankId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_accountType",
                table: "Users",
                newName: "IX_Users_AccountType");

            migrationBuilder.RenameColumn(
                name: "roleName",
                table: "UserRoles",
                newName: "RoleName");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "UserRoles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "transactionTypeName",
                table: "TransactionTypes",
                newName: "TransactionTypeName");

            migrationBuilder.RenameColumn(
                name: "transactionTypeId",
                table: "TransactionTypes",
                newName: "TransactionTypeId");

            migrationBuilder.RenameColumn(
                name: "transactionTypeId",
                table: "Transactions",
                newName: "TransactionTypeId");

            migrationBuilder.RenameColumn(
                name: "toUserCurrentBalance",
                table: "Transactions",
                newName: "ToUserCurrentBalance");

            migrationBuilder.RenameColumn(
                name: "toUser",
                table: "Transactions",
                newName: "ToUser");

            migrationBuilder.RenameColumn(
                name: "remarks",
                table: "Transactions",
                newName: "Remarks");

            migrationBuilder.RenameColumn(
                name: "fromUserCurrentBalance",
                table: "Transactions",
                newName: "FromUserCurrentBalance");

            migrationBuilder.RenameColumn(
                name: "fromUser",
                table: "Transactions",
                newName: "FromUser");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Transactions",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "transactionId",
                table: "Transactions",
                newName: "TransactionId");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "Banks",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "pinCode",
                table: "Banks",
                newName: "PINCode");

            migrationBuilder.RenameColumn(
                name: "landMark",
                table: "Banks",
                newName: "LandMark");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Banks",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Banks",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "bankName",
                table: "Banks",
                newName: "BankName");

            migrationBuilder.RenameColumn(
                name: "bankId",
                table: "Banks",
                newName: "BankId");

            migrationBuilder.RenameColumn(
                name: "accountTypeName",
                table: "AccountTypes",
                newName: "AccountTypeName");

            migrationBuilder.RenameColumn(
                name: "accountTypeId",
                table: "AccountTypes",
                newName: "AccoutnTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AccountTypes_AccountType",
                table: "Users",
                column: "AccountType",
                principalTable: "AccountTypes",
                principalColumn: "AccoutnTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Banks_BankId",
                table: "Users",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "UserRoles",
                principalColumn: "RoleId");
        }
    }
}
