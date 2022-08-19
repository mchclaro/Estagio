using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    internal class AppointmentPaymentConfiguration : IEntityTypeConfiguration<AppointmentPayment>
    {
        public void Configure(EntityTypeBuilder<AppointmentPayment> builder)
        {
            builder.ToTable("AppointmentPayment");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.IsSignal)
                .HasDefaultValue(false)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(e => e.DatePayment)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(e => e.Value)
                .HasColumnType("decimal(18, 2)");
            
            builder.Property(e => e.PaymentStatus)
                .IsRequired()
                .HasConversion<int>();

            builder.HasOne(e => e.Appointment)
                .WithMany(x => x.AppointmentPayments)
                .HasForeignKey(e => e.AppointmentId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasOne(e => e.PaymentMethod)
                .WithMany(x => x.AppointmentPayments)
                .HasForeignKey(e => e.PaymentMethodId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}