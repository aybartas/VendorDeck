using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VendorDeck.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    BasketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Name", "Price", "Stock", "Type" },
                values: new object[,]
                {
                    { 1, "Angular", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "/images/products/sb-ang1.png", "Angular Speedster Board 2000", 20000L, 100, "Boards" },
                    { 2, "Angular", "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.", "/images/products/sb-ang2.png", "Green Angular Board 3000", 15000L, 100, "Boards" },
                    { 3, "NetCore", "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "/images/products/sb-core1.png", "Core Board Speed Rush 3", 18000L, 100, "Boards" },
                    { 4, "NetCore", "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", "/images/products/sb-core2.png", "Net Core Super Board", 30000L, 100, "Boards" },
                    { 5, "React", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "/images/products/sb-react1.png", "React Board Super Whizzy Fast", 25000L, 100, "Boards" },
                    { 6, "TypeScript", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "/images/products/sb-ts1.png", "Typescript Entry Board", 12000L, 100, "Boards" },
                    { 7, "NetCore", "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "/images/products/hat-core1.png", "Core Blue Hat", 1000L, 100, "Hats" },
                    { 8, "React", "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "/images/products/hat-react1.png", "Green React Woolen Hat", 8000L, 100, "Hats" },
                    { 9, "React", "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "/images/products/hat-react2.png", "Purple React Woolen Hat", 1500L, 100, "Hats" },
                    { 10, "VS Code", "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "/images/products/glove-code1.png", "Blue Code Gloves", 1800L, 100, "Gloves" },
                    { 11, "VS Code", "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "/images/products/glove-code2.png", "Green Code Gloves", 1500L, 100, "Gloves" },
                    { 12, "React", "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "/images/products/glove-react1.png", "Purple React Gloves", 1600L, 100, "Gloves" },
                    { 13, "React", "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "/images/products/glove-react2.png", "Green React Gloves", 1400L, 100, "Gloves" },
                    { 14, "Redis", "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "/images/products/boot-redis1.png", "Redis Red Boots", 25000L, 100, "Boots" },
                    { 15, "NetCore", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "/images/products/boot-core2.png", "Core Red Boots", 18999L, 100, "Boots" },
                    { 16, "NetCore", "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", "/images/products/boot-core1.png", "Core Purple Boots", 19999L, 100, "Boots" },
                    { 17, "Angular", "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.", "/images/products/boot-ang2.png", "Angular Purple Boots", 15000L, 100, "Boots" },
                    { 18, "Angular", "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "/images/products/boot-ang1.png", "Angular Blue Boots", 18000L, 100, "Boots" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketId",
                table: "BasketItems",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductId",
                table: "BasketItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
