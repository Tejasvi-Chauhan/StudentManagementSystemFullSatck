using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementSystemFullStack.Migrations
{
    /// <inheritdoc />
    public partial class addedBranchInStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "branch",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "branch",
                table: "Students");
        }
    }
}
