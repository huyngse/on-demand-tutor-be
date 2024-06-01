using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_SWP391_OnDemandTutor.DataAccess.Configurations
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Classes");

            builder.HasKey(c => c.ClassId);

            builder.Property(c => c.ClassName).HasMaxLength(100).IsRequired();

            builder.Property(c => c.ClassTime).HasColumnType("datetime2").IsRequired();

            builder.Property(c => c.ClassInfo).HasMaxLength(500).IsRequired();

            builder.Property(c => c.ClassRequire).HasMaxLength(200).IsRequired();

            builder.Property(c => c.ClassAddress).HasMaxLength(200).IsRequired();

            builder.Property(c => c.ClassMethod).HasMaxLength(50).IsRequired();

            builder.Property(c => c.ClassLevel).HasMaxLength(50).IsRequired();

            builder.Property(c => c.ClassFee).HasColumnType("decimal(18,2)").HasDefaultValue(0.0m).IsRequired();

            builder.HasOne(c => c.Student).WithOne().HasForeignKey<Class>(c => c.StudentId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Tutor).WithOne().HasForeignKey<Class>(c => c.TutorId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
