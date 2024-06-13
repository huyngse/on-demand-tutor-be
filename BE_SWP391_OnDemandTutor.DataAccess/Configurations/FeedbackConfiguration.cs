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

            builder.Property(f => f.Content).IsRequired();

            builder.HasOne(r => r.Student).WithMany(u => u.Feedbacks).HasForeignKey(u => u.StudentId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(f=>f.Class).WithOne(c=>c.Feedback).HasForeignKey<Feedback>(f=>f.ClassId).OnDelete(DeleteBehavior.NoAction);



        }
    }
}
