using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsult.Models;

namespace ProConsult.Data.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired(true)
                .HasColumnType("VARCHAR(50)");

            builder.Property(p => p.Document)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(11)");

            builder.Property(p => p.Mobile)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(11)");

            builder.Property(p => p.Crm)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(8)");

            builder.HasIndex(p => p.Document)
                .IsUnique(true);

            builder.HasIndex(p => p.Crm)
                .IsUnique();

            builder.HasMany(a => a.Appointment)
                .WithOne(d => d.Doctor)
                .HasForeignKey(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
