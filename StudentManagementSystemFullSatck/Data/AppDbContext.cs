using Microsoft.EntityFrameworkCore;
using StudentManagementSystemFullStack.Models;

namespace StudentManagementSystemFullStack.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // Tables
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<StudentTeacher> StudentTeachers { get; set; }
        public DbSet<ProfileUpdateRequest> ProfileUpdateRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ── User ──────────────────────────────
            // Email unique hoga
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // ── Student ───────────────────────────
            // Student → User (one-to-one)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.User)
                .WithOne()
                .HasForeignKey<Student>(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ── Teacher ───────────────────────────
            // Teacher → User (one-to-one)
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.User)
                .WithOne()
                .HasForeignKey<Teacher>(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ── Marks ─────────────────────────────
            // Decimal precision
            modelBuilder.Entity<Mark>()
                .Property(m => m.MarksObtained)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Mark>()
                .Property(m => m.TotalMarks)
                .HasPrecision(5, 2);

            // Mark → Student
            modelBuilder.Entity<Mark>()
                .HasOne(m => m.Student)
                .WithMany()
                .HasForeignKey(m => m.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Mark → Course
            modelBuilder.Entity<Mark>()
                .HasOne(m => m.Course)
                .WithMany()
                .HasForeignKey(m => m.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Mark → Teacher
            modelBuilder.Entity<Mark>()
                .HasOne(m => m.Teacher)
                .WithMany()
                .HasForeignKey(m => m.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            // ── StudentCourse ─────────────────────
            // StudentCourse → Student
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany()
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // StudentCourse → Course
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany()
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            // ── StudentTeacher ────────────────────
            // StudentTeacher → Student
            modelBuilder.Entity<StudentTeacher>()
                .HasOne(st => st.Student)
                .WithMany()
                .HasForeignKey(st => st.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // StudentTeacher → Teacher
            modelBuilder.Entity<StudentTeacher>()
                .HasOne(st => st.Teacher)
                .WithMany()
                .HasForeignKey(st => st.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            // ── ProfileUpdateRequest ──────────────
            // ProfileUpdateRequest → Student
            modelBuilder.Entity<ProfileUpdateRequest>()
                .HasOne(p => p.Student)
                .WithMany()
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProfileUpdateRequest>()
                .HasOne(p => p.Reviewer)
                .WithMany()
                .HasForeignKey(p => p.ReviewedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}