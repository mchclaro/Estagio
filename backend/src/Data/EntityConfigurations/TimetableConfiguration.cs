using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    internal class TimetableConfiguration : IEntityTypeConfiguration<Timetable>
    {
        public void Configure(EntityTypeBuilder<Timetable> builder)
        {
            builder.ToTable("Timetable");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Start)
                .IsRequired()
                .HasColumnType("decimal(20,0)");

            builder.Property(e => e.End)
                .IsRequired()
                .HasColumnType("decimal(20,0)");

            builder.Property(e => e.Break)
                .IsRequired()
                .HasColumnType("decimal(20,0)");
            
            builder.Property(e => e.DayOfWeek)
                .IsRequired()
                .HasConversion<int>();
            
            builder.HasOne(e => e.User)
                .WithMany(x => x.Timetables)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}