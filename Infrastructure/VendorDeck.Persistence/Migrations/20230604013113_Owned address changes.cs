using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendorDeck.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Ownedaddresschanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_AppUserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ShippingAddress_AppUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShippingAddress_AppUserId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_AppUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_CreatedDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_State",
                table: "Orders",
                newName: "ShippingAddressState");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_Details",
                table: "Orders",
                newName: "ShippingAddressDetails");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_Country",
                table: "Orders",
                newName: "ShippingAddressCountry");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_City",
                table: "Orders",
                newName: "ShippingAddressCity");

            migrationBuilder.RenameColumn(
                name: "OrderedProductItem_ProductId",
                table: "OrderItem",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "OrderedProductItem_PictureUrl",
                table: "OrderItem",
                newName: "PictureUrl");

            migrationBuilder.RenameColumn(
                name: "OrderedProductItem_Name",
                table: "OrderItem",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_AppUserId",
                table: "Address",
                newName: "IX_Address_AppUserId");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Address",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8423dc98-e836-48ba-bff4-f25c8122d471");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "092ee29b-7b93-4eaa-80dd-84271881c83b");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AspNetUsers_AppUserId",
                table: "Address",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AspNetUsers_AppUserId",
                table: "Address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameColumn(
                name: "ShippingAddressState",
                table: "Orders",
                newName: "ShippingAddress_State");

            migrationBuilder.RenameColumn(
                name: "ShippingAddressDetails",
                table: "Orders",
                newName: "ShippingAddress_Details");

            migrationBuilder.RenameColumn(
                name: "ShippingAddressCountry",
                table: "Orders",
                newName: "ShippingAddress_Country");

            migrationBuilder.RenameColumn(
                name: "ShippingAddressCity",
                table: "Orders",
                newName: "ShippingAddress_City");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderItem",
                newName: "OrderedProductItem_ProductId");

            migrationBuilder.RenameColumn(
                name: "PictureUrl",
                table: "OrderItem",
                newName: "OrderedProductItem_PictureUrl");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "OrderItem",
                newName: "OrderedProductItem_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Address_AppUserId",
                table: "Addresses",
                newName: "IX_Addresses_AppUserId");

            migrationBuilder.AddColumn<int>(
                name: "ShippingAddress_AppUserId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ShippingAddress_CreatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ShippingAddress_Id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8a3a41f4-7320-434c-84bb-ee9f9d543f4d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "fe7cdcff-7e2d-4f54-930b-fb907a748d5a");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingAddress_AppUserId",
                table: "Orders",
                column: "ShippingAddress_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_AppUserId",
                table: "Addresses",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ShippingAddress_AppUserId",
                table: "Orders",
                column: "ShippingAddress_AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
