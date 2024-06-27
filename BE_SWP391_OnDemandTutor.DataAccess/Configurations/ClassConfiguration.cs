using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BE_SWP391_OnDemandTutor.DataAccess.Configurations
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Classes");

            builder.HasKey(c => c.ClassId);

            builder.Property(c => c.ClassName).HasMaxLength(100).IsRequired();


            builder.Property(c => c.ClassInfo).HasMaxLength(500).IsRequired();

            builder.Property(c => c.CreatedDate).HasColumnType("datetime2").IsRequired();

            builder.Property(c => c.Active).IsRequired();

            builder.Property(c => c.ClassRequire).HasMaxLength(200).IsRequired();

            builder.Property(c => c.ClassAddress).HasMaxLength(200).IsRequired();

            builder.Property(c => c.ClassMethod).HasMaxLength(50).IsRequired();

            builder.Property(c => c.ClassLevel).HasMaxLength(50).IsRequired();

            builder.Property(c => c.District).HasMaxLength(50).IsRequired();

            builder.Property(c => c.Ward).HasMaxLength(50).IsRequired();

            builder.Property(c => c.City).HasMaxLength(50).IsRequired();

            builder.Property(c => c.ClassFee).HasColumnType("decimal(18,2)").HasDefaultValue(0.0m).IsRequired();

            builder.HasOne(c => c.Student).WithMany(u => u.StudentClasses).HasForeignKey(c => c.StudentId).OnDelete(DeleteBehavior.Restrict); ;

            builder.HasOne(c => c.Tutor).WithMany(u => u.TutorClasses).HasForeignKey(c => c.TutorId).OnDelete(DeleteBehavior.Restrict); ;

            builder.HasMany(c => c.Schedules).WithOne(s=>s.Class).HasForeignKey(c => c.ClassID).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
