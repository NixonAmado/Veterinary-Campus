using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_User_userId",
                table: "RefreshToken");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersRoles_Role_IdRolFk",
                table: "UsersRoles");

            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_userId",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "RefreshToken");

            migrationBuilder.RenameColumn(
                name: "IdRolFk",
                table: "UsersRoles",
                newName: "IdRoleFk");

            migrationBuilder.UpdateData(
                table: "RefreshToken",
                keyColumn: "Token",
                keyValue: null,
                column: "Token",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "RefreshToken",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Revoked",
                table: "RefreshToken",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Expires",
                table: "RefreshToken",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "RefreshToken",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.CreateTable(
                name: "Especiality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especiality", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Laboratory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratory", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovementType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PersonType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Stock = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    IdLaboratoryFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Laboratory_IdLaboratoryFk",
                        column: x => x.IdLaboratoryFk,
                        principalTable: "Laboratory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    IdPersonTypeFk = table.Column<int>(type: "int", nullable: false),
                    IdEspecialityFk = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Especiality_IdEspecialityFk",
                        column: x => x.IdEspecialityFk,
                        principalTable: "Especiality",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Person_PersonType_IdPersonTypeFk",
                        column: x => x.IdPersonTypeFk,
                        principalTable: "PersonType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Breed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdSpeciesFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breed_Species_IdSpeciesFk",
                        column: x => x.IdSpeciesFk,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductMovement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProductFk = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdMovementTypeFk = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMovement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductMovement_MovementType_IdMovementTypeFk",
                        column: x => x.IdMovementTypeFk,
                        principalTable: "MovementType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMovement_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductSupplier",
                columns: table => new
                {
                    IdSupplierFk = table.Column<int>(type: "int", nullable: false),
                    IdProductFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSupplier", x => new { x.IdSupplierFk, x.IdProductFk });
                    table.ForeignKey(
                        name: "FK_ProductSupplier_Person_IdSupplierFk",
                        column: x => x.IdSupplierFk,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSupplier_Product_IdProductFk",
                        column: x => x.IdProductFk,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdOwnerFk = table.Column<int>(type: "int", nullable: false),
                    IdSpeciesFk = table.Column<int>(type: "int", nullable: false),
                    IdBreedFk = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Birthdate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pet_Breed_IdBreedFk",
                        column: x => x.IdBreedFk,
                        principalTable: "Breed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pet_Person_IdOwnerFk",
                        column: x => x.IdOwnerFk,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pet_Species_IdSpeciesFk",
                        column: x => x.IdSpeciesFk,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovementDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProductFk = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", maxLength: 70, nullable: false),
                    IdProdMovementFk = table.Column<int>(type: "int", nullable: false),
                    ProductMovementsId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,3)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovementDetail_ProductMovement_ProductMovementsId",
                        column: x => x.ProductMovementsId,
                        principalTable: "ProductMovement",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovementDetail_Product_IdProductFk",
                        column: x => x.IdProductFk,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPetFk = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", maxLength: 50, nullable: false),
                    Hour = table.Column<double>(type: "double", maxLength: 3, nullable: false),
                    Reason = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdVeterinarianFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Person_IdVeterinarianFk",
                        column: x => x.IdVeterinarianFk,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Pet_IdPetFk",
                        column: x => x.IdPetFk,
                        principalTable: "Pet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicalTreatment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdAppointmentFk = table.Column<int>(type: "int", nullable: false),
                    IdProductFk = table.Column<int>(type: "int", nullable: false),
                    Dose = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdministrationDate = table.Column<DateTime>(type: "datetime", maxLength: 100, nullable: false),
                    Observation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalTreatment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalTreatment_Appointment_IdAppointmentFk",
                        column: x => x.IdAppointmentFk,
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalTreatment_Product_IdProductFk",
                        column: x => x.IdProductFk,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_IdUserFk",
                table: "RefreshToken",
                column: "IdUserFk");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_IdPetFk",
                table: "Appointment",
                column: "IdPetFk");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_IdVeterinarianFk",
                table: "Appointment",
                column: "IdVeterinarianFk");

            migrationBuilder.CreateIndex(
                name: "IX_Breed_IdSpeciesFk",
                table: "Breed",
                column: "IdSpeciesFk");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalTreatment_IdAppointmentFk",
                table: "MedicalTreatment",
                column: "IdAppointmentFk");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalTreatment_IdProductFk",
                table: "MedicalTreatment",
                column: "IdProductFk");

            migrationBuilder.CreateIndex(
                name: "IX_MovementDetail_IdProductFk",
                table: "MovementDetail",
                column: "IdProductFk");

            migrationBuilder.CreateIndex(
                name: "IX_MovementDetail_ProductMovementsId",
                table: "MovementDetail",
                column: "ProductMovementsId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_IdEspecialityFk",
                table: "Person",
                column: "IdEspecialityFk");

            migrationBuilder.CreateIndex(
                name: "IX_Person_IdPersonTypeFk",
                table: "Person",
                column: "IdPersonTypeFk");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_IdBreedFk",
                table: "Pet",
                column: "IdBreedFk");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_IdOwnerFk",
                table: "Pet",
                column: "IdOwnerFk");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_IdSpeciesFk",
                table: "Pet",
                column: "IdSpeciesFk");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdLaboratoryFk",
                table: "Product",
                column: "IdLaboratoryFk");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMovement_IdMovementTypeFk",
                table: "ProductMovement",
                column: "IdMovementTypeFk");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMovement_ProductId",
                table: "ProductMovement",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplier_IdProductFk",
                table: "ProductSupplier",
                column: "IdProductFk");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_User_IdUserFk",
                table: "RefreshToken",
                column: "IdUserFk",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRoles_Role_IdRoleFk",
                table: "UsersRoles",
                column: "IdRoleFk",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_User_IdUserFk",
                table: "RefreshToken");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersRoles_Role_IdRoleFk",
                table: "UsersRoles");

            migrationBuilder.DropTable(
                name: "MedicalTreatment");

            migrationBuilder.DropTable(
                name: "MovementDetail");

            migrationBuilder.DropTable(
                name: "ProductSupplier");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "ProductMovement");

            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "MovementType");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Breed");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Laboratory");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Especiality");

            migrationBuilder.DropTable(
                name: "PersonType");

            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_IdUserFk",
                table: "RefreshToken");

            migrationBuilder.RenameColumn(
                name: "IdRoleFk",
                table: "UsersRoles",
                newName: "IdRolFk");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "RefreshToken",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Revoked",
                table: "RefreshToken",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Expires",
                table: "RefreshToken",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "RefreshToken",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "RefreshToken",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_userId",
                table: "RefreshToken",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_User_userId",
                table: "RefreshToken",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRoles_Role_IdRolFk",
                table: "UsersRoles",
                column: "IdRolFk",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
