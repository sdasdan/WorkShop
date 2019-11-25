using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkShop.DataAccess.Migrations
{
    public partial class CategorieProductLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategorie",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    CategorieId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategorieModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategorieModel_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategorieModel_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategorieModel_CategorieId",
                table: "ProductCategorieModel",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategorieModel_ProductId",
                table: "ProductCategorieModel",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategorieModel");
        }
    }
}
