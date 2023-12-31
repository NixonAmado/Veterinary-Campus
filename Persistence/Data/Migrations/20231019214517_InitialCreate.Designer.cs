﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia.Data;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(DbAppContext))]
    [Migration("20231019214517_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasMaxLength(50)
                        .HasColumnType("datetime");

                    b.Property<double>("Hour")
                        .HasMaxLength(3)
                        .HasColumnType("double");

                    b.Property<int>("IdPetFk")
                        .HasColumnType("int");

                    b.Property<int>("IdVeterinarianFk")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdPetFk");

                    b.HasIndex("IdVeterinarianFk");

                    b.ToTable("Appointment", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Breed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdSpeciesFk")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdSpeciesFk");

                    b.ToTable("Breed", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Especiality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Especiality", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Laboratory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.Property<int>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Laboratory", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MedicalTreatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AdministrationDate")
                        .HasMaxLength(100)
                        .HasColumnType("datetime");

                    b.Property<string>("Dose")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.Property<int>("IdAppointmentFk")
                        .HasColumnType("int");

                    b.Property<int>("IdProductFk")
                        .HasColumnType("int");

                    b.Property<string>("Observation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdAppointmentFk");

                    b.HasIndex("IdProductFk");

                    b.ToTable("MedicalTreatment", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MovementDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdMovementTypeFk")
                        .HasColumnType("int");

                    b.Property<int>("IdProductFk")
                        .HasColumnType("int");

                    b.Property<int>("IdProductMovementFk")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasMaxLength(100)
                        .HasColumnType("decimal(10,3)");

                    b.Property<int>("Quantity")
                        .HasMaxLength(70)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdMovementTypeFk");

                    b.HasIndex("IdProductFk");

                    b.HasIndex("IdProductMovementFk");

                    b.ToTable("MovementDetail", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MovementType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.HasKey("Id");

                    b.ToTable("MovementType", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("IdEspecialityFk")
                        .HasColumnType("int");

                    b.Property<int>("IdPersonTypeFk")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.Property<int>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEspecialityFk");

                    b.HasIndex("IdPersonTypeFk");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.PersonType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.HasKey("Id");

                    b.ToTable("PersonType", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime");

                    b.Property<int>("IdBreedFk")
                        .HasColumnType("int");

                    b.Property<int>("IdOwnerFk")
                        .HasColumnType("int");

                    b.Property<int>("IdSpeciesFk")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.HasKey("Id");

                    b.HasIndex("IdBreedFk");

                    b.HasIndex("IdOwnerFk");

                    b.HasIndex("IdSpeciesFk");

                    b.ToTable("Pet", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdLaboratoryFk")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,3)");

                    b.Property<int>("Stock")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdLaboratoryFk");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ProductMovement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<int>("IdProductFk")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(20,3)");

                    b.HasKey("Id");

                    b.HasIndex("IdProductFk");

                    b.ToTable("ProductMovement", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ProductSupplier", b =>
                {
                    b.Property<int>("IdSupplierFk")
                        .HasColumnType("int");

                    b.Property<int>("IdProductFk")
                        .HasColumnType("int");

                    b.HasKey("IdSupplierFk", "IdProductFk");

                    b.HasIndex("IdProductFk");

                    b.ToTable("ProductSuppliers");
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("DateTime");

                    b.Property<int>("IdUserFk")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("DateTime");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("IdUserFk");

                    b.ToTable("RefreshToken", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Species", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Species", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("user_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.UserRole", b =>
                {
                    b.Property<int>("IdRoleFk")
                        .HasColumnType("int");

                    b.Property<int>("IdUserFk")
                        .HasColumnType("int");

                    b.HasKey("IdRoleFk", "IdUserFk");

                    b.HasIndex("IdUserFk");

                    b.ToTable("UsersRoles");
                });

            modelBuilder.Entity("Domain.Entities.Appointment", b =>
                {
                    b.HasOne("Domain.Entities.Pet", "Pet")
                        .WithMany("Appointments")
                        .HasForeignKey("IdPetFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Person", "Veterinarian")
                        .WithMany("Appointments")
                        .HasForeignKey("IdVeterinarianFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");

                    b.Navigation("Veterinarian");
                });

            modelBuilder.Entity("Domain.Entities.Breed", b =>
                {
                    b.HasOne("Domain.Entities.Species", "Species")
                        .WithMany("Breeds")
                        .HasForeignKey("IdSpeciesFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Species");
                });

            modelBuilder.Entity("Domain.Entities.MedicalTreatment", b =>
                {
                    b.HasOne("Domain.Entities.Appointment", "Appointment")
                        .WithMany("MedicalTreatments")
                        .HasForeignKey("IdAppointmentFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany("MedicalTreatments")
                        .HasForeignKey("IdProductFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entities.MovementDetail", b =>
                {
                    b.HasOne("Domain.Entities.MovementType", "MovementType")
                        .WithMany("MovementDetails")
                        .HasForeignKey("IdMovementTypeFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany("MovementDetails")
                        .HasForeignKey("IdProductFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ProductMovement", "ProductMovement")
                        .WithMany("MovementDetails")
                        .HasForeignKey("IdProductMovementFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MovementType");

                    b.Navigation("Product");

                    b.Navigation("ProductMovement");
                });

            modelBuilder.Entity("Domain.Entities.Person", b =>
                {
                    b.HasOne("Domain.Entities.Especiality", "Especiality")
                        .WithMany("People")
                        .HasForeignKey("IdEspecialityFk");

                    b.HasOne("Domain.Entities.PersonType", "PersonType")
                        .WithMany("People")
                        .HasForeignKey("IdPersonTypeFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especiality");

                    b.Navigation("PersonType");
                });

            modelBuilder.Entity("Domain.Entities.Pet", b =>
                {
                    b.HasOne("Domain.Entities.Breed", "Breed")
                        .WithMany("Pets")
                        .HasForeignKey("IdBreedFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Person", "Owner")
                        .WithMany("Pets")
                        .HasForeignKey("IdOwnerFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Species", "Species")
                        .WithMany("Pets")
                        .HasForeignKey("IdSpeciesFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Breed");

                    b.Navigation("Owner");

                    b.Navigation("Species");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.HasOne("Domain.Entities.Laboratory", "Laboratory")
                        .WithMany("Products")
                        .HasForeignKey("IdLaboratoryFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laboratory");
                });

            modelBuilder.Entity("Domain.Entities.ProductMovement", b =>
                {
                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany("ProductMovements")
                        .HasForeignKey("IdProductFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entities.ProductSupplier", b =>
                {
                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany("ProductsSuppliers")
                        .HasForeignKey("IdProductFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Person", "Supplier")
                        .WithMany("ProductsSuppliers")
                        .HasForeignKey("IdSupplierFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("IdUserFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.UserRole", b =>
                {
                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany("UsersRoles")
                        .HasForeignKey("IdRoleFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UsersRoles")
                        .HasForeignKey("IdUserFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Appointment", b =>
                {
                    b.Navigation("MedicalTreatments");
                });

            modelBuilder.Entity("Domain.Entities.Breed", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("Domain.Entities.Especiality", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("Domain.Entities.Laboratory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.Entities.MovementType", b =>
                {
                    b.Navigation("MovementDetails");
                });

            modelBuilder.Entity("Domain.Entities.Person", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Pets");

                    b.Navigation("ProductsSuppliers");
                });

            modelBuilder.Entity("Domain.Entities.PersonType", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("Domain.Entities.Pet", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Navigation("MedicalTreatments");

                    b.Navigation("MovementDetails");

                    b.Navigation("ProductMovements");

                    b.Navigation("ProductsSuppliers");
                });

            modelBuilder.Entity("Domain.Entities.ProductMovement", b =>
                {
                    b.Navigation("MovementDetails");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Navigation("UsersRoles");
                });

            modelBuilder.Entity("Domain.Entities.Species", b =>
                {
                    b.Navigation("Breeds");

                    b.Navigation("Pets");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UsersRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
