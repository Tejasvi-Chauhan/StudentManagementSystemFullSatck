using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementSystemFullStack.Migrations
{
    /// <inheritdoc />
    public partial class addUniqueRollnumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "RollGen");

            migrationBuilder.AlterColumn<string>(
                name: "RollNumber",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValueSql: "'STU' + RIGHT('0000' + CAST(NEXT VALUE FOR RollGen AS VARCHAR),4)",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RollNumber",
                table: "Students",
                column: "RollNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_RollNumber",
                table: "Students");

            migrationBuilder.DropSequence(
                name: "RollGen");

            migrationBuilder.AlterColumn<string>(
                name: "RollNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValueSql: "'STU' + RIGHT('0000' + CAST(NEXT VALUE FOR RollGen AS VARCHAR),4)");
        }
    }
}
