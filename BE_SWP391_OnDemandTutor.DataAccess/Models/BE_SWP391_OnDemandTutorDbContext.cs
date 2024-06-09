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
    public DbSet<Class> Classes { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Rate> Rates { get; set; }
    public DbSet<TutorDegree> TutorDegrees { get; set; }
    public DbSet<TutorDegree> BookingConfiguration { get; set; }

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
        modelBuilder.ApplyConfiguration(new ClassConfiguration());
        modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
        modelBuilder.ApplyConfiguration(new RateConfiguration());
        modelBuilder.ApplyConfiguration(new TutorDegreeConfiguration());
        modelBuilder.ApplyConfiguration(new BookingConfiguration());

        modelBuilder.Entity<Schedule>().HasData
            (new Schedule
            {
                ScheduleID = 1,
                Title = "Lịch học môn Toán",
                Description = "Lớp học môn Toán vào các ngày trong tuần",
                DateOfWeek = DayGroup.MonWedFri, // Thứ 2, 4, 6
                StartTime = new DateTime(2024, 6, 7, 8, 0, 0), // 8:00 AM
                EndTime = new DateTime(2024, 6, 7, 10, 0, 0), // 10:00 AM
            },
            new Schedule
            {
                ScheduleID = 2,
                Title = "Lịch học môn Văn",
                Description = "Lớp học môn Văn vào các ngày trong tuần",
                DateOfWeek = DayGroup.TueThuSat, // Thứ 3, 5, 7
                StartTime = new DateTime(2024, 6, 8, 9, 0, 0), // 9:00 AM
                EndTime = new DateTime(2024, 6, 8, 11, 0, 0), // 11:00 AM
            }
            );
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
                     Role = "Student",
                     City = "New York",
                     District = "Manhattan",
                     Ward = 'A',
                     Street = 'B',
                     TutorType = 'A',
                     School = 'C',
                     TutorDescription = "Experienced in mathematics tutoring."
                 },
    new User
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
        City = "Los Angeles",
        District = "Hollywood",
        Ward = 'C',
        Street = 'D',
        TutorType = 'B',
        School = 'D',
        TutorDescription = "Specializes in English and literature."
    },
    new User
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
        City = "Chicago",
        District = "Downtown",
        Ward = 'B',
        Street = 'A',
        TutorType = 'C',
        School = 'A',
        TutorDescription = "Interested in science and technology."
    },
    new User
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
        City = "San Francisco",
        District = "Bay Area",
        Ward = 'D',
        Street = 'C',
        TutorType = 'A',
        School = 'B',
        TutorDescription = "Provides tutoring in history and social studies."
    },
    new User
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
        City = "Seattle",
        District = "Downtown",
        Ward = 'A',
        Street = 'B',
        TutorType = 'B',
        School = 'C',
        TutorDescription = "Enjoys learning about languages and cultures."
    }
            );

        modelBuilder.Entity<Class>().HasData
            (
            new Class
            {
                ClassId = 1,
                ScheduleId = 1,
                ClassName = "Introduction to Programming",
                ClassTime = new DateTime(2023, 9, 1, 18, 30, 0),
                ClassInfo = "This course introduces the fundamental concepts of programming, including data types, control structures, and algorithms.",
                ClassRequire = "No prior programming experience required.",
                ClassAddress = "123 Main Street, Anytown USA",
                ClassMethod = "In-person",
                ClassLevel = "Beginner",
                ClassFee = 199.99f,
                StudentId = 1,
                TutorId = 3,
                Active= true,
                CreatedDate = new DateTime(2023, 7, 1, 18, 30, 0),
            },
            new Class
            {
                ClassId = 2,
                ScheduleId = 2,
                ClassName = "Advanced Data Structures",
                ClassTime = new DateTime(2023, 10, 15, 14, 0, 0),
                ClassInfo = "This course explores advanced data structures and their implementation in various programming languages.",
                ClassRequire = "Prerequisite: Data Structures and Algorithms",
                ClassAddress = "456 Oak Avenue, Anytown USA",
                ClassMethod = "Online",
                ClassLevel = "Advanced",
                ClassFee = 299.99f,
                StudentId = 2,
                TutorId = 4,
                Active = false,
                CreatedDate = new DateTime(2023, 7, 1, 18, 30, 0),
            }
            );
      
    }
}
