using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

class MovementTypeConfiguration:IEntityTypeConfiguration<MovementType>
{
    public void Configure(EntityTypeBuilder<MovementType> builder)
    {
        builder.ToTable("MovementType");

        builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(70);
    }
}