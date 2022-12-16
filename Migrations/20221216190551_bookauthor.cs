using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryCodingNight.Migrations
{
    public partial class bookauthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_BookAuthor_BookAuthorId",
                table: "Author");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookAuthor_BookAuthorId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_BookAuthorId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Author_BookAuthorId",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "BookAuthorId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BookAuthorId",
                table: "Author");

            migrationBuilder.AddColumn<string>(
                name: "SerieDescription",
                table: "Serie",
                type: "text",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SerieName",
                table: "Serie",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "BookAuthor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BookAuthor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsAuthorId = table.Column<int>(type: "int", nullable: false),
                    BooksBookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsAuthorId, x.BooksBookId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Author_AuthorsAuthorId",
                        column: x => x.AuthorsAuthorId,
                        principalTable: "Author",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Book_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_AuthorId",
                table: "BookAuthor",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_BookId",
                table: "BookAuthor",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksBookId",
                table: "AuthorBook",
                column: "BooksBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Author_AuthorId",
                table: "BookAuthor",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Book_BookId",
                table: "BookAuthor",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Author_AuthorId",
                table: "BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Book_BookId",
                table: "BookAuthor");

            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthor_AuthorId",
                table: "BookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthor_BookId",
                table: "BookAuthor");

            migrationBuilder.DropColumn(
                name: "SerieDescription",
                table: "Serie");

            migrationBuilder.DropColumn(
                name: "SerieName",
                table: "Serie");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "BookAuthor");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookAuthor");

            migrationBuilder.AddColumn<int>(
                name: "BookAuthorId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookAuthorId",
                table: "Author",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookAuthorId",
                table: "Book",
                column: "BookAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Author_BookAuthorId",
                table: "Author",
                column: "BookAuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_BookAuthor_BookAuthorId",
                table: "Author",
                column: "BookAuthorId",
                principalTable: "BookAuthor",
                principalColumn: "BookAuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookAuthor_BookAuthorId",
                table: "Book",
                column: "BookAuthorId",
                principalTable: "BookAuthor",
                principalColumn: "BookAuthorId");
        }
    }
}
