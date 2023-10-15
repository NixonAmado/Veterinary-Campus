using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

class MedicalTreatmentConfiguration:IEntityTypeConfiguration<MedicalTreatment>
{
    public void Configure(EntityTypeBuilder<MedicalTreatment> builder)
    {
        builder.ToTable("MedicalTreatment");

        builder.Property(p => p.Dose)
                .IsRequired()
                .HasMaxLength(70);
    
        builder.Property(p => p.AdministrationDate)
                .IsRequired()
                .HasColumnType("datetime")
                .HasMaxLength(100);

        builder.Property(p => p.Observation)
                .HasColumnType("longtext")
                .IsRequired();

        builder.HasOne(p => p.Product)
                    .WithMany(p => p.MedicalTreatments)
                    .HasForeignKey(p => p.IdProductFk);
        
        builder.HasOne(p => p.Appointment)
                    .WithMany(p => p.MedicalTreatments)
                    .HasForeignKey(p => p.IdAppointmentFk);    
    }
}