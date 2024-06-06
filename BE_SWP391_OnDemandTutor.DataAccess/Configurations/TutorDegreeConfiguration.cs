using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_SWP391_OnDemandTutor.DataAccess.Configurations
{
    public class TutorDegreeConfiguration : IEntityTypeConfiguration<TutorDegree>
    {
        public void Configure(EntityTypeBuilder<TutorDegree> builder)
        {
            builder.ToTable("TutorDegrees");

            builder.HasKey(td => td.DegreeId);

            builder.Property(td => td.DegreeName).IsRequired().HasMaxLength(100);

            builder.Property(td => td.Description).IsRequired().HasMaxLength(500);

            builder.Property(td => td.DegreeImageUrl).HasMaxLength(255);

            builder.Property(td => td.TutorId).IsRequired();

            builder.HasOne(td => td.Tutor).WithOne(u => u.TutorDegree).HasForeignKey<TutorDegree>(td => td.TutorId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
