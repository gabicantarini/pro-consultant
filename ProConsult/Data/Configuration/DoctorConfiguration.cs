﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsult.Models;

namespace ProConsult.Data.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .IsRequired(true)
                .HasColumnType("VARCHAR(50)");

            builder.Property(d => d.Document)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(11)");

            builder.Property(d => d.Mobile)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(11)");

            builder.Property(d => d.Crm)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(8)");

            builder.HasIndex(d => d.Document)
                .IsUnique(true);

            builder.HasIndex(d => d.Crm)
                .IsUnique();

            builder.HasMany(a => a.Appointment)
                .WithOne(d => d.Doctor)
                .HasForeignKey(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
