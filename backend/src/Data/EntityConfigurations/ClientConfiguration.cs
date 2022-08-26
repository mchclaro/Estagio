using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.Property(e => e.Phone)
                .IsRequired(false)
                .HasMaxLength(255);
            
             builder.Property(e => e.PhotoUrl)
                .IsRequired(false)
                .HasColumnType("nvarchar(max)");
            
            builder.HasOne(e => e.Address)
                .WithMany(x => x.Clients)
                .HasForeignKey(e => e.AddressId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}