using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsult.Models;

namespace ProConsult.Data.Configuration
{
    public class SpecialistConfiguration : IEntityTypeConfiguration<Specialist>
    {
        public void Configure(EntityTypeBuilder<Specialist> builder)
        {
            builder.ToTable("Specialists");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired(true)
                .HasColumnType("VARCHAR(60)");

            builder.Property(s => s.Description)
                .IsRequired(false)
                .HasColumnType("NVARCHAR(150)");

            builder.HasMany(d => d.Doctors)
                .WithOne(s => s.Specialist)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
