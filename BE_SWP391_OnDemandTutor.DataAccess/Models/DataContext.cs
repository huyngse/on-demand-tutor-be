using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class DataContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Tutor> Tutors { get; set; }
    public DbSet<Parent> Parents { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<ClassParent> ClassParents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433; Database=fams-database; User=sa; Password=Khongbiet123; TrustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // One-to-One Relationships
        modelBuilder.Entity<Account>()
            .HasOne(a => a.Tutor)
            .WithOne(t => t.Account)
            .HasForeignKey<Tutor>(t => t.AccountID);

        modelBuilder.Entity<Account>()
            .HasOne(a => a.Parent)
            .WithOne(p => p.Account)
            .HasForeignKey<Parent>(p => p.AccountID);

        modelBuilder.Entity<Tutor>()
            .HasOne(t => t.Schedule)
            .WithOne(s => s.Tutor)
            .HasForeignKey<Schedule>(s => s.TutorID);

        modelBuilder.Entity<Schedule>()
            .HasOne(s => s.Subject)
            .WithOne(sub => sub.Schedule)
            .HasForeignKey<Subject>(sub => sub.ScheduleId);

        // One-to-Many Relationships
        //modelBuilder.Entity<Account>()
        //    .HasMany(a => a.Tutors)
        //    .WithOne(t => t.Account)
        //    .HasForeignKey(t => t.AccountID);

        //modelBuilder.Entity<Account>()
        //    .HasMany(a => a.Parents)
        //    .WithOne(p => p.Account)
        //    .HasForeignKey(p => p.AccountID);

        //modelBuilder.Entity<Tutor>()
        //    .HasMany(t => t.Classes)
        //    .WithOne(c => c.Tutor)
        //    .HasForeignKey(c => c.TutorID);

        modelBuilder.Entity<Class>()
            .HasMany(c => c.Schedules)
            .WithOne(s => s.Class)
            .HasForeignKey(s => s.ClassID);

        modelBuilder.Entity<Tutor>()
            .HasMany(t => t.Subjects)
            .WithOne(s => s.Tutor)
            .HasForeignKey(s => s.TutorID);

        modelBuilder.Entity<Parent>()
            .HasMany(p => p.Feedbacks)
            .WithOne(f => f.Parent)
            .HasForeignKey(f => f.StudentID);

        modelBuilder.Entity<Parent>().HasNoKey();
        // Many-to-Many Relationship between Class and Parent
        modelBuilder.Entity<ClassParent>()
            .HasKey(cp => new { cp.ClassId, cp.ParentId });

        modelBuilder.Entity<ClassParent>()
            .HasOne(cp => cp.Class)
            .WithMany(c => c.ClassParents)
            .HasForeignKey(cp => cp.ClassId);

        modelBuilder.Entity<ClassParent>()
            .HasOne(cp => cp.Parent)
            .WithMany(p => p.ClassParents)
            .HasForeignKey(cp => cp.ParentId);
    }
}