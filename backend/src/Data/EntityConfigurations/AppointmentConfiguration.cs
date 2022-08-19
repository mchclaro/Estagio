using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    internal class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointment");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description)
                .IsRequired(false)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.DataHeld)
                .IsRequired()
                .HasColumnType("datetime");
            
            builder.Property(e => e.Status)
                .IsRequired()
                .HasConversion<int>();

            builder.HasOne(e => e.Estimate)
                .WithOne(x => x.Appointment)
                .HasForeignKey<Appointment>(e => e.EstimateId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Client)
                .WithMany(x => x.Appointments)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}