using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNET_Console_Application.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeySeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "instructor",
                columns: new[] { "id", "first_name", "last_name" },
                values: new object[] { -1, "John", "Doe" });

            migrationBuilder.UpdateData(
                table: "course",
                keyColumn: "id",
                keyValue: -2,
                column: "instructor_id",
                value: -1);

            migrationBuilder.UpdateData(
                table: "course",
                keyColumn: "id",
                keyValue: -1,
                column: "instructor_id",
                value: -1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "course",
                keyColumn: "id",
                keyValue: -2,
                column: "instructor_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "course",
                keyColumn: "id",
                keyValue: -1,
                column: "instructor_id",
                value: null);

            migrationBuilder.DeleteData(
                table: "instructor",
                keyColumn: "id",
                keyValue: -1);

        }
    }
}
