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
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects");

            builder.HasKey(s => s.SubjectId);

            builder.Property(s => s.SubjectName).IsRequired().HasMaxLength(100);

            builder.Property(s => s.Description).HasMaxLength(500);

            builder.HasOne(s => s.Rate).WithOne(r => r.Subject).HasForeignKey<Rate>(r => r.SubjectId);
        }
    }
}
