using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INV.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class thisforInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<long>(type: "bigint", nullable: false),
                    storeId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FisicalyearId = table.Column<long>(type: "bigint", nullable: false),
                    prductcountmain = table.Column<long>(type: "bigint", nullable: false),
                    productcountwestage = table.Column<long>(type: "bigint", nullable: false),
                    Tyoprationdatepe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    oprationtype = table.Column<byte>(type: "tinyint", nullable: false),
                    Expirtiondate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_Inventory_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Inventory_FisicalYear_FisicalyearId",
                        column: x => x.FisicalyearId,
                        principalTable: "FisicalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Inventory_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Inventory_Store_storeId",
                        column: x => x.storeId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_FisicalyearId",
                table: "Inventory",
                column: "FisicalyearId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_productId",
                table: "Inventory",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_storeId",
                table: "Inventory",
                column: "storeId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_UserId",
                table: "Inventory",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");
        }
    }
}
