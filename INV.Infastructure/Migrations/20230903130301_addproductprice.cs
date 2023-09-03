using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INV.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class addproductprice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "productprice",
                columns: table => new
                {
                    ProductPriceid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Purchaseprice = table.Column<int>(type: "int", nullable: false),
                    salesprice = table.Column<int>(type: "int", nullable: false),
                    coverprice = table.Column<int>(type: "int", nullable: false),
                    OpertaionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    productid = table.Column<long>(type: "bigint", nullable: false),
                    Fisicalyearid = table.Column<long>(type: "bigint", nullable: false),
                    userid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    actiondate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productprice", x => x.ProductPriceid);
                    table.ForeignKey(
                        name: "FK_productprice_ApplicationUser_userid",
                        column: x => x.userid,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_productprice_FisicalYear_Fisicalyearid",
                        column: x => x.Fisicalyearid,
                        principalTable: "FisicalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_productprice_Products_productid",
                        column: x => x.productid,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productprice_Fisicalyearid",
                table: "productprice",
                column: "Fisicalyearid");

            migrationBuilder.CreateIndex(
                name: "IX_productprice_productid",
                table: "productprice",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_productprice_userid",
                table: "productprice",
                column: "userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productprice");
        }
    }
}
