using System;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;


namespace BE_SWP391_OnDemandTutor.DataAccess.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API configurations can be added here if needed

            // Example of configuring a relationship
            modelBuilder.Entity<Parent>()
                .HasMany(p => p.Classes)
                .WithOne()
                .HasForeignKey(c => c.ClassID);

            modelBuilder.Entity<Tutor>()
                .HasMany(t => t.Classes)
                .WithOne(c => c.Tutor)
                .HasForeignKey(c => c.TutorID);

            modelBuilder.Entity<Tutor>()
                .HasMany(t => t.Feedbacks)
                .WithOne(f => f.Tutor)
                .HasForeignKey(f => f.TutorID);

            modelBuilder.Entity<Class>()
                .HasMany(c => c.Schedules)
                .WithOne(s => s.Class)
                .HasForeignKey(s => s.ClassID);

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Classes)
                .WithOne(c => c.Subject)
                .HasForeignKey(c => c.SubjectID);

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Schedules)
                .WithOne(sc => sc.Subject)
                .HasForeignKey(sc => sc.SubjectID);
        }
    }
}

