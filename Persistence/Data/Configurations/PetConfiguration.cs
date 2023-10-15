using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

class PetConfiguration:IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("Pet");

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(70);
    
        builder.Property(p => p.Birthdate)
            .IsRequired()
            .HasColumnType("datetime");
    
        builder.HasOne(p => p.Owner)
            .WithMany(p => p.Pets)
            .HasForeignKey(p => p.IdOwnerFk);

        builder.HasOne(p => p.Species)
            .WithMany(p => p.Pets)
            .HasForeignKey(p => p.IdSpeciesFk);

        builder.HasOne(p => p.Breed)
            .WithMany(p => p.Pets)
            .HasForeignKey(p => p.IdBreedFk);

    }
}