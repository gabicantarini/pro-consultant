using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsult.Models;

namespace ProConsult.Data.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");
            builder.Property(p => p.Document)
                .IsRequired()
                .HasColumnType("NVARCHAR(11)");
            builder.Property(p => p.Mail)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");
            builder.Property(p => p.Mobile)
                .IsRequired()
                .HasColumnType("NVARCHAR(11)");
            builder.HasIndex(p => p.Document)
                .IsUnique();
            builder.HasMany(a => a.Appointment)
                .WithOne(p => p.Patient)
                .HasForeignKey(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
