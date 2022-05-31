using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektSemestralny.Logika.Migrations
{
    public partial class new_products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 13, "Smartwatches" },
                    { 20, "Washing machines" },
                    { 19, "Refrigerators" },
                    { 18, "Consoles" },
                    { 21, "Ovens" },
                    { 16, "Powerbanks" },
                    { 15, "Projectors" },
                    { 14, "Soundbars" },
                    { 17, "Printers" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 600.0);

            migrationBuilder.InsertData(
                table: "Producents",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 59, "Epson" },
                    { 53, "Electrolux" },
                    { 54, "Sony" },
                    { 55, "HP" },
                    { 56, "Huawei" },
                    { 57, "Boose" },
                    { 58, "Sbs" }
                });

            migrationBuilder.InsertData(
                table: "CategoryProducents",
                columns: new[] { "Id", "CategoryId", "ProducentId" },
                values: new object[,]
                {
                    { 4, 13, 50 },
                    { 10, 19, 50 },
                    { 11, 20, 53 },
                    { 12, 21, 53 },
                    { 9, 18, 54 },
                    { 5, 14, 57 },
                    { 7, 16, 58 },
                    { 6, 15, 59 },
                    { 8, 17, 59 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryProducentId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 4, 4, "Galaxy Watch4 Classic runs faster (compared to Galaxy Watch3), efficiently activates applications that you have even more space to do.", "Smartwatch SAMSUNG Galaxy Watch 4", 1199.0 },
                    { 10, 10, "The PS5 takes gaming to a new level you don't even expect.", "PlayStation 5 B Chassis", 2799.0 },
                    { 11, 11, "Looking for a unique refrigerator that fits perfectly into your kitchen style? If you're looking at design, the BESPOKE range of refrigerators will allow you to choose from a range of colors and textures.", "SAMSUNG Bespoke RB38A6B2E22/EF", 2949.0 },
                    { 12, 12, "The combination of steam and hot air ensures that the dishes do not dry and can be cooked at a lower temperature.", "ELECTROLUX EOC8H31Z", 2799.0 },
                    { 9, 9, "The PS5 takes gaming to a new level you don't even expect.", "PlayStation 5 B Chassis", 2799.0 },
                    { 5, 5, "Bose Voice4Video's unique technology extends voice control through Alex's assistant, something no other soundbar can do.", "Soundbar BOSE Smart Soundbar 900", 4699.0 },
                    { 7, 7, "With a high capacity battery, you don't have to worry about running out of battery power on your device.", "Powerbank SBS 20000mAh Czarny TTBB20000FASTK", 119.0 },
                    { 6, 6, "Enjoy your favorite movies with this Full HD projector.", "Projektor EPSON EH-TW740", 2699.0 },
                    { 8, 8, "Save up to 90% on printing costs with this Epson EcoTank L3251 printer.", "EPSON EcoTank L3251", 869.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Producents",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Producents",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "CategoryProducents",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CategoryProducents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CategoryProducents",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CategoryProducents",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CategoryProducents",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CategoryProducents",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CategoryProducents",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CategoryProducents",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CategoryProducents",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Producents",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Producents",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Producents",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Producents",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Producents",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 0.0);
        }
    }
}
