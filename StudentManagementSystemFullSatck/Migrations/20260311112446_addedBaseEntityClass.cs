using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementSystemFullStack.Migrations
{
    /// <inheritdoc />
    public partial class addedBaseEntityClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileUpdateRequests_Users_UserId",
                table: "ProfileUpdateRequests");

            migrationBuilder.DropIndex(
                name: "IX_ProfileUpdateRequests_UserId",
                table: "ProfileUpdateRequests");

            migrationBuilder.DropColumn(
                name: "AddedAt",
                table: "Marks");

            migrationBuilder.RenameColumn(
                name: "AssignedAt",
                table: "StudentTeachers",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "AssignedAt",
                table: "StudentCourses",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ProfileUpdateRequests",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "RequestedAt",
                table: "ProfileUpdateRequests",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Marks",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Teachers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Teachers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "StudentTeachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "StudentTeachers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StudentTeachers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "StudentTeachers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "StudentTeachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "StudentCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "StudentCourses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StudentCourses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "StudentCourses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "StudentCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ReviewedBy",
                table: "ProfileUpdateRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ProfileUpdateRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ProfileUpdateRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProfileUpdateRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ProfileUpdateRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Marks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Marks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Marks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Marks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Marks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileUpdateRequests_ReviewedBy",
                table: "ProfileUpdateRequests",
                column: "ReviewedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileUpdateRequests_Users_ReviewedBy",
                table: "ProfileUpdateRequests",
                column: "ReviewedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileUpdateRequests_Users_ReviewedBy",
                table: "ProfileUpdateRequests");

            migrationBuilder.DropIndex(
                name: "IX_ProfileUpdateRequests_ReviewedBy",
                table: "ProfileUpdateRequests");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProfileUpdateRequests");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ProfileUpdateRequests");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProfileUpdateRequests");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ProfileUpdateRequests");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "StudentTeachers",
                newName: "AssignedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "StudentCourses",
                newName: "AssignedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "ProfileUpdateRequests",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ProfileUpdateRequests",
                newName: "RequestedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Marks",
                newName: "UpdatedAt");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewedBy",
                table: "ProfileUpdateRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedAt",
                table: "Marks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_ProfileUpdateRequests_UserId",
                table: "ProfileUpdateRequests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileUpdateRequests_Users_UserId",
                table: "ProfileUpdateRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
