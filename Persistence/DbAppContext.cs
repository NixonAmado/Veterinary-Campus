using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace Persistencia.Data;

public class DbAppContext: DbContext
{
    public DbAppContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Role> Roles{get;set;}
    public DbSet<User> Users {get;set;}
    public DbSet<UserRole> UsersRoles {get;set;}
    public DbSet<Appointment> Appointments {get;set;}
    public DbSet<Breed> Breeds {get;set;}
    public DbSet<Especiality> Especialities {get;set;}
    public DbSet<Laboratory> Laboratories {get;set;}
    public DbSet<MedicalTreatment> MedicalTreatments {get;set;}
    public DbSet<MovementDetail> MovementDetails {get;set;}
    public DbSet<MovementType> MovementTypes {get;set;}
    public DbSet<Person> People {get;set;}
    public DbSet<PersonType> PersonTypes {get;set;}
    public DbSet<Pet> Pets {get;set;}
    public DbSet<Product> Products {get;set;}
    public DbSet<ProductMovement> ProductMovements {get;set;}
    public DbSet<RefreshToken> RefreshTokens {get;set;}
    public DbSet<Species> Species {get;set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}