using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektSemestralny.Logika.Migrations
{
    public partial class filldata2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryProducentId", "Description", "Name", "Price" },
                values: new object[] { 1, 1, "Samsung's fastest, most powerful chip ever. That means, a faster CPU and GPU compared to Galaxy S21 Ultra. It’s an epic leap for smartphone technology.", "Galaxy S22 Ultra", 1199.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
