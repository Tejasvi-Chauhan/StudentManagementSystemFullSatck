using Microsoft.EntityFrameworkCore;
using StudentManagementSystemFullStack.Data;
using StudentManagementSystemFullStack.Models;
using StudentManagementSystemFullStack.Repositories.Interfaces;

namespace StudentManagementSystemFullStack.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {  

        private readonly AppDbContext _db;

        public StudentRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            var student = await _db.Students.Include(s=>s.User).FirstOrDefaultAsync(s => s.Id == id &&!s.IsDeleted && s.IsActive);
             return student;

        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            var students = await _db.Students.Where(s => !s.IsDeleted && s.IsActive  ).
                Include(s => s.User).ToListAsync();
            return students;
        }

        public async Task AddAsync(Student student)
        {   
           
            await _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            var std = await _db.Students.FindAsync(student.Id);
            if (std != null)
            {
                std.User = student.User;
                std.RollNumber = student.RollNumber;
                std.PhoneNumber = student.PhoneNumber;
                std.Address = student.Address;
                std.ModifiedAt = DateTime.Now;
                await _db.SaveChangesAsync();
            }
        }


        public async Task DeleteAsync(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student != null)
            {
                student.IsDeleted = true;
                student.IsActive = false;
                student.ModifiedAt = DateTime.Now;
                await _db.SaveChangesAsync();
            }
        }

       
    }
}
