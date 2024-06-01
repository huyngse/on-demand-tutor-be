﻿using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_SWP391_OnDemandTutor.DataAccess.Configurations
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedules");

            builder.HasKey(s => s.ScheduleID);

            builder.Property(s => s.Title).IsRequired().HasMaxLength(200);

            builder.Property(s => s.Description).HasMaxLength(500);

            builder.Property(s => s.StartDate).IsRequired();

            builder.Property(s => s.EndDate).IsRequired();

            builder.Property(s => s.SlotId).IsRequired();
        }
    }
}
