using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _18_SaveData.Migrations
{
    /// <inheritdoc />
    public partial class addpriceproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksV2_AuthorsV2_AuthorV2Id",
                table: "BooksV2");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorV2Id",
                table: "BooksV2",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Books",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksV2_AuthorsV2_AuthorV2Id",
                table: "BooksV2",
                column: "AuthorV2Id",
                principalTable: "AuthorsV2",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksV2_AuthorsV2_AuthorV2Id",
                table: "BooksV2");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorV2Id",
                table: "BooksV2",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksV2_AuthorsV2_AuthorV2Id",
                table: "BooksV2",
                column: "AuthorV2Id",
                principalTable: "AuthorsV2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
