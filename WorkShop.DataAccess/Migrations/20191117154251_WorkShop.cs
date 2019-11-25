using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkShop.DataAccess.Migrations
{
    public partial class WorkShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StockId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    //ProductId = table.Column<Guid>(nullable: true)
                },
            constraints: table =>
            {
                table.PrimaryKey("PK_Categories", x => x.Id);
                //table.ForeignKey(
                //    name: "FK_Categories_Products_ProductId",
                //    column: x => x.ProductId,
                //    principalTable: "Products",   
                //    principalColumn: "Id",
                //    onDelete: ReferentialAction.Restrict);
            });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Categories_ProductId",
            //    table: "Categories",
            //    column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StockId",
                table: "Products",
                column: "StockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
