using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BE_SWP391_OnDemandTutor.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(a => a.UserId);

            builder.Property(a => a.Username).IsRequired().HasMaxLength(50);

            builder.Property(a => a.Password).IsRequired().HasMaxLength(100);

            builder.Property(a => a.ProfileImage).HasMaxLength(255);

            builder.Property(a => a.PhoneNumber).HasMaxLength(20);

            builder.Property(a => a.EmailAddress).IsRequired().HasMaxLength(100);

            builder.Property(a => a.DateOfBirth).IsRequired();

            builder.Property(a => a.Gender).HasMaxLength(50);

            builder.Property(a => a.Role).IsRequired().HasMaxLength(150);

            builder.Property(u => u.City).IsRequired().HasMaxLength(150);

            builder.Property(u => u.District).IsRequired().HasMaxLength(150);

            builder.Property(u => u.Ward).IsRequired().HasMaxLength(150);

            builder.Property(u => u.Street).IsRequired().HasMaxLength(150);

            builder.Property(u => u.TutorType).IsRequired().HasMaxLength(150);

            builder.Property(u => u.School).IsRequired().HasMaxLength(150);

            builder.Property(u => u.TutorDescription).HasColumnType("nvarchar(max)").IsRequired();

            builder.HasMany(u => u.StudentClasses).WithOne(c => c.Student).HasForeignKey(c => c.StudentId);
            
            builder.HasMany(u => u.TutorClasses).WithOne(c => c.Tutor).HasForeignKey(c => c.TutorId);

            builder.HasMany(u=>u.Feedbacks).WithOne(f=>f.Student).HasForeignKey(f=>f.StudentId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
