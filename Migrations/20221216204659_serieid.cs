using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryCodingNight.Migrations
{
    public partial class serieid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Serie_SerieId",
                table: "Book");

            migrationBuilder.AlterColumn<int>(
                name: "SerieId",
                table: "Book",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Serie_SerieId",
                table: "Book",
                column: "SerieId",
                principalTable: "Serie",
                principalColumn: "SerieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Serie_SerieId",
                table: "Book");

            migrationBuilder.AlterColumn<int>(
                name: "SerieId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Serie_SerieId",
                table: "Book",
                column: "SerieId",
                principalTable: "Serie",
                principalColumn: "SerieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
