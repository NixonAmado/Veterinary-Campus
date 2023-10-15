using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

class PersonTypeConfiguration:IEntityTypeConfiguration<PersonType>
{
    public void Configure(EntityTypeBuilder<PersonType> builder)
    {
        builder.ToTable("PersonType");

        builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(70);
    }
}