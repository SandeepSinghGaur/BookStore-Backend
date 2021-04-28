using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookstoreRepositoryLayer.Migrations
{
    public partial class orderDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderItemsOrderId",
                table: "CartDB",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderDB",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDB", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_OrderDB_CustomerDB_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerDB",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartDB_OrderItemsOrderId",
                table: "CartDB",
                column: "OrderItemsOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDB_CustomerId",
                table: "OrderDB",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDB_OrderDB_OrderItemsOrderId",
                table: "CartDB",
                column: "OrderItemsOrderId",
                principalTable: "OrderDB",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDB_OrderDB_OrderItemsOrderId",
                table: "CartDB");

            migrationBuilder.DropTable(
                name: "OrderDB");

            migrationBuilder.DropIndex(
                name: "IX_CartDB_OrderItemsOrderId",
                table: "CartDB");

            migrationBuilder.DropColumn(
                name: "OrderItemsOrderId",
                table: "CartDB");
        }
    }
}
