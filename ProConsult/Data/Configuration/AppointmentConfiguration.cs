using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsult.Models;

namespace ProConsult.Data.Configuration
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Note)
                .IsRequired(true)
                .HasColumnType("VARCHAR(250)");

            builder.Property(a => a.PatientId)
                .IsRequired(true);

            builder.Property(d => d.DoctorId)
                .IsRequired(true);
        }
    }
}
