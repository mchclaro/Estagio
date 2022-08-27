using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired(false)
                .HasMaxLength(255);
            
            builder.Property(e => e.Phone)
                .IsRequired(false)
                .HasMaxLength(255);
            
            builder.Property(e => e.Email)
                .IsRequired(false)
                .HasMaxLength(255);
            
             builder.Property(e => e.Password)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.Property(e => e.PhotoUrl)
                .IsRequired(false)
                .HasColumnType("nvarchar(max)");
            
            builder.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValue(true)
                .HasColumnType("bit");
           
            builder.Property(e => e.Role)
                .IsRequired()
                .HasConversion<int>();

        }
    }
}