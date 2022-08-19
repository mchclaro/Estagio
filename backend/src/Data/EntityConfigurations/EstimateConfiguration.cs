using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    internal class EstimateConfiguration : IEntityTypeConfiguration<Estimate>
    {
        public void Configure(EntityTypeBuilder<Estimate> builder)
        {
            builder.ToTable("Estimate");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Service)
                .IsRequired(false)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.Description)
                .IsRequired(false)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.Value)
                .HasColumnType("decimal(18, 2)");
            
            builder.Property(e => e.CreatedDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(e => e.ValidateDate)
                .IsRequired()
                .HasColumnType("datetime");
            
            builder.HasOne(e => e.Client)
                .WithMany(x => x.Estimates)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}