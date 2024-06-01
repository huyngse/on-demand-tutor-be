using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BE_SWP391_OnDemandTutor.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DateOfBirth", "EmailAddress", "Gender", "Password", "PhoneNumber", "ProfileImage", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "Male", "password123", "555-1234", "https://example.com/profile_image_1.jpg", "Student", "JohnDoe" },
                    { 2, new DateTime(1992, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.doe@example.com", "Female", "securepassword", "555-5678", "https://example.com/profile_image_2.jpg", "Student", "JaneDoe" },
                    { 3, new DateTime(1978, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.smith@example.com", "Male", "mypassword456", "555-9012", "https://example.com/profile_image_3.jpg", "Tutor", "BobSmith" },
                    { 4, new DateTime(1990, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "sarah.johnson@example.com", "Female", "strongpassword", "555-3456", "https://example.com/profile_image_4.jpg", "Tutor", "SarahJohnson" },
                    { 5, new DateTime(1982, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.davis@example.com", "Male", "123456789", "555-7890", "https://example.com/profile_image_5.jpg", "Student", "MichaelDavis" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "ClassAddress", "ClassFee", "ClassInfo", "ClassLevel", "ClassMethod", "ClassName", "ClassRequire", "ClassTime", "StudentId", "TutorId" },
                values: new object[,]
                {
                    { 1, "123 Main Street, Anytown USA", 199.99m, "This course introduces the fundamental concepts of programming, including data types, control structures, and algorithms.", "Beginner", "In-person", "Introduction to Programming", "No prior programming experience required.", new DateTime(2023, 9, 1, 18, 30, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 2, "456 Oak Avenue, Anytown USA", 299.99m, "This course explores advanced data structures and their implementation in various programming languages.", "Advanced", "Online", "Advanced Data Structures", "Prerequisite: Data Structures and Algorithms", new DateTime(2023, 10, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);
        }
    }
}
