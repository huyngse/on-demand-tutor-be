﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BE_SWP391_OnDemandTutor.DataAccess.Migrations
{
    [DbContext(typeof(BE_SWP391_OnDemandTutorDbContext))]
    [Migration("20240612043151_DBOnDemandTutor")]
    partial class DBOnDemandTutor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("UserId");

                    b.ToTable("Booking", (string)null);
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ClassAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("ClassFee")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<string>("ClassInfo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ClassLevel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ClassMethod")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ClassRequire")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("ClassTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.Property<string>("Ward")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ClassId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TutorId");

                    b.ToTable("Classes", (string)null);

                    b.HasData(
                        new
                        {
                            ClassId = 1,
                            Active = true,
                            City = "LA",
                            ClassAddress = "123 Main Street, Anytown USA",
                            ClassFee = 199.99m,
                            ClassInfo = "This course introduces the fundamental concepts of programming, including data types, control structures, and algorithms.",
                            ClassLevel = "Beginner",
                            ClassMethod = "In-person",
                            ClassName = "Introduction to Programming",
                            ClassRequire = "No prior programming experience required.",
                            ClassTime = new DateTime(2023, 9, 1, 18, 30, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(2023, 7, 1, 18, 30, 0, 0, DateTimeKind.Unspecified),
                            District = "Downtown",
                            StudentId = 1,
                            TutorId = 4,
                            Ward = "Go vap"
                        },
                        new
                        {
                            ClassId = 2,
                            Active = false,
                            City = "LA",
                            ClassAddress = "456 Oak Avenue, Anytown USA",
                            ClassFee = 299.99m,
                            ClassInfo = "This course explores advanced data structures and their implementation in various programming languages.",
                            ClassLevel = "Advanced",
                            ClassMethod = "Online",
                            ClassName = "Advanced Data Structures",
                            ClassRequire = "Prerequisite: Data Structures and Algorithms",
                            ClassTime = new DateTime(2023, 10, 15, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(2023, 7, 1, 18, 30, 0, 0, DateTimeKind.Unspecified),
                            District = "Downtown",
                            StudentId = 1,
                            TutorId = 5,
                            Ward = "Go vap"
                        },
                        new
                        {
                            ClassId = 3,
                            Active = true,
                            City = "TP.HCM",
                            ClassAddress = "123 Đường A, Quận 1, TP.HCM",
                            ClassFee = 500000m,
                            ClassInfo = "Khóa học giới thiệu các khái niệm cơ bản của ngôn ngữ lập trình Java",
                            ClassLevel = "Cơ bản",
                            ClassMethod = "Trực tiếp",
                            ClassName = "Lập trình Java cơ bản",
                            ClassRequire = "Không yêu cầu kiến thức lập trình trước đó",
                            ClassTime = new DateTime(2023, 6, 1, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            District = "Quận 1",
                            StudentId = 2,
                            TutorId = 4,
                            Ward = "Phường A"
                        },
                        new
                        {
                            ClassId = 4,
                            Active = true,
                            City = "TP.HCM",
                            ClassAddress = "456 Đường B, Quận 3, TP.HCM",
                            ClassFee = 800000m,
                            ClassInfo = "Khóa học giới thiệu các kỹ thuật nâng cao trong việc xây dựng ứng dụng web với React.js",
                            ClassLevel = "Nâng cao",
                            ClassMethod = "Trực tuyến",
                            ClassName = "Lập trình React.js nâng cao",
                            ClassRequire = "Có kiến thức lập trình Javascript và React.js cơ bản",
                            ClassTime = new DateTime(2023, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            District = "Quận 3",
                            StudentId = 2,
                            TutorId = 5,
                            Ward = "Phường B"
                        },
                        new
                        {
                            ClassId = 5,
                            Active = true,
                            City = "TP.HCM",
                            ClassAddress = "789 Đường C, Quận 5, TP.HCM",
                            ClassFee = 400000m,
                            ClassInfo = "Khóa học giới thiệu các khái niệm cơ bản của ngôn ngữ lập trình C#",
                            ClassLevel = "Cơ bản",
                            ClassMethod = "Trực tiếp",
                            ClassName = "Lập trình C# cơ bản",
                            ClassRequire = "Không yêu cầu kiến thức lập trình trước đó",
                            ClassTime = new DateTime(2023, 8, 15, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            District = "Quận 5",
                            StudentId = 3,
                            TutorId = 4,
                            Ward = "Phường C"
                        });
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Feedback", b =>
                {
                    b.Property<int>("FeedbackID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackID"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Evaluation")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("FeedbackID");

                    b.HasIndex("ClassId")
                        .IsUnique();

                    b.HasIndex("StudentId");

                    b.ToTable("Feedbacks", (string)null);
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Rate", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RatingId"));

                    b.Property<int>("NumberStars")
                        .HasColumnType("integer");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("RatingId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TutorId");

                    b.ToTable("Rates", (string)null);
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Schedule", b =>
                {
                    b.Property<int>("ScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleID"));

                    b.Property<int>("ClassID")
                        .HasColumnType("int");

                    b.Property<string>("DateOfWeek")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("EndTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ScheduleID");

                    b.HasIndex("ClassID");

                    b.ToTable("Schedules", (string)null);

                    b.HasData(
                        new
                        {
                            ScheduleID = 1,
                            ClassID = 1,
                            DateOfWeek = "MonWedFri",
                            Description = "Lớp học môn Toán vào các ngày trong tuần",
                            EndTime = new DateTime(2024, 6, 7, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 6, 7, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Lịch học môn Toán"
                        },
                        new
                        {
                            ScheduleID = 2,
                            ClassID = 2,
                            DateOfWeek = "TueThuSat",
                            Description = "Lớp học môn Văn vào các ngày trong tuần",
                            EndTime = new DateTime(2024, 6, 8, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 6, 8, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Lịch học môn Văn"
                        });
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.TutorDegree", b =>
                {
                    b.Property<int>("DegreeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DegreeId"));

                    b.Property<string>("DegreeImageUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DegreeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("DegreeId");

                    b.HasIndex("TutorId")
                        .IsUnique();

                    b.ToTable("TutorDegrees", (string)null);
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ProfileImage")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("School")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("TutorDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TutorType")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ward")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("UserId");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            City = "New York",
                            DateOfBirth = new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            District = "Manhattan",
                            EmailAddress = "john.doe@example.com",
                            FullName = " Leo Dinh",
                            Gender = "Male",
                            Password = "student1",
                            PhoneNumber = "555-1234",
                            ProfileImage = "https://example.com/profile_image_1.jpg",
                            Role = "Student",
                            School = "C",
                            Street = "B",
                            TutorDescription = "Experienced in mathematics tutoring.",
                            TutorType = "A",
                            Username = "student1",
                            Ward = "A"
                        },
                        new
                        {
                            UserId = 2,
                            City = "Los Angeles",
                            DateOfBirth = new DateTime(1992, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            District = "Hollywood",
                            EmailAddress = "jane.doe@example.com",
                            FullName = " Leo Dinh",
                            Gender = "Female",
                            Password = "student2",
                            PhoneNumber = "555-5678",
                            ProfileImage = "https://example.com/profile_image_2.jpg",
                            Role = "Student",
                            School = "D",
                            Street = "D",
                            TutorDescription = "Specializes in English and literature.",
                            TutorType = "B",
                            Username = "student2",
                            Ward = "C"
                        },
                        new
                        {
                            UserId = 3,
                            City = "Chicago",
                            DateOfBirth = new DateTime(1978, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            District = "Downtown",
                            EmailAddress = "bob.smith@example.com",
                            FullName = " Leo Dinh",
                            Gender = "Male",
                            Password = "student3",
                            PhoneNumber = "555-9012",
                            ProfileImage = "https://example.com/profile_image_3.jpg",
                            Role = "Student",
                            School = "A",
                            Street = "A",
                            TutorDescription = "Interested in science and technology.",
                            TutorType = "C",
                            Username = "student3",
                            Ward = "B"
                        },
                        new
                        {
                            UserId = 4,
                            City = "San Francisco",
                            DateOfBirth = new DateTime(1990, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            District = "Bay Area",
                            EmailAddress = "sarah.johnson@example.com",
                            FullName = " Leo Dinh",
                            Gender = "Female",
                            Password = "tutor1",
                            PhoneNumber = "555-3456",
                            ProfileImage = "https://example.com/profile_image_4.jpg",
                            Role = "Tutor",
                            School = "B",
                            Street = "C",
                            TutorDescription = "Provides tutoring in history and social studies.",
                            TutorType = "A",
                            Username = "tutor1",
                            Ward = "D"
                        },
                        new
                        {
                            UserId = 5,
                            City = "Seattle",
                            DateOfBirth = new DateTime(1982, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            District = "Downtown",
                            EmailAddress = "michael.davis@example.com",
                            FullName = " Leo Dinh",
                            Gender = "Male",
                            Password = "tutor2",
                            PhoneNumber = "555-7890",
                            ProfileImage = "https://example.com/profile_image_5.jpg",
                            Role = "Tutor",
                            School = "C",
                            Street = "B",
                            TutorDescription = "Enjoys learning about languages and cultures.",
                            TutorType = "B",
                            Username = "tutor2",
                            Ward = "A"
                        },
                        new
                        {
                            UserId = 6,
                            City = "Anytown",
                            DateOfBirth = new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            District = "Central",
                            EmailAddress = "johndoe@example.com",
                            FullName = " Leo Dinh",
                            Gender = "Male",
                            Password = "admin",
                            PhoneNumber = "555-1234",
                            ProfileImage = "profile.jpg",
                            Role = "Tutor",
                            School = "University of Anytown",
                            Street = "123 Main St",
                            TutorDescription = "I have 5 years of experience teaching mathematics to students of all levels.",
                            TutorType = "Mathematics",
                            Username = "admin",
                            Ward = "Downtown"
                        });
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Booking", b =>
                {
                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.Schedule", "Schedule")
                        .WithMany("Bookings")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Schedule");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Class", b =>
                {
                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.User", "Student")
                        .WithMany("StudentClasses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.User", "Tutor")
                        .WithMany("TutorClasses")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Feedback", b =>
                {
                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.Class", "Class")
                        .WithOne("Feedback")
                        .HasForeignKey("BE_SWP391_OnDemandTutor.DataAccess.Models.Feedback", "ClassId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.User", "Student")
                        .WithMany("Feedbacks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Rate", b =>
                {
                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.User", "Student")
                        .WithMany("StudentSendRatings")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.User", "Tutor")
                        .WithMany("TutorReceiveRatings")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Schedule", b =>
                {
                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.Class", "Class")
                        .WithMany("Schedules")
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.TutorDegree", b =>
                {
                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.User", "Tutor")
                        .WithOne("TutorDegree")
                        .HasForeignKey("BE_SWP391_OnDemandTutor.DataAccess.Models.TutorDegree", "TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Class", b =>
                {
                    b.Navigation("Feedback")
                        .IsRequired();

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Schedule", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.User", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Feedbacks");

                    b.Navigation("StudentClasses");

                    b.Navigation("StudentSendRatings");

                    b.Navigation("TutorClasses");

                    b.Navigation("TutorDegree")
                        .IsRequired();

                    b.Navigation("TutorReceiveRatings");
                });
#pragma warning restore 612, 618
        }
    }
}
