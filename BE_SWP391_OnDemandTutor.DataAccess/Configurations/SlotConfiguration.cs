using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_SWP391_OnDemandTutor.DataAccess.Configurations
{
    public class SlotConfiguration : IEntityTypeConfiguration<Slot>
    {
        public void Configure(EntityTypeBuilder<Slot> builder)
        {
            builder.ToTable("Slots");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Description).IsRequired();

            builder.Property(s => s.StartTime).IsRequired();

            builder.Property(s => s.EndTime).IsRequired();

            builder.Property(s => s.ClassId).IsRequired();

            builder.HasOne(s => s.Class).WithOne(c => c.Slot).HasForeignKey<Slot>(s => s.ClassId);

            builder.HasOne(s => s.Subject).WithOne(c => c.Slot).HasForeignKey<Slot>(s => s.SubjectId);

            builder.HasOne(s => s.Schedule).WithOne(c => c.Slot).HasForeignKey<Slot>(s => s.ScheduleId);

        }
    }
}
