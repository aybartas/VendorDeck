using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendorDeck.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Addresstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShippingAddressDetails",
                table: "Orders",
                newName: "ShippingAddress_Zip");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Address",
                newName: "Zip");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress_Address2",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ShippingAddress_AppUserId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress_FullName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "bfe9f521-b012-42e3-841d-c47dac245463");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e953af94-0f07-4dfe-a4d9-4a2b99721344");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id",
                table: "Orders",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderNumber",
                table: "Orders",
                column: "OrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingAddress_AppUserId",
                table: "Orders",
                column: "ShippingAddress_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ShippingAddress_AppUserId",
                table: "Orders",
                column: "ShippingAddress_AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ShippingAddress_AppUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderNumber",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShippingAddress_AppUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Address1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_Address2",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_AppUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_FullName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Address1",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_Zip",
                table: "Orders",
                newName: "ShippingAddressDetails");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "Address",
                newName: "Details");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f1219731-7874-44c0-b721-70929a326ff7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "712f37e6-ea88-49d1-af4f-2ff43d841337");
        }
    }
}
