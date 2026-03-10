using Microsoft.EntityFrameworkCore;
using StudentManagementSystemFullStack.Models;


namespace StudentManagementSystemFullStack.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions <AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        //public DbSet<Student> Students { get; set; } 
        //public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<Course> Courses { get; set; }
        //public DbSet<StudentCourse> StudentCourses { get; set; }
        //public DbSet<StudentTeacher> StudentTeachers { get; set; }
        //public DbSet<Mark> Marks { get; set; }
        //public DbSet<ProfileUpdateRequest> ProfileUpdateRequests { get; set; }  
       


    }
}
