using Microsoft.EntityFrameworkCore.Migrations;

namespace BookstoreRepositoryLayer.Migrations
{
    public partial class UserIdAddedinBookDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "BookDB");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "BookDB",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookDB",
                table: "BookDB",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookDB",
                table: "BookDB");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BookDB");

            migrationBuilder.RenameTable(
                name: "BookDB",
                newName: "Book");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "BookId");
        }
    }
}
