using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Street)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.Property(e => e.ZipCode)
                .IsRequired(false)
                .HasMaxLength(20);
            
            builder.Property(e => e.StreetNumber)
                .IsRequired(false)
                .HasMaxLength(10);
            
            builder.Property(e => e.District)
                .IsRequired(false)
                .HasMaxLength(255);
            
            builder.Property(e => e.City)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.Property(e => e.State)
                .IsRequired(false)
                .HasMaxLength(255);
        }
    }
}