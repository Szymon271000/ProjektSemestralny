using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektSemestralny.Logika.Migrations
{
    public partial class filldata3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryProducentId", "Description", "Name", "Price" },
                values: new object[] { 2, 2, "Laptop dock for the Motorola ATRIX 4G for a more interactive computer-like experience from your smartphone", "ATRIX 4G", 500.0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryProducentId", "Description", "Name", "Price" },
                values: new object[] { 3, 3, "6 Models of Entry-level Displays with 4K High-Definition Image Quality.", "TH-75CQ2U 75 4K UHD Professional TV", 0.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
