using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektSemestralny.Logika.Migrations
{
    public partial class Items : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_CategoryProducents_CategoryProducentId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryProducentId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_CategoryProducents_CategoryProducentId",
                table: "Items",
                column: "CategoryProducentId",
                principalTable: "CategoryProducents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_CategoryProducents_CategoryProducentId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryProducentId",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_CategoryProducents_CategoryProducentId",
                table: "Items",
                column: "CategoryProducentId",
                principalTable: "CategoryProducents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
