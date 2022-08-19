using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    internal class ReportsConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Report");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Type)
                .IsRequired()
                .HasConversion<int>();

            builder.HasOne(e => e.Appointment)
                .WithMany(x => x.Reports)
                .HasForeignKey(e => e.AppointmentId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasOne(e => e.AppointmentPayment)
                .WithMany(x => x.Reports)
                .HasForeignKey(e => e.AppointmentPaymentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}