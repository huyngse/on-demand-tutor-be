using BE_SWP391_OnDemandTutor.DataAccess.Configurations;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class BE_SWP391_OnDemandTutorDbContext : DbContext
{
    public BE_SWP391_OnDemandTutorDbContext()
    {

    }
    public BE_SWP391_OnDemandTutorDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Slot> Slots { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Rate> Rates { get; set; }
    public DbSet<TutorDegree> TutorDegrees { get; set; }
    public DbSet<TutorFreeTimeSchedule> TutorFreeTimeSchedules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string root = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName;
        string apiDirectory = Path.Combine(root, "BE_SWP391_OnDemandTutor.API");
        var configuration = new ConfigurationBuilder()
            .SetBasePath(apiDirectory)
            .AddJsonFile("appsettings.Development.json")
            .Build();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
        modelBuilder.ApplyConfiguration(new SlotConfiguration());
        modelBuilder.ApplyConfiguration(new ClassConfiguration());
        modelBuilder.ApplyConfiguration(new SubjectConfiguration());
        modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
        modelBuilder.ApplyConfiguration(new RateConfiguration());
        modelBuilder.ApplyConfiguration(new TutorDegreeConfiguration());
        modelBuilder.ApplyConfiguration(new TutorFreeTimeScheduleConfiguration());


        modelBuilder.Entity<User>().HasData
            (
                new User
                {
                    UserId = 1,
                    Username = "JohnDoe",
                    Password = "password123",
                    ProfileImage = "https://example.com/profile_image_1.jpg",
                    PhoneNumber = "555-1234",
                    EmailAddress = "john.doe@example.com",
                    DateOfBirth = new DateTime(1985, 6, 15),
                    Gender = "Male",
                    Role = "Student"
                }, new User
                {
                    UserId = 2,
                    Username = "JaneDoe",
                    Password = "securepassword",
                    ProfileImage = "https://example.com/profile_image_2.jpg",
                    PhoneNumber = "555-5678",
                    EmailAddress = "jane.doe@example.com",
                    DateOfBirth = new DateTime(1992, 3, 10),
                    Gender = "Female",
                    Role = "Student",
                }, new User
                {
                    UserId = 3,
                    Username = "BobSmith",
                    Password = "mypassword456",
                    ProfileImage = "https://example.com/profile_image_3.jpg",
                    PhoneNumber = "555-9012",
                    EmailAddress = "bob.smith@example.com",
                    DateOfBirth = new DateTime(1978, 11, 20),
                    Gender = "Male",
                    Role = "Tutor",
                }, new User
                {
                    UserId = 4,
                    Username = "SarahJohnson",
                    Password = "strongpassword",
                    ProfileImage = "https://example.com/profile_image_4.jpg",
                    PhoneNumber = "555-3456",
                    EmailAddress = "sarah.johnson@example.com",
                    DateOfBirth = new DateTime(1990, 8, 5),
                    Gender = "Female",
                    Role = "Tutor",
                }, new User
                {
                    UserId = 5,
                    Username = "MichaelDavis",
                    Password = "123456789",
                    ProfileImage = "https://example.com/profile_image_5.jpg",
                    PhoneNumber = "555-7890",
                    EmailAddress = "michael.davis@example.com",
                    DateOfBirth = new DateTime(1982, 2, 28),
                    Gender = "Male",
                    Role = "Student",
                }
            );

        modelBuilder.Entity<Class>().HasData
            (
            new Class
            {
                ClassId = 1,
                ClassName = "Introduction to Programming",
                ClassTime = new DateTime(2023, 9, 1, 18, 30, 0),
                ClassInfo = "This course introduces the fundamental concepts of programming, including data types, control structures, and algorithms.",
                ClassRequire = "No prior programming experience required.",
                ClassAddress = "123 Main Street, Anytown USA",
                ClassMethod = "In-person",
                ClassLevel = "Beginner",
                ClassFee = 199.99f,
                StudentId = 1,
                TutorId = 3
            },
            new Class
            {
                ClassId = 2,
                ClassName = "Advanced Data Structures",
                ClassTime = new DateTime(2023, 10, 15, 14, 0, 0),
                ClassInfo = "This course explores advanced data structures and their implementation in various programming languages.",
                ClassRequire = "Prerequisite: Data Structures and Algorithms",
                ClassAddress = "456 Oak Avenue, Anytown USA",
                ClassMethod = "Online",
                ClassLevel = "Advanced",
                ClassFee = 299.99f,
                StudentId = 2,
                TutorId = 4

            }
            );
    }
}
