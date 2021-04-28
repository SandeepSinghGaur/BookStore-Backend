using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookstoreRepositoryLayer.Migrations
{
    public partial class AddCustomerDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerRegister",
                table: "CustomerRegister");

            migrationBuilder.RenameTable(
                name: "CustomerRegister",
                newName: "UserDB");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDB",
                table: "UserDB",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "CustomerDB",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fullname = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Pincode = table.Column<string>(nullable: false),
                    AddressType = table.Column<string>(nullable: true),
                    FullAddress = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDB", x => x.CustomerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerDB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDB",
                table: "UserDB");

            migrationBuilder.RenameTable(
                name: "UserDB",
                newName: "CustomerRegister");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerRegister",
                table: "CustomerRegister",
                column: "UserId");
        }
    }
}
