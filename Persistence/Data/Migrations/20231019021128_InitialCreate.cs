using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

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
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
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
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_name = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
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
                    PhoneNumber = table.Column<int>(type: "int", maxLength: 20, nullable: false),
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
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUserFk = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Created = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Revoked = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_User_IdUserFk",
                        column: x => x.IdUserFk,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                columns: table => new
                {
                    IdUserFk = table.Column<int>(type: "int", nullable: false),
                    IdRoleFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRoles", x => new { x.IdRoleFk, x.IdUserFk });
                    table.ForeignKey(
                        name: "FK_UsersRoles_Role_IdRoleFk",
                        column: x => x.IdRoleFk,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersRoles_User_IdUserFk",
                        column: x => x.IdUserFk,
                        principalTable: "User",
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
                    TotalPrice = table.Column<decimal>(type: "decimal(20,3)", nullable: false),
                    Quantity = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMovement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductMovement_Product_IdProductFk",
                        column: x => x.IdProductFk,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductSuppliers",
                columns: table => new
                {
                    IdSupplierFk = table.Column<int>(type: "int", nullable: false),
                    IdProductFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSuppliers", x => new { x.IdSupplierFk, x.IdProductFk });
                    table.ForeignKey(
                        name: "FK_ProductSuppliers_Person_IdSupplierFk",
                        column: x => x.IdSupplierFk,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSuppliers_Product_IdProductFk",
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
                    IdMovementTypeFk = table.Column<int>(type: "int", nullable: false),
                    IdProdMovementFk = table.Column<int>(type: "int", nullable: false),
                    ProductMovementId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,3)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovementDetail_MovementType_IdMovementTypeFk",
                        column: x => x.IdMovementTypeFk,
                        principalTable: "MovementType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovementDetail_ProductMovement_ProductMovementId",
                        column: x => x.ProductMovementId,
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
                name: "IX_MovementDetail_IdMovementTypeFk",
                table: "MovementDetail",
                column: "IdMovementTypeFk");

            migrationBuilder.CreateIndex(
                name: "IX_MovementDetail_IdProductFk",
                table: "MovementDetail",
                column: "IdProductFk");

            migrationBuilder.CreateIndex(
                name: "IX_MovementDetail_ProductMovementId",
                table: "MovementDetail",
                column: "ProductMovementId");

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
                name: "IX_ProductMovement_IdProductFk",
                table: "ProductMovement",
                column: "IdProductFk");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSuppliers_IdProductFk",
                table: "ProductSuppliers",
                column: "IdProductFk");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_IdUserFk",
                table: "RefreshToken",
                column: "IdUserFk");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_IdUserFk",
                table: "UsersRoles",
                column: "IdUserFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalTreatment");

            migrationBuilder.DropTable(
                name: "MovementDetail");

            migrationBuilder.DropTable(
                name: "ProductSuppliers");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "MovementType");

            migrationBuilder.DropTable(
                name: "ProductMovement");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Pet");

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
        }
    }
}
