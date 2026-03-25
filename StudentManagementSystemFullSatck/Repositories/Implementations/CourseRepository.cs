using Microsoft.EntityFrameworkCore;
using StudentManagementSystemFullStack.Data;
using StudentManagementSystemFullStack.Models;
using StudentManagementSystemFullStack.Repositories.Interfaces;

namespace StudentManagementSystemFullStack.Repositories.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _db;

        public CourseRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Course?> GetByIdAsync(int id)
        {
            var course = await _db.Courses.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted && c.IsActive);
       
            return course;

        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            var courses = await _db.Courses.Where(c=>c.IsActive && !c.IsDeleted).ToListAsync();
            return courses;
        }

        public async Task AddAsync(Course course)
        {
            await _db.Courses.AddAsync(course);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var course = await _db.Courses.FindAsync(id);
            if (course == null)
            {
                throw new Exception($"Course with id {id} not found.");
            }

            course.IsDeleted = true;
            course.IsActive = false;
            course.ModifiedAt= DateTime.Now;
            await _db.SaveChangesAsync();


        }

  
        
    }
}
