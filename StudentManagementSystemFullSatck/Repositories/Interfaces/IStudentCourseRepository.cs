using StudentManagementSystemFullStack.Models;

namespace StudentManagementSystemFullStack.Repositories.Interfaces
{
    public interface IStudentCourseRepository
    {
          Task<IEnumerable<StudentCourse>> GetByStudentIdAsync(int studentId);
          Task<IEnumerable<StudentCourse>> GetByCourseIdAsync(int courseId);
        Task<IEnumerable<StudentCourse>> GetAllAsync();

        Task AddAsync(StudentCourse studentCourse);

        Task DeleteAsync(int ScId);


    }
}
