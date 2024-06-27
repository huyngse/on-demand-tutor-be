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
                    FullName = "Nguyễn Văn Phát",
                    ProfileImage = "https://i.pinimg.com/736x/2e/22/ef/2e22ef4d59cc9f1cb8ef31d113a4c46b.jpg",
                    PhoneNumber = "0983827216",
                    EmailAddress = "phatnv28212@gmail.com",
                    DateOfBirth = new DateTime(2005, 6, 15),
                    IsActive = true,
                    Gender = "Male",
                    Role = "Student",
                    City = "Thành phố Hồ Chí Minh",
                    District = "Quận 1",
                    Ward = "Phường Nguyễn Thái Bình",
                    Street = "Phường Nguyễn Thái Bình, Quận 1, Hồ Chí Minh, Việt Nam",
                    TutorType = "",
                    School = "",
                    TutorDescription = ""
                },

                // 2. Student
                new User
                {
                    UserId = 2,
                    Username = "student2",
                    Password = "student2",
                    FullName = "Trần Tấn Lộc",
                    IsActive = true,
                    ProfileImage = "https://i.pinimg.com/736x/5e/6c/57/5e6c572eed026b75f81682e02f83a983.jpg",
                    PhoneNumber = "0983337417",
                    EmailAddress = "loctt227211@gmail.com",
                    DateOfBirth = new DateTime(2005, 3, 10),
                    Gender = "Male",
                    Role = "Student",
                    City = "Thành phố Hồ Chí Minh",
                    District = "Quận 1",
                    Ward = "Phường Cầu Ông Lãnh",
                    Street = "463 Chợ Cầu Muối",
                    TutorType = "",
                    School = "",
                    TutorDescription = ""
                },

                // 3. Student
                new User
                {
                    UserId = 3,
                    Username = "student3",
                    Password = "student3",
                    FullName = "Trần Thị Mĩ Dung",
                    IsActive = true,
                    ProfileImage = "https://fn.vinhphuc.edu.vn/UploadImages/thptngogiatu/admin/2017_10/thu%2030.JPG?w=700",
                    PhoneNumber = "0981039112",
                    EmailAddress = "dungttm2928@gmail.com",
                    DateOfBirth = new DateTime(2004, 11, 20),
                    Gender = "Female",
                    Role = "Student",
                    City = "Thành phố Hồ Chí Minh",
                    District = "Quận Thủ Đức",
                    Ward = "Phường Tam Bình",
                    Street = "73 Đường số 10",
                    TutorType = "",
                    School = "",
                    TutorDescription = ""
                },

                // 4. Tutor
                new User
                {
                    UserId = 4,
                    Username = "tutor1",
                    Password = "tutor1",
                    FullName = "Nguyễn Gia Cát",
                    IsActive = true,
                    ProfileImage = "https://d3.violet.vn/uploads/previews/document/1/254/601/anh_4X6_Binh.jpg.jpg",
                    PhoneNumber = "0988136713",
                    EmailAddress = "catng1111@gmail.com",
                    DateOfBirth = new DateTime(1990, 8, 5),
                    Gender = "Male",
                    Role = "Tutor",
                    City = "Thành phố Hồ Chí Minh",
                    District = "Quận Thủ Đức",
                    Ward = "Phường Tam Phú",
                    Street = "162/6 Đường Cây Keo",
                    TutorType = "Người đi làm",
                    School = "Trường ĐH Khoa học xã hội và nhân văn",
                    TutorDescription = "<p>Là một gia sư, tôi đã có nhiều năm kinh nghiệm trong việc hướng dẫn và hỗ trợ học sinh. Tôi có kiến thức sâu rộng về nhiều lĩnh vực như toán học, khoa học, văn học, và các môn học khác. Mục tiêu của tôi là giúp các em học sinh phát triển kiến thức, kỹ năng, và khả năng tư duy một cách toàn diện.</p><p><br></p><p>Tôi luôn cố gắng tìm hiểu từng học sinh một cách cẩn thận, để có thể thiết kế chương trình học phù hợp với nhu cầu và sở thích của các em. Tôi sử dụng các phương pháp giảng dạy linh hoạt, kết hợp giữa lý thuyết và thực hành, giúp các em dễ dàng tiếp thu và vận dụng kiến thức.</p><p><br></p><p>Ngoài ra, tôi còn rất quan tâm đến sự phát triển toàn diện của các em, bao gồm cả về mặt tư duy, kỹ năng mềm, và định hướng nghề nghiệp. Tôi sẵn sàng lắng nghe, tư vấn, và hỗ trợ các em trong mọi khía cạnh của cuộc sống.</p>"
                },

                // 5. Tutor
                new User
                {
                    UserId = 5,
                    Username = "tutor2",
                    Password = "tutor2",
                    FullName = "Lê Thị Hồng Nhi",
                    ProfileImage = "https://tiemanhsky.com/wp-content/uploads/2020/03/61103071_2361422507447925_6222318223514140672_n_1.jpg",
                    PhoneNumber = "0983555233",
                    EmailAddress = "nhilth84@gmail.com",
                    DateOfBirth = new DateTime(1992, 2, 28),
                    IsActive = true,
                    Gender = "Female",
                    Role = "Tutor",
                    City = "Thành phố Hồ Chí Minh",
                    District = "Quận Gò Vấp",
                    Ward = "Phường 12",
                    Street = "56 Hẻm 256 Phan Huy Ích",
                    TutorType = "Giáo viên",
                    School = "Trường ĐH Sư phạm Kỹ thuật TPHCM",
                    TutorDescription = "Enjoys learning about languages and cultures."
                },

                new
                {
                    UserId = 6,
                    Username = "admin",
                    Password = "admin",
                    FullName = "Leo Dinh",
                    IsActive = true,
                    ProfileImage = "https://t4.ftcdn.net/jpg/06/91/91/33/360_F_691913391_7m6zaKwCNeec23ECP6gG518x9jxwM8UV.jpg",
                    PhoneNumber = "0941715212",
                    EmailAddress = "johndoe@gmail.com",
                    DateOfBirth = new DateTime(2003, 5, 15),
                    Gender = "Male",
                    Role = "Administrator",
                    City = "Thành phố Hồ Chí Minh",
                    District = "Quận Thủ Đức",
                    Ward = "Phường Long Thạnh Mỹ",
                    Street = "Đường D1",
                    TutorType = "",
                    School = "",
                    TutorDescription = ""
                }

            );

        modelBuilder.Entity<Class>().HasData
            (
            new Class
            {
                ClassId = 1,
                ClassName = "Introduction to Programming",
                ClassInfo = "This course introduces the fundamental concepts of programming, including data types, control structures, and algorithms.",
                ClassRequire = "No prior programming experience required.",
                ClassMethod = "In-person",
                ClassLevel = "Beginner",
                ClassFee = 1200000,
                City = "Thành phố Hồ Chí Minh",
                TutorId = 4,
                Ward = "Phường Tam Phú",
                District = "Quận Thủ Đức",
                Active = true,
                CreatedDate = new DateTime(2023, 7, 1, 18, 30, 0),
            },
            new Class
            {
                ClassId = 2,
                ClassName = "Advanced Data Structures",
                ClassInfo = "This course explores advanced data structures and their implementation in various programming languages.",
                ClassRequire = "Prerequisite: Data Structures and Algorithms",
                ClassMethod = "Online",
                ClassLevel = "Beginner",
                ClassFee = 750000,
                City = "Thành phố Hồ Chí Minh",
                TutorId = 5,
                Ward = "Phường 12",
                District = "Quận Gò Vấp",
                Active = false,
                CreatedDate = new DateTime(2023, 7, 1, 18, 30, 0),
            },
            new Class
            {
                ClassId = 3,
                ClassName = "Lập trình Java cơ bản",
                ClassInfo = "Khóa học giới thiệu các khái niệm cơ bản của ngôn ngữ lập trình Java",
                ClassRequire = "Không yêu cầu kiến thức lập trình trước đó",
                ClassMethod = "In-person",
                ClassLevel = "Cơ bản",
                CreatedDate = new DateTime(2023, 5, 15),
                City = "Thành phố Hồ Chí Minh",
                District = "Quận Thủ Đức",
                Ward = "Phường Tam Phú",
                TutorId = 4,
                Active = true,
                ClassFee = 500000
            },
            new Class
            {
                ClassId = 4,
                ClassName = "Lập trình React.js nâng cao",
                ClassInfo = "Khóa học giới thiệu các kỹ thuật nâng cao trong việc xây dựng ứng dụng web với React.js",
                ClassRequire = "Có kiến thức lập trình Javascript và React.js cơ bản",
                ClassMethod = "Trực tuyến",
                ClassLevel = "Nâng cao",
                CreatedDate = new DateTime(2023, 6, 1),
                TutorId = 5,
                City = "Thành phố Hồ Chí Minh",
                District = "Quận Gò Vấp",
                Ward = "Phường 12",
                Active = true,
                ClassFee = 800000
            },
            new Class
            {
                ClassId = 5,
                ClassName = "Lập trình C# cơ bản",
                ClassInfo = "Khóa học giới thiệu các khái niệm cơ bản của ngôn ngữ lập trình C#",
                ClassRequire = "Không yêu cầu kiến thức lập trình trước đó",
                ClassMethod = "In-person",
                ClassLevel = "Cơ bản",
                CreatedDate = new DateTime(2023, 7, 20),
                City = "Thành phố Hồ Chí Minh",
                TutorId = 4,
                District = "Quận Thủ Đức",
                Ward = "Phường Tam Phú",
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
        modelBuilder.Entity<Booking>().HasData(
                 new Booking
                 {
                     BookingId = 1,
                     UserId = 1,
                     ScheduleId = 1,
                     CreateDate = new DateTime(2024, 6, 8, 9, 0, 0),
                     StartDate = new DateTime(2024, 6, 8, 9, 0, 0),
                     EndDate = new DateTime(2024, 10, 8, 9, 0, 0),
                     Description = "Con tôi đang gặp khó khăn trong việc học lập trình. Tôi muốn mời Thầy đến dạy thêm cho con tôi, để giúp con cải thiện và tiến bộ hơn trong môn này.\r\n\r\nCon tôi năng động và rất ham học hỏi, nhưng vẫn còn nhiều vấn đề cần phải khắc phục trong lập trình. Tôi nghĩ rằng sự hướng dẫn của Thầy sẽ rất hữu ích cho con.\r\n\r\nChúng tôi có thể thảo luận về lịch trình, địa điểm và các chi tiết khác. Tôi rất mong được sự giúp đỡ của Thầy để con tôi có thể vượt qua khó khăn và tiến bộ hơn trong lập trình.",
                     Status = "Pending",
                     Address = "17-13 Đ. Số 40, Linh Đông, Thủ Đức"
                 }
            );
    }
}
