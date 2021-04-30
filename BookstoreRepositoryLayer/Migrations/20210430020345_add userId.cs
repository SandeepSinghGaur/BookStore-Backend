using Microsoft.EntityFrameworkCore.Migrations;

namespace BookstoreRepositoryLayer.Migrations
{
    public partial class adduserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "OrderDB",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "CustomerDB",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderDB");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CustomerDB");
        }
    }
}
