using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryCodingNight.Migrations
{
    public partial class reserve3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActual",
                table: "Reservation",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActual",
                table: "Reservation");
        }
    }
}
