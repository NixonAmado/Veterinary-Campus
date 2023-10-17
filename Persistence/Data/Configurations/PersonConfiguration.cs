using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

class PersonConfiguration:IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Person");

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(70);
    
        builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(100);
    
        builder.Property(p => p.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20);
    
        builder.HasOne(p => p.PersonType)
            .WithMany(p => p.People)
            .HasForeignKey(p => p.IdPersonTypeFk);

        builder.HasOne(p => p.Especiality)
                .WithMany(p => p.People)
                .HasForeignKey(p => p.IdEspecialityFk)
                .IsRequired(false);
            
    }
}