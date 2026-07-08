using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InitialMigration.Migrations
{
    /// <inheritdoc />
    public partial class InitialForSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CourseName", "Price" },
                values: new object[] { "Mathematics", 1000.00m });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 2000.00m);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 1500.00m);

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseName", "Price" },
                values: new object[,]
                {
                    { 4, "Biology", 1200.00m },
                    { 5, "CS-50", 3000.00m }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Name", "OfficeId" },
                values: new object[,]
                {
                    { 4, "Ahmed Abdullah", 1 },
                    { 5, "Yasmeen Mohammed", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfficeLocation",
                value: "Building A");

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfficeLocation",
                value: "Building B");

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfficeLocation",
                value: "Administration");

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "FName", "LName" },
                values: new object[,]
                {
                    { 1, "Fatima", "Ali" },
                    { 2, "Noor", "Saleh" },
                    { 3, "Omar", "Youssef" },
                    { 4, "Huda", "Ahmed" },
                    { 5, "Amira", "Tariq" },
                    { 6, "Zainab", "Ismail" },
                    { 7, "Yousef", "Farid" },
                    { 8, "Layla", "Mustafa" },
                    { 9, "Mohammed", "Adel" },
                    { 10, "Samira", "Nabil" }
                });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "TwiceAWeek");

            migrationBuilder.InsertData(
                table: "Coporates",
                columns: new[] { "Id", "Company", "JobTitle" },
                values: new object[,]
                {
                    { 2, "ABC", "Developer" },
                    { 4, "ABC", "QA" },
                    { 7, "EFG", "Developer" },
                    { 8, "EFG", "QA" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "ParticipantId", "SectionId" },
                values: new object[,]
                {
                    { 1, 6 },
                    { 2, 6 },
                    { 3, 7 },
                    { 4, 7 },
                    { 5, 8 },
                    { 6, 8 },
                    { 7, 9 },
                    { 8, 9 },
                    { 9, 10 },
                    { 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Individuals",
                columns: new[] { "Id", "IsIntern", "University", "YearOfGraduation" },
                values: new object[,]
                {
                    { 1, false, "XYZ", 2024 },
                    { 3, true, "POQ", 2023 },
                    { 5, false, "POQ", 2025 },
                    { 6, true, "POQ", 2023 },
                    { 9, false, "XYZ", 2024 },
                    { 10, false, "XYZ", 2024 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coporates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Coporates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Coporates",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Coporates",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "ParticipantId", "SectionId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "ParticipantId", "SectionId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "ParticipantId", "SectionId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "ParticipantId", "SectionId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "ParticipantId", "SectionId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "ParticipantId", "SectionId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "ParticipantId", "SectionId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "ParticipantId", "SectionId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "ParticipantId", "SectionId" },
                keyValues: new object[] { 9, 10 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "ParticipantId", "SectionId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "Individuals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Individuals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Individuals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Individuals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Individuals",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Individuals",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CourseName", "Price" },
                values: new object[] { "Mathmatics", 100m });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 200m);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 150m);

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfficeLocation",
                value: "building A");

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfficeLocation",
                value: "building B");

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfficeLocation",
                value: "Adminstration");

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Twice-a-Week");
        }
    }
}
