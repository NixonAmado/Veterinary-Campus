using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

class LaboratoryConfiguration:IEntityTypeConfiguration<Laboratory>
{
    public void Configure(EntityTypeBuilder<Laboratory> builder)
    {
        builder.ToTable("Laboratory");

        builder.Property(p =>p.Name)
                .IsRequired()
                .HasMaxLength(70);
    
        builder.Property(p =>p.Address)
                .IsRequired()
                .HasMaxLength(100);

        builder.Property(p =>p.PhoneNumber)
                .HasColumnType("int")
                .IsRequired()
                .HasMaxLength(50);
    
    }
}