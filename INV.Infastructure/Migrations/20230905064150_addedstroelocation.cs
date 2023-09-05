using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INV.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedstroelocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoreLocation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    createiontime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreLocation_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StoreLocation_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StoreLocation_Store_StorId",
                        column: x => x.StorId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreLocation_ProductId",
                table: "StoreLocation",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreLocation_StorId",
                table: "StoreLocation",
                column: "StorId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreLocation_UserId",
                table: "StoreLocation",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreLocation");
        }
    }
}
