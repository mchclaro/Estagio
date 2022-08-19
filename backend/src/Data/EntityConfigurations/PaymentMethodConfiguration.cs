using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    internal class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("PaymentMethod");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired(false)
                .HasMaxLength(255);
            
             builder.Property(e => e.Description)
                .IsRequired(false)
                .HasColumnType("nvarchar(max)");
        }
    }
}