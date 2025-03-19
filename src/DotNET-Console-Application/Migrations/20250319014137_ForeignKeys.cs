using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNET_Console_Application.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "course_id",
                table: "student",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "instructor_id",
                table: "course",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "course",
                keyColumn: "id",
                keyValue: -2,
                column: "instructor_id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "course",
                keyColumn: "id",
                keyValue: -1,
                column: "instructor_id",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "FK_Student_Course",
                table: "student",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "FK_Course_Instructor",
                table: "course",
                column: "instructor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Instructor",
                table: "course",
                column: "instructor_id",
                principalTable: "instructor",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Course",
                table: "student",
                column: "course_id",
                principalTable: "course",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Instructor",
                table: "course");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Course",
                table: "student");

            migrationBuilder.DropIndex(
                name: "FK_Student_Course",
                table: "student");

            migrationBuilder.DropIndex(
                name: "FK_Course_Instructor",
                table: "course");

            migrationBuilder.DropColumn(
                name: "course_id",
                table: "student");

            migrationBuilder.DropColumn(
                name: "instructor_id",
                table: "course");
        }
    }
}
