using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookstoreRepositoryLayer.Migrations
{
    public partial class addaddressTypeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressType",
                table: "CustomerDB");

            migrationBuilder.AddColumn<int>(
                name: "AddressTypeId",
                table: "CustomerDB",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AddressDB",
                columns: table => new
                {
                    AddressTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerAddressType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressDB", x => x.AddressTypeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressDB");

            migrationBuilder.DropColumn(
                name: "AddressTypeId",
                table: "CustomerDB");

            migrationBuilder.AddColumn<string>(
                name: "AddressType",
                table: "CustomerDB",
                nullable: true);
        }
    }
}
