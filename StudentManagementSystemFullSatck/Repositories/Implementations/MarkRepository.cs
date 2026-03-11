using StudentManagementSystemFullStack.Data;
using StudentManagementSystemFullStack.Models;
using StudentManagementSystemFullStack.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystemFullStack.Repositories.Implementations
{
    public class MarkRepository : IMarkRepository
    {

        private readonly AppDbContext _db;

        public MarkRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Mark>> GetByStudentIdAsync(int StudentId)
        {
            var marks= await _db.Marks.Where(m=> m.StudentId == StudentId && !m.IsDeleted && m.IsActive).ToListAsync();
            return marks;
        }
        public async Task AddAsync(Mark mark)
        {
            await _db.Marks.AddAsync(mark);
            await _db.SaveChangesAsync();
        }

        public async  Task UpdateAsync(Mark mark)
        {
           var mk =  await _db.Marks.FindAsync(mark.Id);
            if(mk != null)
            {
                mk.MarksObtained = mark.MarksObtained;
                mk.TotalMarks = mark.TotalMarks;
                mk.Grade = mark.Grade;
                mk.ModifiedAt = DateTime.Now;
                await _db.SaveChangesAsync();
            }
            
        }

        public async  Task DeleteAsync(int id)
        {
            var mk = await _db.Marks.FindAsync(id);
            if(mk != null)
            {
                mk.IsDeleted = true;
                mk.IsActive = false;
                mk.ModifiedAt = DateTime.Now;
                await _db.SaveChangesAsync();
            }
        }

      

       
    }
}
