using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryCodingNight.Migrations
{
    public partial class card : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CardName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.CardId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CardId",
                table: "AspNetUsers",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Card_CardId",
                table: "AspNetUsers",
                column: "CardId",
                principalTable: "Card",
                principalColumn: "CardId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Card_CardId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CardId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "AspNetUsers");
        }
    }
}
