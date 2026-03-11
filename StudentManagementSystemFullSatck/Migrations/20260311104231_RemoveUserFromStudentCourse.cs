using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementSystemFullStack.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserFromStudentCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Users_UserId",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_UserId",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StudentCourses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "StudentCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_UserId",
                table: "StudentCourses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Users_UserId",
                table: "StudentCourses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
