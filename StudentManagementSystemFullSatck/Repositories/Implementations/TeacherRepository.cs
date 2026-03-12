using Microsoft.EntityFrameworkCore;
using StudentManagementSystemFullStack.Data;
using StudentManagementSystemFullStack.Models;
using StudentManagementSystemFullStack.Repositories.Interfaces;

namespace StudentManagementSystemFullStack.Repositories.Implementations
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _db;

        public TeacherRepository(AppDbContext db)
        {
            _db = db;

        }

        public async Task<Teacher?> GetByIdAsync(int id)
        {
            var teacher = await _db.Teachers.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted && t.IsActive);
            return teacher;

        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            var teachers = await _db.Teachers.Where(t=>t.IsActive && !t.IsDeleted).Include(t => t.User).ToListAsync();
            return teachers;
        }


        public async Task AddAsync(Teacher teacher)
        {
            await _db.Teachers.AddAsync(teacher);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var teacher = await _db.Teachers.FindAsync(id);
            if (teacher != null)
            {
                teacher.IsDeleted = true;
                teacher.IsActive = false;
                await _db.SaveChangesAsync();
            }
        }


    }
}
