using System;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_SWP391_OnDemandTutor.DataAccess.Configurations
{
	public class BookingConfiguration  : IEntityTypeConfiguration<Booking>
        
	{
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking");

            builder.HasKey(c => c.BookingId);

            builder.Property(c => c.CreateDate).HasColumnType("datetime2").IsRequired();

            builder.Property(c => c.Description).HasMaxLength(500).IsRequired();

            builder.Property(c => c.TutorId).HasMaxLength(50).IsRequired();

            builder.Property(c => c.Status).HasMaxLength(50).IsRequired();

            builder.Property(c => c.Address).HasMaxLength(150).IsRequired();

            builder.HasOne(b => b.User).WithMany(u => u.Bookings).HasForeignKey(b => b.UserId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(b => b.Schedule).WithMany(u => u.Bookings).HasForeignKey(b => b.ScheduleId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}

