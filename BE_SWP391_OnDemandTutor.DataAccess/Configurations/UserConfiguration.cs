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

            builder.Property(a => a.Role).IsRequired().HasMaxLength(50);
        }
    }
}
