using StudentManagementSystemFullStack.Data;
using StudentManagementSystemFullStack.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace StudentManagementSystemFullStack.Repositories.Implementations
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly AppDbContext _db;

        public StudentCourseRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Models.StudentCourse>> GetByStudentIdAsync(int studentId)
        {
            var studentCourses = await _db.StudentCourses.Include(sc=>sc.Student).ThenInclude(s=>s.User).Include(sc=>sc.Course).Where(sc=> sc.StudentId == studentId && sc.IsActive && !sc.IsDeleted).ToListAsync();
            return studentCourses;


        }
        public async Task<IEnumerable<Models.StudentCourse>> GetByCourseIdAsync(int courseId)
        {
             var sc= await _db.StudentCourses.Include(sc => sc.Student).ThenInclude(s => s.User).Include(sc => sc.Course).Where(sc => sc.CourseId == courseId && sc.IsActive && !sc.IsDeleted).ToListAsync();
              return sc;
        }

        public async Task<IEnumerable<Models.StudentCourse>> GetAllAsync()
        {
            var StCourse = await _db.StudentCourses
             .Where(m => !m.IsDeleted && m.IsActive).Include(m=>m.Student).ThenInclude(m=> m.User).Include(m=>m.Course).ToListAsync();
            return StCourse;
        }
        public async Task AddAsync(Models.StudentCourse studentCourse)
        {
           await _db.StudentCourses.AddAsync(studentCourse);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int ScId)
        {
            var sc = await _db.StudentCourses.FirstOrDefaultAsync(sc => ScId ==sc.Id);
            if (sc != null)
            {
                sc.IsActive = false;
                sc.IsDeleted = true;
                sc.ModifiedAt = DateTime.Now;
               
                await _db.SaveChangesAsync();

            }
        }

       
    }
}
