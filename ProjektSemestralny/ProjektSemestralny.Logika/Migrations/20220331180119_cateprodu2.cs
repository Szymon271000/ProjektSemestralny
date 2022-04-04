using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektSemestralny.Logika.Migrations
{
    public partial class cateprodu2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProducents_Producents_ProducentId",
                table: "CategoryProducents");

            migrationBuilder.DropIndex(
                name: "IX_CategoryProducents_ProducentId",
                table: "CategoryProducents");

            migrationBuilder.AlterColumn<int>(
                name: "ProducentId",
                table: "CategoryProducents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProducentId",
                table: "CategoryProducents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProducents_ProducentId",
                table: "CategoryProducents",
                column: "ProducentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProducents_Producents_ProducentId",
                table: "CategoryProducents",
                column: "ProducentId",
                principalTable: "Producents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
