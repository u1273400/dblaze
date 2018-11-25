using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dblaze.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookID = table.Column<string>(type: "nchar(3)", nullable: true),
                    Title = table.Column<string>(type: "nchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookID = table.Column<string>(type: "nchar(3)", nullable: false),
                    Title = table.Column<string>(type: "nchar(20)", nullable: true),
                    Author = table.Column<string>(type: "nchar(20)", nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    ImageURL = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    CategoryName = table.Column<string>(type: "nchar(20)", nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    FirstName = table.Column<string>(type: "nchar(10)", nullable: false),
                    LastName = table.Column<string>(type: "nchar(10)", nullable: false),
                    Address = table.Column<string>(type: "nchar(50)", nullable: true),
                    Phone = table.Column<string>(type: "nchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "OrderLine",
                columns: table => new
                {
                    LineNum = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(nullable: true),
                    BookId = table.Column<string>(type: "nchar(3)", nullable: true),
                    Quantity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLine", x => x.LineNum);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<Guid>(nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    CardNo = table.Column<string>(maxLength: 12, nullable: true),
                    SecurityNo = table.Column<string>(maxLength: 3, nullable: true),
                    CardType = table.Column<string>(type: "nchar(10)", nullable: true),
                    TotalCost = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OrderLine");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
