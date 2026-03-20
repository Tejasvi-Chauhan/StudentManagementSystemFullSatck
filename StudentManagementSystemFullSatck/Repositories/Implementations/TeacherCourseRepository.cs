using Microsoft.EntityFrameworkCore;
using StudentManagementSystemFullStack.Data;
using StudentManagementSystemFullStack.Models;
using StudentManagementSystemFullStack.Repositories.Interfaces;

namespace StudentManagementSystemFullStack.Repositories.Implementations
{
    public class TeacherCourseRepository : ITeacherCourseRepository
    {
        private readonly AppDbContext _db;

        public TeacherCourseRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TeacherCourse>> GetByTeacherIdAsync(int teacherId)
        {
            return await _db.TeacherCourses
                .Include(tc => tc.Teacher)
                    .ThenInclude(t => t.User)
                .Include(tc => tc.Course)
                .Where(tc => tc.TeacherId == teacherId && tc.IsActive && !tc.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<TeacherCourse>> GetByCourseIdAsync(int courseId)
        {
            return await _db.TeacherCourses
                .Include(tc => tc.Teacher)
                    .ThenInclude(t => t.User)
                .Include(tc => tc.Course)
                .Where(tc => tc.CourseId == courseId && tc.IsActive && !tc.IsDeleted)
                .ToListAsync();
        }

        public async Task AddAsync(TeacherCourse teacherCourse)
        {
            await _db.TeacherCourses.AddAsync(teacherCourse);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int teacherId, int courseId)
        {
            var tc = await _db.TeacherCourses
                .FirstOrDefaultAsync(tc => tc.TeacherId == teacherId
                                    && tc.CourseId == courseId);
            if (tc != null)
            {
                tc.IsDeleted = true;
                tc.IsActive = false;
                tc.ModifiedAt = DateTime.Now;
                await _db.SaveChangesAsync();
            }
        }
    }
}