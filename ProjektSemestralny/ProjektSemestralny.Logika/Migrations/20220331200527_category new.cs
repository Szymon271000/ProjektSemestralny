using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektSemestralny.Logika.Migrations
{
    public partial class categorynew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CategoryProducents_CategoryId",
                table: "CategoryProducents",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProducents_ProducentId",
                table: "CategoryProducents",
                column: "ProducentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProducents_Categories_CategoryId",
                table: "CategoryProducents",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProducents_Producents_ProducentId",
                table: "CategoryProducents",
                column: "ProducentId",
                principalTable: "Producents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProducents_Categories_CategoryId",
                table: "CategoryProducents");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProducents_Producents_ProducentId",
                table: "CategoryProducents");

            migrationBuilder.DropIndex(
                name: "IX_CategoryProducents_CategoryId",
                table: "CategoryProducents");

            migrationBuilder.DropIndex(
                name: "IX_CategoryProducents_ProducentId",
                table: "CategoryProducents");
        }
    }
}
