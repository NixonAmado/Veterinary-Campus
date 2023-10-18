using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

class ProductMovementConfiguration:IEntityTypeConfiguration<ProductMovement>
{
    public void Configure(EntityTypeBuilder<ProductMovement> builder)
    {
        builder.ToTable("ProductMovement");

        builder.Property(p => p.Date)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(p => p.Quantity)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(p => p.TotalPrice)
            .HasColumnType("decimal(20,3)");

        builder.HasOne(p => p.Product)
            .WithMany(p => p.ProductMovements)
            .HasForeignKey(p => p.IdProductFk);
        
    }
}