using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektSemestralny.Logika.Migrations
{
    public partial class cateprodu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProducents_Categories_CategoryId",
                table: "CategoryProducents");

            migrationBuilder.DropIndex(
                name: "IX_CategoryProducents_CategoryId",
                table: "CategoryProducents");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
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
                name: "CategoryId",
                table: "CategoryProducents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mobile" },
                    { 2, "Tv" },
                    { 3, "Pc" },
                    { 4, "Scan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProducents_CategoryId",
                table: "CategoryProducents",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProducents_Categories_CategoryId",
                table: "CategoryProducents",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
