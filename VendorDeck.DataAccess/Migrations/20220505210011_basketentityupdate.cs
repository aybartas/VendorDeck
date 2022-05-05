using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendorDeck.DataAccess.Migrations
{
    public partial class basketentityupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Baskets");

            migrationBuilder.AddColumn<string>(
                name: "BuyerId",
                table: "Baskets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Baskets");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
