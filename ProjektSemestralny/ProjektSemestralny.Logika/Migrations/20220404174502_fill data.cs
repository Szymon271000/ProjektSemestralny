using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektSemestralny.Logika.Migrations
{
    public partial class filldata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryProducents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoryProducents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CategoryProducents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Producents",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Producents",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Producents",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Mobile" });
        }
    }
}
