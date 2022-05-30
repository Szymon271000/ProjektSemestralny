using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektSemestralny.Logika.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProducents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProducentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProducents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryProducents_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProducents_Producents_ProducentId",
                        column: x => x.ProducentId,
                        principalTable: "Producents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Paid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryProducentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_CategoryProducents_CategoryProducentId",
                        column: x => x.CategoryProducentId,
                        principalTable: "CategoryProducents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Items_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10, "Mobiles" },
                    { 11, "Laptops" },
                    { 12, "Monitors" }
                });

            migrationBuilder.InsertData(
                table: "Producents",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 50, "Samsung" },
                    { 51, "Motorola" },
                    { 52, "Panasonic" }
                });

            migrationBuilder.InsertData(
                table: "CategoryProducents",
                columns: new[] { "Id", "CategoryId", "ProducentId" },
                values: new object[] { 1, 10, 50 });

            migrationBuilder.InsertData(
                table: "CategoryProducents",
                columns: new[] { "Id", "CategoryId", "ProducentId" },
                values: new object[] { 2, 11, 51 });

            migrationBuilder.InsertData(
                table: "CategoryProducents",
                columns: new[] { "Id", "CategoryId", "ProducentId" },
                values: new object[] { 3, 12, 52 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryProducentId", "Description", "Name", "Price" },
                values: new object[] { 1, 1, "Samsung's fastest, most powerful chip ever. That means, a faster CPU and GPU compared to Galaxy S21 Ultra. It’s an epic leap for smartphone technology.", "Galaxy S22 Ultra", 1199.0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryProducentId", "Description", "Name", "Price" },
                values: new object[] { 2, 2, "Laptop dock for the Motorola ATRIX 4G for a more interactive computer-like experience from your smartphone", "ATRIX 4G", 500.0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryProducentId", "Description", "Name", "Price" },
                values: new object[] { 3, 3, "6 Models of Entry-level Displays with 4K High-Definition Image Quality.", "TH-75CQ2U 75 4K UHD Professional TV", 0.0 });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProducents_CategoryId",
                table: "CategoryProducents",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProducents_ProducentId",
                table: "CategoryProducents",
                column: "ProducentId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryProducentId",
                table: "Items",
                column: "CategoryProducentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "CategoryProducents");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Producents");
        }
    }
}
