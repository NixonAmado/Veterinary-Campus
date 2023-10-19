using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

class MovementDetailConfiguration:IEntityTypeConfiguration<MovementDetail>
{
    public void Configure(EntityTypeBuilder<MovementDetail> builder)
    {
        builder.ToTable("MovementDetail");

        builder.Property(p => p.Quantity)
                .IsRequired()
                .HasMaxLength(70);
    
        builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(10,3)")
                .HasMaxLength(100);
        
        builder.HasOne(p => p.MovementType)
            .WithMany(p => p.MovementDetails)
            .HasForeignKey(p => p.IdMovementTypeFk);

        builder.HasOne(p => p.Product)
                    .WithMany(p => p.MovementDetails)
                    .HasForeignKey(p => p.IdProductFk);
        
        builder.HasOne(p => p.ProductMovement)
                    .WithMany(p => p.MovementDetails)
                    .HasForeignKey(p => p.IdProductMovementFk);
                
    }
}