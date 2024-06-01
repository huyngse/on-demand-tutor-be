using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_SWP391_OnDemandTutor.DataAccess.Configurations
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedbacks");

            builder.HasKey(f => f.FeedbackID);

            builder.Property(f => f.Evaluation).IsRequired();

            builder.Property(f => f.CreateDate).IsRequired();

            builder.HasOne(r => r.Student).WithMany(u => u.StudentGivenFeedbacks).HasForeignKey(u => u.StudentId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.Tutor).WithMany(u => u.TutorReceiveFeedbacks).HasForeignKey(u => u.TutorId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(f=>f.Slot).WithOne(s=>s.Feedback).HasForeignKey<Feedback>(f=>f.SlotId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
