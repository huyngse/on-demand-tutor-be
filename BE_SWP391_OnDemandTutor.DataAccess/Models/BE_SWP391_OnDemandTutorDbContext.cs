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
    public DbSet<Class> Classes { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Rate> Rates { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<TutorDegree> TutorDegrees { get; set; }
    public DbSet<Booking> Booking { get; set; }

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
        modelBuilder.ApplyConfiguration(new ClassConfiguration());
        modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
        modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
        modelBuilder.ApplyConfiguration(new RateConfiguration());
        modelBuilder.ApplyConfiguration(new TutorDegreeConfiguration());
        modelBuilder.ApplyConfiguration(new BookingConfiguration());


        modelBuilder.Entity<User>().HasData
            (
                // 1. Student
                new User
                {
                    UserId = 1,
                    Username = "student1",
                    Password = "student1",
                    FullName = " Leo Dinh",
                    ProfileImage = "https://example.com/profile_image_1.jpg",
                    PhoneNumber = "555-1234",
                    EmailAddress = "john.doe@example.com",
                    DateOfBirth = new DateTime(1985, 6, 15),
                    IsActive = true,
                    Gender = "Male",
                    Role = "Student",
                    City = "New York",
                    District = "Manhattan",
                    Ward = "A",
                    Street = "B",
                    TutorType = "A",
                    School = "C",
                    TutorDescription = "Experienced in mathematics tutoring."
                },

                // 2. Student
                new User
                {
                    UserId = 2,
                    Username = "student2",
                    Password = "student2",
                    FullName = " Leo Dinh",
                    IsActive = true,
                    ProfileImage = "https://example.com/profile_image_2.jpg",
                    PhoneNumber = "555-5678",
                    EmailAddress = "jane.doe@example.com",
                    DateOfBirth = new DateTime(1992, 3, 10),
                    Gender = "Female",
                    Role = "Student",
                    City = "Los Angeles",
                    District = "Hollywood",
                    Ward = "C",
                    Street = "D",
                    TutorType = "B",
                    School = "D",
                    TutorDescription = "Specializes in English and literature."
                },

                // 3. Student
                new User
                {
                    UserId = 3,
                    Username = "student3",
                    Password = "student3",
                    FullName =" Leo Dinh",
                    IsActive = true,
                    ProfileImage = "https://example.com/profile_image_3.jpg",
                    PhoneNumber = "555-9012",
                    EmailAddress = "bob.smith@example.com",
                    DateOfBirth = new DateTime(1978, 11, 20),
                    Gender = "Male",
                    Role = "Student",
                    City = "Chicago",
                    District = "Downtown",
                    Ward = "B",
                    Street = "A",
                    TutorType = "C",
                    School = "A",
                    TutorDescription = "Interested in science and technology."
                },

                // 4. Tutor
                new User
                {
                    UserId = 4,
                    Username = "tutor1",
                    Password = "tutor1",
                    FullName = " Leo Dinh",
                    IsActive = true,
                    ProfileImage = "https://example.com/profile_image_4.jpg",
                    PhoneNumber = "555-3456",
                    EmailAddress = "sarah.johnson@example.com",
                    DateOfBirth = new DateTime(1990, 8, 5),
                    Gender = "Female",
                    Role = "Tutor",
                    City = "San Francisco",
                    District = "Bay Area",
                    Ward = "D",
                    Street = "C",
                    TutorType = "A",
                    School = "B",
                    TutorDescription = "Provides tutoring in history and social studies."
                },

                // 5. Tutor
                new User
                {
                    UserId = 5,
                    Username = "tutor2",
                    Password = "tutor2",
                    FullName = " Leo Dinh",
                    ProfileImage = "https://example.com/profile_image_5.jpg",
                    PhoneNumber = "555-7890",
                    EmailAddress = "michael.davis@example.com",
                    DateOfBirth = new DateTime(1982, 2, 28),
                    IsActive = true,
                    Gender = "Male",
                    Role = "Tutor",
                    City = "Seattle",
                    District = "Downtown",
                    Ward = "A",
                    Street = "B",
                    TutorType = "B",
                    School = "C",
                    TutorDescription = "Enjoys learning about languages and cultures."
                },

                new
                {
                    UserId = 6,
                    Username = "admin",
                    Password = "admin",
                    FullName = " Leo Dinh",
                    IsActive = true,
                    ProfileImage = "profile.jpg",
                    PhoneNumber = "555-1234",
                    EmailAddress = "johndoe@example.com",
                    DateOfBirth = new DateTime(1990, 5, 15),
                    Gender = "Male",
                    Role = "Administrator",
                    City = "Anytown",
                    District = "Central",
                    Ward = "Downtown",
                    Street = "123 Main St",
                    TutorType = "Mathematics",
                    School = "University of Anytown",
                    TutorDescription = "I have 5 years of experience teaching mathematics to students of all levels."
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
                City = "LA",
                StudentId = 1,
                TutorId = 4,
                Ward = "Go vap",
                District = "Downtown",
                Active = true,
                CreatedDate = new DateTime(2023, 7, 1, 18, 30, 0),
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
                City = "LA",
                StudentId = 1,
                TutorId = 5,
                Ward = "Go vap",
                District = "Downtown",
                Active = false,
                CreatedDate = new DateTime(2023, 7, 1, 18, 30, 0),
            },
            new Class
            {
                ClassId = 3,
                ClassName = "Lập trình Java cơ bản",
                ClassTime = new DateTime(2023, 6, 1, 19, 0, 0),
                ClassInfo = "Khóa học giới thiệu các khái niệm cơ bản của ngôn ngữ lập trình Java",
                ClassRequire = "Không yêu cầu kiến thức lập trình trước đó",
                ClassAddress = "123 Đường A, Quận 1, TP.HCM",
                ClassMethod = "Trực tiếp",
                ClassLevel = "Cơ bản",
                CreatedDate = new DateTime(2023, 5, 15),
                City = "TP.HCM",
                District = "Quận 1",
                Ward = "Phường A",
                StudentId = 2,
                TutorId = 4,
                Active = true,
                ClassFee = 500000
            },
            new Class
            {
                ClassId = 4,
                ClassName = "Lập trình React.js nâng cao",
                ClassTime = new DateTime(2023, 7, 1, 9, 0, 0),
                ClassInfo = "Khóa học giới thiệu các kỹ thuật nâng cao trong việc xây dựng ứng dụng web với React.js",
                ClassRequire = "Có kiến thức lập trình Javascript và React.js cơ bản",
                ClassAddress = "456 Đường B, Quận 3, TP.HCM",
                ClassMethod = "Trực tuyến",
                ClassLevel = "Nâng cao",
                CreatedDate = new DateTime(2023, 6, 1),
                StudentId = 2,
                TutorId = 5,
                City = "TP.HCM",
                District = "Quận 3",
                Ward = "Phường B",
                Active = true,
                ClassFee = 800000
            },
            new Class
            {
                ClassId = 5,
                ClassName = "Lập trình C# cơ bản",
                ClassTime = new DateTime(2023, 8, 15, 14, 0, 0),
                ClassInfo = "Khóa học giới thiệu các khái niệm cơ bản của ngôn ngữ lập trình C#",
                ClassRequire = "Không yêu cầu kiến thức lập trình trước đó",
                ClassAddress = "789 Đường C, Quận 5, TP.HCM",
                ClassMethod = "Trực tiếp",
                ClassLevel = "Cơ bản",
                CreatedDate = new DateTime(2023, 7, 20),
                City = "TP.HCM",
                StudentId = 3,
                TutorId = 4,
                District = "Quận 5",
                Ward = "Phường C",
                Active = true,
                ClassFee = 400000
            }
            );
        modelBuilder.Entity<Schedule>().HasData
          (
            new Schedule
            {
                ScheduleID = 1,
                ClassID = 1,
                Title = "Lịch học môn Toán",
                Description = "Lớp học môn Toán vào các ngày trong tuần",
                DateOfWeek = DayGroup.MonWedFri, // Thứ 2, 4, 6
                StartTime = new DateTime(2024, 6, 7, 8, 0, 0), // 8:00 AM
                EndTime = new DateTime(2024, 6, 7, 10, 0, 0), // 10:00 AM
            },
          new Schedule
          {
              ScheduleID = 2,
              ClassID = 2,
              Title = "Lịch học môn Văn",
              Description = "Lớp học môn Văn vào các ngày trong tuần",
              DateOfWeek = DayGroup.TueThuSat, // Thứ 3, 5, 7
              StartTime = new DateTime(2024, 6, 8, 9, 0, 0), // 9:00 AM
              EndTime = new DateTime(2024, 6, 8, 11, 0, 0), // 11:00 AM
          }
          );

    }
}
