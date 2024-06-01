using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_SWP391_OnDemandTutor.DataAccess.Configurations
{
    public class TutorFreeTimeScheduleConfiguration : IEntityTypeConfiguration<TutorFreeTimeSchedule>
    {
        public void Configure(EntityTypeBuilder<TutorFreeTimeSchedule> builder)
        {
            builder.ToTable("TutorFreeTimeSchedules");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.StartTime).IsRequired().HasColumnType("time");

            builder.Property(t => t.EndTimeTime).IsRequired().HasColumnType("time");

            builder.Property(t => t.DateOfWeek).IsRequired().HasMaxLength(50);

            builder.Property(t => t.Status).IsRequired();

            builder.Property(t => t.TutorId).IsRequired();

            builder.HasOne(t => t.Tutor).WithOne(u => u.TutorFreeTimeSchedule).HasForeignKey<TutorFreeTimeSchedule>(t => t.TutorId);
                
        }
    }
}
