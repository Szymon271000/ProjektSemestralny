using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektSemestralny.Logika.Migrations
{
    public partial class producents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryProducents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Producents",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Sony" });

            migrationBuilder.InsertData(
                table: "Producents",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Toshiba" });

            migrationBuilder.InsertData(
                table: "Producents",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Apple" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Producents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Producents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Producents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "CategoryProducents",
                columns: new[] { "Id", "CategoryId", "ProducentId" },
                values: new object[] { 1, 1, 1 });
        }
    }
}
