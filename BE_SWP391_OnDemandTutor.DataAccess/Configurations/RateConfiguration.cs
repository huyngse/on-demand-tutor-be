using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_SWP391_OnDemandTutor.DataAccess.Configurations
{
    public class RateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.ToTable("Rates");

            builder.HasKey(r=>r.RatingId);

            builder.Property(r=>r.NumberStars).IsRequired().HasColumnType("integer");

            builder.HasOne(r => r.Student).WithMany(u => u.StudentSendRatings).HasForeignKey(u => u.StudentId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.Tutor).WithMany(u => u.TutorReceiveRatings).HasForeignKey(u => u.TutorId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r=>r.Subject).WithOne(s=>s.Rate).HasForeignKey<Rate>(r=>r.SubjectId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
