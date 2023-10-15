using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

class ProductConfiguration:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(70);

        builder.Property(p => p.Stock)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(p => p.Price)
            .HasColumnType("decimal(10,3)")
            .IsRequired();

        builder.HasOne(p => p.Laboratory)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.IdLaboratoryFk);
        
        builder
        .HasMany(p => p.Suppliers)
        .WithMany(p => p.Products)
        .UsingEntity<ProductSupplier>(
            
            j => j
                .HasOne(pt => pt.Supplier)
                .WithMany(p => p.ProductsSuppliers)
                .HasForeignKey(pt => pt.IdSupplierFk),
            j => j
                .HasOne(pt => pt.Product)
                .WithMany(t => t.ProductsSuppliers)
                .HasForeignKey(pt => pt.IdProductFk),
            
            j =>{
                j.HasKey(t => new{t.IdSupplierFk, t.IdProductFk});
                });
    }
}