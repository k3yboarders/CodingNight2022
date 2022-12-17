using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryCodingNight.Migrations
{
    public partial class types : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedBook_AspNetUsers_ApplicationUserId1",
                table: "BorrowedBook");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_AspNetUsers_ApplicationUserId1",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_ApplicationUserId1",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_BorrowedBook_ApplicationUserId1",
                table: "BorrowedBook");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "BorrowedBook");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Reservation",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "BorrowedBook",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ApplicationUserId",
                table: "Reservation",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBook_ApplicationUserId",
                table: "BorrowedBook",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBook_AspNetUsers_ApplicationUserId",
                table: "BorrowedBook",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_AspNetUsers_ApplicationUserId",
                table: "Reservation",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedBook_AspNetUsers_ApplicationUserId",
                table: "BorrowedBook");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_AspNetUsers_ApplicationUserId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_ApplicationUserId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_BorrowedBook_ApplicationUserId",
                table: "BorrowedBook");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Reservation",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Reservation",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "BorrowedBook",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "BorrowedBook",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ApplicationUserId1",
                table: "Reservation",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBook_ApplicationUserId1",
                table: "BorrowedBook",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBook_AspNetUsers_ApplicationUserId1",
                table: "BorrowedBook",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_AspNetUsers_ApplicationUserId1",
                table: "Reservation",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
