
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

class BreedConfiguration:IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.ToTable("Breed");

        builder.Property(p =>p.Name)
                .IsRequired()
                .HasMaxLength(50);
        
        builder.HasOne(p => p.Species)
                    .WithMany(p => p.Breeds)
                    .HasForeignKey(p => p.IdSpeciesFk);
    }
}