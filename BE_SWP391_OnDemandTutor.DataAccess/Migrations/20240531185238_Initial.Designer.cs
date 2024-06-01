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
    [Migration("20240531185238_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"));

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

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("ClassId");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.HasIndex("TutorId")
                        .IsUnique();

                    b.ToTable("Classes", (string)null);
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Feedback", b =>
                {
                    b.Property<int>("FeedbackID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Evaluation")
                        .HasColumnType("int");

                    b.Property<int>("SlotId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("FeedbackID");

                    b.HasIndex("SlotId")
                        .IsUnique();

                    b.HasIndex("StudentId");

                    b.HasIndex("TutorId");

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

                    b.HasIndex("SubjectId")
                        .IsUnique();

                    b.HasIndex("TutorId");

                    b.ToTable("Rates", (string)null);
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Schedule", b =>
                {
                    b.Property<int>("ScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SlotId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ScheduleID");

                    b.ToTable("Schedules", (string)null);
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Slot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("Description")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId")
                        .IsUnique();

                    b.HasIndex("ScheduleId")
                        .IsUnique();

                    b.HasIndex("SubjectId")
                        .IsUnique();

                    b.ToTable("Slots", (string)null);
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects", (string)null);
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

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.TutorFreeTimeSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DateOfWeek")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<TimeSpan>("EndTimeTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TutorId")
                        .IsUnique();

                    b.ToTable("TutorFreeTimeSchedules", (string)null);
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

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
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.HasIndex("ClassId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Class", b =>
                {
                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.User", "Student")
                        .WithOne()
                        .HasForeignKey("BE_SWP391_OnDemandTutor.DataAccess.Models.Class", "StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.User", "Tutor")
                        .WithOne()
                        .HasForeignKey("BE_SWP391_OnDemandTutor.DataAccess.Models.Class", "TutorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Feedback", b =>
                {
                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.Slot", "Slot")
                        .WithOne("Feedback")
                        .HasForeignKey("BE_SWP391_OnDemandTutor.DataAccess.Models.Feedback", "SlotId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.User", "Student")
                        .WithMany("StudentGivenFeedbacks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.User", "Tutor")
                        .WithMany("TutorReceiveFeedbacks")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Slot");

                    b.Navigation("Student");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Rate", b =>
                {
                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.User", "Student")
                        .WithMany("StudentSendRatings")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.Subject", "Subject")
                        .WithOne("Rate")
                        .HasForeignKey("BE_SWP391_OnDemandTutor.DataAccess.Models.Rate", "SubjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.User", "Tutor")
                        .WithMany("TutorReceiveRatings")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Slot", b =>
                {
                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.Class", "Class")
                        .WithOne("Slot")
                        .HasForeignKey("BE_SWP391_OnDemandTutor.DataAccess.Models.Slot", "ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.Schedule", "Schedule")
                        .WithOne("Slot")
                        .HasForeignKey("BE_SWP391_OnDemandTutor.DataAccess.Models.Slot", "ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.Subject", "Subject")
                        .WithOne("Slot")
                        .HasForeignKey("BE_SWP391_OnDemandTutor.DataAccess.Models.Slot", "SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Schedule");

                    b.Navigation("Subject");
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

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.TutorFreeTimeSchedule", b =>
                {
                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.User", "Tutor")
                        .WithOne("TutorFreeTimeSchedule")
                        .HasForeignKey("BE_SWP391_OnDemandTutor.DataAccess.Models.TutorFreeTimeSchedule", "TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.User", b =>
                {
                    b.HasOne("BE_SWP391_OnDemandTutor.DataAccess.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Class", b =>
                {
                    b.Navigation("Slot")
                        .IsRequired();
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Schedule", b =>
                {
                    b.Navigation("Slot")
                        .IsRequired();
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Slot", b =>
                {
                    b.Navigation("Feedback")
                        .IsRequired();
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.Subject", b =>
                {
                    b.Navigation("Rate")
                        .IsRequired();

                    b.Navigation("Slot")
                        .IsRequired();
                });

            modelBuilder.Entity("BE_SWP391_OnDemandTutor.DataAccess.Models.User", b =>
                {
                    b.Navigation("StudentGivenFeedbacks");

                    b.Navigation("StudentSendRatings");

                    b.Navigation("TutorDegree")
                        .IsRequired();

                    b.Navigation("TutorFreeTimeSchedule")
                        .IsRequired();

                    b.Navigation("TutorReceiveFeedbacks");

                    b.Navigation("TutorReceiveRatings");
                });
#pragma warning restore 612, 618
        }
    }
}
