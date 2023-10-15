
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

class AppointmentConfiguration:IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("Appointment");
        builder.Property(p => p.Date)
        .IsRequired()
        .HasColumnType("datetime")
        .HasMaxLength(50);

        builder.Property(p => p.Hour)
        .HasMaxLength(3)
        .HasColumnType("double")
        .IsRequired();

        builder.Property(p => p.Reason)
        .HasColumnType("longtext")
        .IsRequired();
        
        builder.HasOne(p => p.Pet)
        .WithMany(p => p.Appointments)
        .HasForeignKey(p => p.IdPetFk);
    
        builder.HasOne(p => p.Veterinarian)
        .WithMany(p => p.Appointments)
        .HasForeignKey(p => p.IdVeterinarianFk);    

        
    }
}