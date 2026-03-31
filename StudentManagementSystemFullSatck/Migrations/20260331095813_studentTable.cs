using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementSystemFullStack.Migrations
{
    /// <inheritdoc />
    public partial class studentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "branch",
                table: "Students",
                newName: "Branch");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Branch",
                table: "Students",
                newName: "branch");
        }
    }
}
