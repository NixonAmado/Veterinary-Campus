using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductMovement_MovementType_IdMovementTypeFk",
                table: "ProductMovement");

            migrationBuilder.DropIndex(
                name: "IX_ProductMovement_IdMovementTypeFk",
                table: "ProductMovement");

            migrationBuilder.DropColumn(
                name: "IdMovementTypeFk",
                table: "ProductMovement");

            migrationBuilder.AddColumn<int>(
                name: "IdMovementTypeFk",
                table: "MovementDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MovementDetail_IdMovementTypeFk",
                table: "MovementDetail",
                column: "IdMovementTypeFk");

            migrationBuilder.AddForeignKey(
                name: "FK_MovementDetail_MovementType_IdMovementTypeFk",
                table: "MovementDetail",
                column: "IdMovementTypeFk",
                principalTable: "MovementType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovementDetail_MovementType_IdMovementTypeFk",
                table: "MovementDetail");

            migrationBuilder.DropIndex(
                name: "IX_MovementDetail_IdMovementTypeFk",
                table: "MovementDetail");

            migrationBuilder.DropColumn(
                name: "IdMovementTypeFk",
                table: "MovementDetail");

            migrationBuilder.AddColumn<int>(
                name: "IdMovementTypeFk",
                table: "ProductMovement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductMovement_IdMovementTypeFk",
                table: "ProductMovement",
                column: "IdMovementTypeFk");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMovement_MovementType_IdMovementTypeFk",
                table: "ProductMovement",
                column: "IdMovementTypeFk",
                principalTable: "MovementType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
