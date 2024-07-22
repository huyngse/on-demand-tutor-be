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

                new User
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
                },
                new User
                {
                    UserId = 7,
                    Username = "tutor3",
                    Password = "tutor3",
                    FullName = "Nguyễn Thị Hoa",
                    IsActive = true,
                    ProfileImage = "",
                    PhoneNumber = "0987654321",
                    EmailAddress = "nguyenthihoa@example.com",
                    DateOfBirth = new DateTime(1990, 5, 15),
                    Gender = "Female",
                    Role = "Tutor",
                    City = "Thành phố Hà Nội",
                    District = "Quận Hoàn Kiếm",
                    Ward = "Phường Hàng Bài",
                    Street = "Phố Hàng Bài",
                    TutorType = "Giáo viên",
                    School = "Đại học Quốc gia Hà Nội",
                    TutorDescription = "Tôi là giáo viên dạy Toán có kinh nghiệm nhiều năm. Tôi sẽ cung cấp các bài học bổ ích và hướng dẫn kỹ lưỡng để giúp học sinh đạt kết quả tốt."
                },
                new User
                {
                    UserId = 8,
                    Username = "tutor4",
                    Password = "tutor4",
                    FullName = "Trần Văn Minh",
                    IsActive = true,
                    ProfileImage = "",
                    PhoneNumber = "0912345678",
                    EmailAddress = "tranvanminh@example.com",
                    DateOfBirth = new DateTime(1985, 11, 20),
                    Gender = "Male",
                    Role = "Tutor",
                    City = "Thành phố Hồ Chí Minh",
                    District = "Quận 1",
                    Ward = "Phường Bến Nghé",
                    Street = "Đường Lê Lợi",
                    TutorType = "Giảng viên",
                    School = "Đại học Bách Khoa Thành Phố Hồ Chí Minh",
                    TutorDescription = "Tôi là giáo viên dạy Toán có kinh nghiệm nhiều năm. Tôi sẽ cung cấp các bài học bổ ích và hướng dẫn kỹ lưỡng để giúp học sinh đạt kết quả tốt."
                },
                new User
                {
                    UserId = 9,
                    Username = "tutor5",
                    Password = "tutor5",
                    FullName = "Lê Thị Thu Hà",
                    IsActive = true,
                    ProfileImage = "",
                    PhoneNumber = "0978563412",
                    EmailAddress = "lethithuha@example.com",
                    DateOfBirth = new DateTime(1992, 8, 05),
                    Gender = "Female",
                    Role = "Tutor",
                    City = "Thành phố Đà Nẵng",
                    District = "Quận Hải Châu",
                    Ward = "Phường Thạch Thang",
                    Street = "Đường Phan Châu Trinh",
                    TutorType = "Giảng viên",
                    School = "Đại học Đà Nẵng",
                    TutorDescription = "Tôi là giáo viên dạy Anh Văn với phương pháp giảng dạy hiện đại và tương tác. Tôi sẽ giúp học sinh cải thiện khả năng nghe, nói, đọc, viết một cách toàn diện."
                },
                new User
                {
                    UserId = 10,
                    Username = "tutor6",
                    Password = "tutor6",
                    FullName = "Ngô Văn Dũng",
                    IsActive = true,
                    ProfileImage = "",
                    PhoneNumber = "0987215643",
                    EmailAddress = "ngovanung@example.com",
                    DateOfBirth = new DateTime(1988, 3, 10),
                    Gender = "Male",
                    Role = "Tutor",
                    City = "Thành phố Cần Thơ",
                    District = "Quận Ninh Kiều",
                    Ward = "Phường An Khánh",
                    Street = "Đường Võ Văn Kiệt",
                    TutorType = "Chuyên gia",
                    School = "Đại học Cần Thơ",
                    TutorDescription = "Tôi là giáo viên dạy Sinh Học với kinh nghiệm nhiều năm. Tôi sẽ giúp học sinh hiểu sâu các khái niệm và ứng dụng chúng vào các bài tập thực hành."
                },
                new User
                {
                    UserId = 11,
                    Username = "tutor7",
                    Password = "tutor7",
                    FullName = "Phạm Thị Minh Châu",
                    IsActive = true,
                    ProfileImage = "",
                    PhoneNumber = "0932145687",
                    EmailAddress = "phamthiminhchau@example.com",
                    DateOfBirth = new DateTime(1995, 6, 25),
                    Gender = "Female",
                    Role = "Tutor",
                    City = "Tỉnh Thừa Thiên Huế",
                    District = "Thành phố Huế",
                    Ward = "Phường Phú Hội",
                    Street = "Đường Lê Lợi",
                    TutorType = "Người đi làm",
                    School = "Đại học Huế",
                    TutorDescription = "Tôi là giáo viên dạy Lịch Sử và Địa Lý với phương pháp giảng dạy sinh động và gắn với thực tiễn. Tôi sẽ giúp học sinh hiểu sâu về các sự kiện lịch sử và các đặc điểm địa lý của Việt Nam."
                },
                new User
                {
                    UserId = 12,
                    Username = "tutor8",
                    Password = "tutor8",
                    FullName = "Lê Văn Hưng",
                    IsActive = true,
                    ProfileImage = "",
                    PhoneNumber = "0965478321",
                    EmailAddress = "levanhung@example.com",
                    DateOfBirth = new DateTime(1990, 9, 18),
                    Gender = "Male",
                    Role = "Tutor",
                    City = "Tỉnh Lâm Đồng",
                    District = "Thành phố Đà Lạt",
                    Ward = "Phường 3",
                    Street = "Đường Xuân Hương",
                    TutorType = "Người đi làm",
                    School = "Đại học Đà Lạt",
                    TutorDescription = "Tôi là giáo viên dạy Tin Học với kiến thức chuyên sâu và kỹ năng sử dụng công nghệ. Tôi sẽ giúp học sinh nâng cao khả năng lập trình, xử lý dữ liệu và ứng dụng công nghệ vào các bài tập."
                },
                new User
                {
                    UserId = 13,
                    Username = "tutor9",
                    Password = "tutor9",
                    FullName = "Nguyễn Thị Kim Yến",
                    IsActive = true,
                    ProfileImage = "https://nguoinoitieng.tv/images/nnt/99/1/bd0s.jpg",
                    PhoneNumber = "0978456321",
                    EmailAddress = "nguyenthikimyen@example.com",
                    DateOfBirth = new DateTime(1993, 12, 1),
                    Gender = "Female",
                    Role = "Tutor",
                    City = "Tỉnh Khánh Hòa",
                    District = "Thành phố Nha Trang",
                    Ward = "Phường Lộc Thọ",
                    Street = "Đường Trần Phú",
                    TutorType = "Giảng viên",
                    School = "Đại học Nha Trang",
                    TutorDescription = "Tôi là giáo viên dạy Hóa Học với phương pháp giảng dạy cụ thể và thực hành nhiều. Tôi sẽ giúp học sinh nắm vững các khái niệm hóa học và áp dụng chúng vào giải bài tập."
                },
                new User
                {
                    UserId = 14,
                    Username = "tutor10",
                    Password = "tutor10",
                    FullName = "Trương Quốc Bảo",
                    IsActive = true,
                    ProfileImage = "https://godimedia.com.vn/wp-content/uploads/2021/04/AN_0969-768x512.jpg",
                    PhoneNumber = "0912365478",
                    EmailAddress = "truongquocbao@example.com",
                    DateOfBirth = new DateTime(1987, 4, 22),
                    Gender = "Male",
                    Role = "Tutor",
                    City = "Tỉnh Bình Định",
                    District = "Thành phố Quy Nhơn",
                    Ward = "Phường Trần Hưng Đạo",
                    Street = "Đường Nguyễn Tất Thành",
                    TutorType = "Giảng viên",
                    School = "Đại học Quy Nhơn",
                    TutorDescription = "Tôi là giáo viên dạy Văn Học với phương pháp giảng dạy sáng tạo và gắn với thực tiễn. Tôi sẽ giúp học sinh hiểu sâu về các tác phẩm văn học và áp dụng kỹ năng phân tích, sáng tạo văn bản."
                },
                new User
                {
                    UserId = 15,
                    Username = "tutor11",
                    Password = "tutor11",
                    FullName = "Nguyễn Thị Hồng Nhung",
                    IsActive = true,
                    ProfileImage = "",
                    PhoneNumber = "0981234567",
                    EmailAddress = "hongnhung@example.com",
                    DateOfBirth = new DateTime(1992, 5, 15),
                    Gender = "Female",
                    Role = "Tutor",
                    City = "Thành phố Hà Nội",
                    District = "Quận Hoàn Kiếm",
                    Ward = "Phường Hàng Bài",
                    Street = "Phố Hàng Bài",
                    TutorType = "Giáo viên",
                    School = "Đại học Quốc gia Hà Nội",
                    TutorDescription = "Tôi là một giáo viên có kinh nghiệm trong lĩnh vực Toán học và Khoa học Máy tính. Tôi đam mê giảng dạy và luôn nỗ lực để mang đến những bài học thú vị và hiệu quả cho các học sinh của mình."
                },
                new User
                {
                    UserId = 16,
                    Username = "tutor12",
                    Password = "tutor12",
                    FullName = "Trần Văn Minh",
                    IsActive = true,
                    ProfileImage = "",
                    PhoneNumber = "0912345678",
                    EmailAddress = "vanminh@example.com",
                    DateOfBirth = new DateTime(1988, 11, 10),
                    Gender = "Male",
                    Role = "Tutor",
                    City = "Thành phố Hồ Chí Minh",
                    District = "Quận 1",
                    Ward = "Phường Bến Nghé",
                    Street = "Đường Lê Lợi",
                    TutorType = "Giảng viên",
                    School = "Đại học Bách khoa Thành phố Hồ Chí Minh",
                    TutorDescription = "Tôi là một chuyên gia về Kỹ thuật Điện tử và Công nghệ Thông tin. Với nhiều năm kinh nghiệm giảng dạy, tôi cam kết sẽ mang đến cho các học sinh những bài học sáng tạo và có ích."
                },
                new User
                {
                    UserId = 17,
                    Username = "student3",
                    Password = "student3",
                    FullName = "Nguyễn Anh Thư",
                    ProfileImage = "",
                    PhoneNumber = "0723827216",
                    EmailAddress = "thuanh@gmail.com",
                    DateOfBirth = new DateTime(2006, 4, 25),
                    IsActive = true,
                    Gender = "Female",
                    Role = "Student",
                    City = "Tỉnh Bình Định",
                    District = "Thành phố Quy Nhơn",
                    Ward = "Phường Trần Hưng Đạo ",
                    Street = "Đường 2/9",
                    TutorType = "",
                    School = "",
                    TutorDescription = ""
                },
                new User
                {
                    UserId = 18,
                    Username = "student4",
                    Password = "student4",
                    FullName = "Phạm Việt Hoàng",
                    ProfileImage = "",
                    PhoneNumber = "0358297185",
                    EmailAddress = "pvh1801@gmail.com",
                    DateOfBirth = new DateTime(2003, 01, 18),
                    IsActive = true,
                    Gender = "Male",
                    Role = "Student",
                    City = "Tỉnh Bà Rịa Vũng Tàu",
                    District = "Thành phố Bà Rịa",
                    Ward = "Phường Thắng Nhất",
                    Street = "Đường Nguyễn Thiện Thuật",
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
                MeetingLink = "https://meet.google.com"
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
                MeetingLink = "https://meet.google.com"
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
                ClassFee = 500000,
                MeetingLink = "https://meet.google.com"
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
                ClassFee = 800000,
                MeetingLink = "https://meet.google.com"
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
                ClassFee = 400000,
                MeetingLink = "https://meet.google.com"
            },
            new Class
            {
                ClassId = 6,
                ClassName = "Khóa học Lịch sử và Địa ly cấp THPT",
                ClassInfo = "Khóa học giới thiệu cho các bạn trẻ về Lịch sử và Địa Lý cấp THPT",
                ClassRequire = "Không yêu cầu kiến thức lập trình trước đó",
                ClassMethod = "Trực tuyến",
                ClassLevel = "Cơ bản",
                CreatedDate = new DateTime(2023, 7, 25),
                City = "Tỉnh Thừa Thiên Huế",
                TutorId = 11,
                District = "Thành phố Huế",
                Ward = "Phường Phú Hội",
                Active = true,
                ClassFee = 250000,
                MeetingLink = "https://meet.google.com"
            },
            new Class
            {

                ClassId = 7,
                ClassName = "Tiếng anh cho người đi làm",
                ClassInfo = "Khóa học đào tạo và luyện tập những kĩ năng cần thiết trong công việc cho người đi làm",
                ClassRequire = "Yêu cầu kiến thức căn bản về Tiếng anh",
                ClassMethod = "In-person",
                ClassLevel = "Cơ bản",
                CreatedDate = new DateTime(2023, 7, 30),
                City = "Thành phố Đà Nẵng",
                TutorId = 9,
                District = "Quận Hải Châu",
                Ward = "Phường Thạch Thang",
                Active = true,
                ClassFee = 500000,
                MeetingLink = "https://meet.google.com"
            },
            new Class
            {

                ClassId = 8,
                ClassName = "Văn học đại cương",
                ClassInfo = "Khóa học giới thiệu về văn học trong nước và thế giới",
                ClassRequire = "Không yêu cầu kiến thức văn học trước đó",
                ClassMethod = "In-person",
                ClassLevel = "Cơ bản",
                CreatedDate = new DateTime(2023, 8, 02),
                City = "Thành phố Hồ Chí Minh",
                TutorId = 6,
                District = "Quận Gò Vấp",
                Ward = "Phường 1",
                Active = true,
                ClassFee = 350000,
                MeetingLink = "https://meet.google.com"
            },
            new Class
            {

                ClassId = 9,
                ClassName = "Toán cao cấp",
                ClassInfo = "Khóa học toán cao cấp cho sinh viên đại học",
                ClassRequire = "Yêu cầu những kiến thức toán cơ bản của cấp Trung học phổ thông",
                ClassMethod = "Trực tuyến",
                ClassLevel = "Cơ bản",
                CreatedDate = new DateTime(2023, 8, 12),
                City = "Thành phố Hà Nội",
                TutorId = 7,
                District = "Quận Hoàn Kiếm",
                Ward = "Phường Hàng Bài",
                Active = true,
                ClassFee = 550000,
                MeetingLink = "https://meet.google.com"
            },
            new Class
            {

                ClassId = 10,
                ClassName = "Hóa học trung học phổ thông",
                ClassInfo = "Khóa học môn Hóa học ở cấp độ trung học phổ thông",
                ClassRequire = "Yêu cầu kiến thức cơ bản môn Hóa học",
                ClassMethod = "In-person",
                ClassLevel = "Cơ bản",
                CreatedDate = new DateTime(2023, 8, 03),
                City = "Tỉnh Khánh Hòa",
                TutorId = 13,
                District = "Thành phố Nha Trang",
                Ward = "Phường Lộc Thọ",
                Active = true,
                ClassFee = 400000,
                MeetingLink = "https://meet.google.com"
            },
            new Class
            {
                ClassId = 11,
                ClassName = "Ôn thi Sinh học cho kì thi trung học phổ thông quốc gia",
                ClassInfo = "Khóa ôn thi môn Sinh học cho kì thi trung học phổ thông quốc gia",
                ClassRequire = "Yêu cầu kiến thức cơ bản môn Sinh học",
                ClassMethod = "Trực tuyến",
                ClassLevel = "Cơ bản",
                CreatedDate = new DateTime(2023, 9, 03),
                City = "Thành phồ Cần Thơ",
                TutorId = 13,
                District = "Quận Ninh Kiều",
                Ward = "Phường An Khánh",
                Active = true,
                ClassFee = 400000,
                MeetingLink = "https://meet.google.com"
            }
            );
        modelBuilder.Entity<Schedule>().HasData
          (
            new Schedule
            {
                ScheduleID = 1,
                ClassID = 1,
                Title = "Lịch lập trình buổi sáng",
                Description = "Lịch lập trình buổi sáng các ngày trong tuần",
                DateOfWeek = DayGroup.MonWedFri, // Thứ 2, 4, 6
                StartTime = new DateTime(2024, 6, 7, 8, 0, 0), // 8:00 AM
                EndTime = new DateTime(2024, 6, 7, 10, 0, 0), // 10:00 AM,

            },
          new Schedule
          {
              ScheduleID = 2,
              ClassID = 2,
              Title = "Lịch lập trình buổi sáng",
              Description = "Lịch lập trình buổi sáng các ngày trong tuần",
              DateOfWeek = DayGroup.TueThuSat, // Thứ 3, 5, 7
              StartTime = new DateTime(2024, 6, 8, 9, 0, 0), // 9:00 AM
              EndTime = new DateTime(2024, 6, 8, 11, 0, 0), // 11:00 AM
          },
          new Schedule
          {
              ScheduleID = 3,
              ClassID = 3,
              Title = "Lịch lập trình JAVA buổi sáng",
              Description = "Lịch lập trình buổi sáng các ngày trong tuần",
              DateOfWeek = DayGroup.TueThuSat, // Thứ 3, 5, 7
              StartTime = new DateTime(2024, 5, 20, 9, 0, 0), // 9:00 AM
              EndTime = new DateTime(2024, 5, 20, 11, 0, 0), // 11:00 AM
          },
          new Schedule
          {
              ScheduleID = 4,
              ClassID = 3,
              Title = "Lịch lập trình JAVA buổi sáng",
              Description = "Lịch lập trình buổi sáng các ngày trong tuần",
              DateOfWeek = DayGroup.MonWedFri, // Thứ 2, 4, 6
              StartTime = new DateTime(2024, 5, 20, 9, 0, 0), // 9:00 AM
              EndTime = new DateTime(2024, 5, 20, 11, 0, 0), // 11:00 AM
          },
          new Schedule
          {
              ScheduleID = 5,
              ClassID = 4,
              Title = "Lịch học React.js nâng cao",
              Description = "Lịch học React.js nâng cao buổi tối các ngày trong tuần",
              DateOfWeek = DayGroup.MonWedFri, // Thứ 2, 4, 6
              StartTime = new DateTime(2024, 6, 22, 19, 0, 0), // 7:00 PM
              EndTime = new DateTime(2024, 6, 22, 21, 0, 0), // 9:00 PM
          },
          new Schedule
          {
              ScheduleID = 6,
              ClassID = 5,
              Title = "Lịch học C# cơ bản",
              Description = "Lịch học C# cơ bản buổi tối các ngày trong tuần",
              DateOfWeek = DayGroup.TueThuSat, // Thứ 3, 5, 7
              StartTime = new DateTime(2024, 7, 28, 19, 0, 0), // 7:00 PM
              EndTime = new DateTime(2024, 7, 28, 21, 0, 0), // 9:00 PM
          },
          new Schedule
          {
              ScheduleID = 7,
              ClassID = 6,
              Title = "Lịch học khóa học Lịch sử và Địa ly cấp THPT",
              Description = "Lịch học khóa học Lịch sử và Địa ly cấp THPT",
              DateOfWeek = DayGroup.MonWedFriSun, // Thứ 2, 4, 6, cn
              StartTime = new DateTime(2024, 7, 28, 19, 0, 0), // 7:00 PM
              EndTime = new DateTime(2024, 7, 28, 21, 0, 0), // 9:00 PM
          },
          new Schedule
          {
              ScheduleID = 8,
              ClassID = 7,
              Title = "Lịch học tiếng anh cho người đi làm",
              Description = "Lịch học tiếng anh cho người đi làm",
              DateOfWeek = DayGroup.MonWedFriSun, // Thứ 2, 4, 6, cn
              StartTime = new DateTime(2024, 8, 2, 19, 0, 0), // 7:00 PM
              EndTime = new DateTime(2024, 8, 2, 21, 0, 0), // 9:00 PM
          },
          
          new Schedule
          {
              ScheduleID = 9,
              ClassID = 8,
              Title = "Lịch Văn Học đại cươn buổi tối",
              Description = "Lịch Văn Học đại cươn buổi tối các ngày trong tuần",
              DateOfWeek = DayGroup.MonWedFri, // Thứ 2, 4, 6
              StartTime = new DateTime(2024, 7, 20, 9, 0, 0), // 9:00 AM
              EndTime = new DateTime(2024, 7, 20, 11, 0, 0), // 11:00 AM
          },
          new Schedule
          {
              ScheduleID = 10,
              ClassID = 9,
              Title = "Lịch học toán cao cấp cho sinh viên đại học",
              Description = "Lịch học toán cao cấp cho sinh viên đại học",
              DateOfWeek = DayGroup.MonWedFri, // Thứ 2, 4, 6
              StartTime = new DateTime(2024, 8, 12, 19, 0, 0), // 7:00 PM
              EndTime = new DateTime(2024, 8, 12, 21, 0, 0), // 9:00 PM
          },
          new Schedule
          {
              ScheduleID = 11,
              ClassID = 9,
              Title = "Lịch học toán cao cấp cho sinh viên đại học",
              Description = "Lịch học toán cao cấp cho sinh viên đại học",
              DateOfWeek = DayGroup.TueThuSat, // Thứ 3, 5, 7
              StartTime = new DateTime(2024, 8, 12, 19, 0, 0), // 7:00 PM
              EndTime = new DateTime(2024, 8, 12, 21, 0, 0), // 9:00 PM
          },
          new Schedule
          {
              ScheduleID = 12,
              ClassID = 10,
              Title = "Lịch học Hóa học trung học phổ thông",
              Description = "Lịch học Hóa học trung học phổ thông",
              DateOfWeek = DayGroup.MonWedFri, // Thứ 2, 4, 6
              StartTime = new DateTime(2024, 8, 03, 19, 0, 0), // 7:00 PM
              EndTime = new DateTime(2024, 8, 03, 21, 0, 0), // 9:00 PM
          },
          new Schedule
          {
              ScheduleID = 13,
              ClassID = 10,
              Title = "Lịch học Hóa học trung học phổ thông",
              Description = "Lịch học Hóa học trung học phổ thông",
              DateOfWeek = DayGroup.TueThuSat, // Thứ 3, 5, 7
              StartTime = new DateTime(2024, 8, 03, 19, 0, 0), // 7:00 PM
              EndTime = new DateTime(2024, 8, 03, 21, 0, 0), // 9:00 PM
          },
          new Schedule
          {
              ScheduleID = 14,
              ClassID = 11,
              Title = "Lịch học Sinh học cho kì thi trung học phổ thông quốc gia",
              Description = "Lịch học Sinh học cho kì thi trung học phổ thông quốc gia",
              DateOfWeek = DayGroup.MonWedFriSun, // Thứ 2, 4, 6, cn
              StartTime = new DateTime(2024, 9, 03, 18, 0, 0), // 6:00 PM
              EndTime = new DateTime(2024, 9, 03, 21, 0, 0), // 9:00 PM
          }
          );
        modelBuilder.Entity<Booking>().HasData(
                 new Booking
                 {
                     BookingId = 1,
                     UserId = 1,
                     ScheduleId = 1,
                     TutorId = 4,
                     CreateDate = new DateTime(2024, 6, 8, 9, 0, 0),
                     StartDate = new DateTime(2024, 6, 8, 9, 0, 0),
                     EndDate = new DateTime(2024, 10, 8, 9, 0, 0),
                     Description = "Con tôi đang gặp khó khăn trong việc học lập trình. Tôi muốn mời Thầy đến dạy thêm cho con tôi, để giúp con cải thiện và tiến bộ hơn trong môn này.\r\n\r\nCon tôi năng động và rất ham học hỏi, nhưng vẫn còn nhiều vấn đề cần phải khắc phục trong lập trình. Tôi nghĩ rằng sự hướng dẫn của Thầy sẽ rất hữu ích cho con.\r\n\r\nChúng tôi có thể thảo luận về lịch trình, địa điểm và các chi tiết khác. Tôi rất mong được sự giúp đỡ của Thầy để con tôi có thể vượt qua khó khăn và tiến bộ hơn trong lập trình.",
                     Status = "Pending",
                     Address = "17-13 Đ. Số 40, Linh Đông, Thủ Đức"
                 },
                 new Booking
                 {
                     BookingId = 2,
                     UserId = 17,
                     ScheduleId = 13,
                     TutorId = 14,
                     CreateDate = new DateTime(2024, 8, 12, 18, 0, 0),
                     StartDate = new DateTime(2024, 8, 12, 18, 0, 0),
                     EndDate = new DateTime(2024, 8, 12, 21, 0, 0),
                     Description = "",
                     Status = "Pending",
                     Address = "40 Đ. Nguyễn Văn Cừ, Ninh Kiều, An Khánh"
                 },
                 new Booking
                 {
                     BookingId = 3,
                     UserId = 18,
                     ScheduleId = 11,
                     TutorId = 7,
                     CreateDate = new DateTime(2024, 8, 12, 18, 0, 0),
                     StartDate = new DateTime(2024, 8, 12, 19, 0, 0),
                     EndDate = new DateTime(2024, 8, 12, 21, 0, 0),
                     Description = "",
                     Status = "Pending",
                     Address = ""
                 }

            );
        
        modelBuilder.Entity<TutorDegree>().HasData(
            new TutorDegree
            {
                DegreeId = 1,
                DegreeName = "Bằng giải nhất cuộc thi học sinh giỏi toán cấp thành phố Hồ Chí Minh năm 2022",
                Description = "Giải nhất cuộc thi học sinh giỏi toán cấp thành phố Hồ Chí Minh năm 2022",
                DegreeImageUrl = "https://loremflickr.com/640/480",
                TutorId = 4
            },

            new TutorDegree
            {
                DegreeId = 2,
                DegreeName = "Ielts 6.5",
                Description = "Bằng tiếng anh Ielts 6.5",
                DegreeImageUrl = "https://loremflickr.com/640/480",
                TutorId = 5
            },
            new TutorDegree
            {
                DegreeId = 3,
                DegreeName = "Bằng giải nhất cuộc thi học sinh giỏi toán cấp thành phố Hà Nội",
                Description = "Giải nhất cuộc thi học sinh giỏi toán cấp thành phố Hà Nội",
                DegreeImageUrl = "https://loremflickr.com/640/480",
                TutorId = 7
            },
            new TutorDegree
            {
                DegreeId = 4,
                DegreeName = "Bằng giải khuyến khích cuộc thi toán học sinh giỏi cấp thành phố Hồ Chí Minh năm 2022",
                Description = "Giải khuyến khích cuộc thi toán học sinh giỏi cấp thành phố Hồ Chí Minh năm 2022",
                DegreeImageUrl = "https://loremflickr.com/640/480",
                TutorId = 8
            },
            new TutorDegree
            {
                DegreeId = 5,
                DegreeName = "Bằng Ielts 7.5",
                Description = "Bằng tiếng anh Ielts 7.5",
                DegreeImageUrl = "https://loremflickr.com/640/480",
                TutorId = 9
            },
            new TutorDegree
            {
                DegreeId = 6,
                DegreeName = "Bằng giải nhất cuộc thi học sinh giỏi môn Sinh học cấp thành phố Cần Thơ",
                Description = "Giải nhất cuộc thi học sinh giỏi môn Sinh học cấp thành phố Cần Thơ",
                DegreeImageUrl = "https://loremflickr.com/640/480",
                TutorId = 10
            },
            new TutorDegree
            {
                DegreeId = 7,
                DegreeName = "Bằng tốt nghiệp trường đại học sư phạm chuyên ngành Lịch Sử và Địa Lý",
                Description = "Bằng tốt nghiệp trường đại học sư phạm chuyên ngành Lịch Sử và Địa Lý",
                DegreeImageUrl = "https://loremflickr.com/640/480",
                TutorId = 11
            },
            new TutorDegree
            {
                DegreeId = 8,
                DegreeName = "Bằng thạc sĩ trường đại học sư phạm Đà Lạt chuyên ngành công nghệ thông tin",
                Description = "Bằng thạc sĩ trường đại học sư phạm Đà Lạt chuyên ngành công nghệ thông tin",
                DegreeImageUrl = "https://loremflickr.com/640/480",
                TutorId = 12
            },
            new TutorDegree
            {
                DegreeId = 9,
                DegreeName = "Bằng tốt nghiệp trường đại học Nha Trang chuyên ngành Công nghệ Sinh học",
                Description = "Bằng tốt nghiệp trường đại học Nha Trang chuyên ngành Công nghệ Sinh học",
                DegreeImageUrl = "https://loremflickr.com/640/480",
                TutorId = 13
            },
            new TutorDegree
            {
                DegreeId = 10,
                DegreeName = "Bằng tốt nghiệp trường đại học Quy Nhơn chuyên ngành sư phạm Văn",
                Description = "Bằng tốt nghiệp trường đại học Quy Nhơn chuyên ngành sư phạm Văn",
                DegreeImageUrl = "https://loremflickr.com/640/480",
                TutorId = 14
            },
            new TutorDegree
            {
                DegreeId = 11,
                DegreeName = "Bằng tốt nghiệp trường đại học Quốc Gia Hà Nội chuyên ngành Trí Tuệ Nhân Tạo",
                Description = "Bằng tốt nghiệp trường đại học Quốc Gia Hà Nội chuyên ngành Trí Tuệ Nhân Tạo",
                DegreeImageUrl = "https://loremflickr.com/640/480",
                TutorId = 15
            },
            new TutorDegree
            {
                DegreeId = 12,
                DegreeName = "Bằng tốt nghiệp đại học Bách khoa Thành phố Hồ Chí Minh chuyên ngành công nghệ thông tin",
                Description = "Bằng tốt nghiệp đại học Bách khoa Thành phố Hồ Chí Minh chuyên ngành công nghệ thông tin",
                DegreeImageUrl = "https://loremflickr.com/640/480",
                TutorId = 16
            }
            );
        modelBuilder.Entity<Rate>().HasData(
            new Rate
            {
                RatingId = 1,
                StudentId = 2,
                TutorId = 2,
                NumberStars = 3,

            }
            );
    }
}
