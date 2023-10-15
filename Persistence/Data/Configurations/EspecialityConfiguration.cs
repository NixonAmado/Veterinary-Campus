using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

class EspecialityConfiguration:IEntityTypeConfiguration<Especiality>
{
    public void Configure(EntityTypeBuilder<Especiality> builder)
    {
        builder.ToTable("Especiality");

        builder.Property(p =>p.Description)
                .IsRequired()
                .HasMaxLength(50);
    }
}