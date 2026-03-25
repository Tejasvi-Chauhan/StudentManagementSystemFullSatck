using StudentManagementSystemFullStack.Models;
using StudentManagementSystemFullStack.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystemFullStack.Data;

namespace StudentManagementSystemFullStack.Repositories.Implementations
{
    public class StudentTeacherRepository : IStudentTeacherRepository
    {

         private readonly AppDbContext _db;
        public StudentTeacherRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<StudentTeacher>> GetByStudentIdAsync(int studentId)
        {
            var st = await _db.StudentTeachers.Include(st => st.Student)
            .ThenInclude(s => s.User).Include(st => st.Teacher)
            .ThenInclude(t => t.User).Where(st => st.StudentId == studentId && !st.IsDeleted && st.IsActive).ToListAsync();
            return st;
        }

        public async Task<IEnumerable<StudentTeacher>> GetByTeacherIdAsync(int teacherId)
        {
           var st = await _db.StudentTeachers.Include(st => st.Student)
            .ThenInclude(s => s.User).Include(st => st.Teacher)
            .ThenInclude(t => t.User).Where(st=> st.TeacherId == teacherId && !st.IsDeleted && st.IsActive).ToListAsync();
            return st;
        }

        public async Task<IEnumerable<StudentTeacher>> GetAllAsync()
        {
            var st = await _db.StudentTeachers.Include(st => st.Student)
           .ThenInclude(s => s.User).Include(st => st.Teacher)
           .ThenInclude(t => t.User).Where( st=>!st.IsDeleted && st.IsActive).ToListAsync();
            return st;
        }
        public async Task AddAsync(StudentTeacher studentTeacher)
        {
             await _db.StudentTeachers.AddAsync(studentTeacher);
                await _db.SaveChangesAsync();
        }


        public async Task DeleteAsync(int Id)
        {
            var st = await _db.StudentTeachers.FirstOrDefaultAsync(st => Id==st.Id);
            if (st != null)
            {
                st.IsActive= false;
                st.IsDeleted= true;
                st.ModifiedAt= DateTime.Now;
                
                await  _db.SaveChangesAsync();
            }
        }

       
    }
}
