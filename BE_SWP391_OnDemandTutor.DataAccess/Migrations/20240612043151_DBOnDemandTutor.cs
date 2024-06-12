using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BE_SWP391_OnDemandTutor.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DBOnDemandTutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    City = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    District = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TutorType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    School = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TutorDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClassTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassInfo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ClassRequire = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClassAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClassMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClassLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ClassFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    TutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_Classes_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Classes_Users_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TutorId = table.Column<int>(type: "int", nullable: false),
                    NumberStars = table.Column<int>(type: "integer", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Rates_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Rates_Users_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "TutorDegrees",
                columns: table => new
                {
                    DegreeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DegreeImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorDegrees", x => x.DegreeId);
                    table.ForeignKey(
                        name: "FK_TutorDegrees_Users_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Evaluation = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackID);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DateOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleID);
                    table.ForeignKey(
                        name: "FK_Schedules_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ClassId");
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleID");
                    table.ForeignKey(
                        name: "FK_Booking_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "City", "DateOfBirth", "District", "EmailAddress", "FullName", "Gender", "Password", "PhoneNumber", "ProfileImage", "Role", "School", "Street", "TutorDescription", "TutorType", "Username", "Ward" },
                values: new object[,]
                {
                    { 1, "New York", new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manhattan", "john.doe@example.com", " Leo Dinh", "Male", "student1", "555-1234", "https://example.com/profile_image_1.jpg", "Student", "C", "B", "Experienced in mathematics tutoring.", "A", "student1", "A" },
                    { 2, "Los Angeles", new DateTime(1992, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hollywood", "jane.doe@example.com", " Leo Dinh", "Female", "student2", "555-5678", "https://example.com/profile_image_2.jpg", "Student", "D", "D", "Specializes in English and literature.", "B", "student2", "C" },
                    { 3, "Chicago", new DateTime(1978, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Downtown", "bob.smith@example.com", " Leo Dinh", "Male", "student3", "555-9012", "https://example.com/profile_image_3.jpg", "Student", "A", "A", "Interested in science and technology.", "C", "student3", "B" },
                    { 4, "San Francisco", new DateTime(1990, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bay Area", "sarah.johnson@example.com", " Leo Dinh", "Female", "tutor1", "555-3456", "https://example.com/profile_image_4.jpg", "Tutor", "B", "C", "Provides tutoring in history and social studies.", "A", "tutor1", "D" },
                    { 5, "Seattle", new DateTime(1982, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Downtown", "michael.davis@example.com", " Leo Dinh", "Male", "tutor2", "555-7890", "https://example.com/profile_image_5.jpg", "Tutor", "C", "B", "Enjoys learning about languages and cultures.", "B", "tutor2", "A" },
                    { 6, "Anytown", new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central", "johndoe@example.com", " Leo Dinh", "Male", "admin", "555-1234", "profile.jpg", "Tutor", "University of Anytown", "123 Main St", "I have 5 years of experience teaching mathematics to students of all levels.", "Mathematics", "admin", "Downtown" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "Active", "City", "ClassAddress", "ClassFee", "ClassInfo", "ClassLevel", "ClassMethod", "ClassName", "ClassRequire", "ClassTime", "CreatedDate", "District", "StudentId", "TutorId", "Ward" },
                values: new object[,]
                {
                    { 1, true, "LA", "123 Main Street, Anytown USA", 199.99m, "This course introduces the fundamental concepts of programming, including data types, control structures, and algorithms.", "Beginner", "In-person", "Introduction to Programming", "No prior programming experience required.", new DateTime(2023, 9, 1, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 1, 18, 30, 0, 0, DateTimeKind.Unspecified), "Downtown", 1, 4, "Go vap" },
                    { 2, false, "LA", "456 Oak Avenue, Anytown USA", 299.99m, "This course explores advanced data structures and their implementation in various programming languages.", "Advanced", "Online", "Advanced Data Structures", "Prerequisite: Data Structures and Algorithms", new DateTime(2023, 10, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 1, 18, 30, 0, 0, DateTimeKind.Unspecified), "Downtown", 1, 5, "Go vap" },
                    { 3, true, "TP.HCM", "123 Đường A, Quận 1, TP.HCM", 500000m, "Khóa học giới thiệu các khái niệm cơ bản của ngôn ngữ lập trình Java", "Cơ bản", "Trực tiếp", "Lập trình Java cơ bản", "Không yêu cầu kiến thức lập trình trước đó", new DateTime(2023, 6, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quận 1", 2, 4, "Phường A" },
                    { 4, true, "TP.HCM", "456 Đường B, Quận 3, TP.HCM", 800000m, "Khóa học giới thiệu các kỹ thuật nâng cao trong việc xây dựng ứng dụng web với React.js", "Nâng cao", "Trực tuyến", "Lập trình React.js nâng cao", "Có kiến thức lập trình Javascript và React.js cơ bản", new DateTime(2023, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quận 3", 2, 5, "Phường B" },
                    { 5, true, "TP.HCM", "789 Đường C, Quận 5, TP.HCM", 400000m, "Khóa học giới thiệu các khái niệm cơ bản của ngôn ngữ lập trình C#", "Cơ bản", "Trực tiếp", "Lập trình C# cơ bản", "Không yêu cầu kiến thức lập trình trước đó", new DateTime(2023, 8, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quận 5", 3, 4, "Phường C" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "ScheduleID", "ClassID", "DateOfWeek", "Description", "EndTime", "StartTime", "Title" },
                values: new object[,]
                {
                    { 1, 1, "MonWedFri", "Lớp học môn Toán vào các ngày trong tuần", new DateTime(2024, 6, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), "Lịch học môn Toán" },
                    { 2, 2, "TueThuSat", "Lớp học môn Văn vào các ngày trong tuần", new DateTime(2024, 6, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "Lịch học môn Văn" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ScheduleId",
                table: "Booking",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_StudentId",
                table: "Classes",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TutorId",
                table: "Classes",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ClassId",
                table: "Feedbacks",
                column: "ClassId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_StudentId",
                table: "Feedbacks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_StudentId",
                table: "Rates",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_TutorId",
                table: "Rates",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ClassID",
                table: "Schedules",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_TutorDegrees_TutorId",
                table: "TutorDegrees",
                column: "TutorId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "TutorDegrees");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
