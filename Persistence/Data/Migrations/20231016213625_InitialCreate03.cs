using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductMovement_Product_ProductId",
                table: "ProductMovement");

            migrationBuilder.DropIndex(
                name: "IX_ProductMovement_ProductId",
                table: "ProductMovement");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductMovement");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMovement_IdProductFk",
                table: "ProductMovement",
                column: "IdProductFk");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMovement_Product_IdProductFk",
                table: "ProductMovement",
                column: "IdProductFk",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductMovement_Product_IdProductFk",
                table: "ProductMovement");

            migrationBuilder.DropIndex(
                name: "IX_ProductMovement_IdProductFk",
                table: "ProductMovement");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductMovement",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductMovement_ProductId",
                table: "ProductMovement",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMovement_Product_ProductId",
                table: "ProductMovement",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}
