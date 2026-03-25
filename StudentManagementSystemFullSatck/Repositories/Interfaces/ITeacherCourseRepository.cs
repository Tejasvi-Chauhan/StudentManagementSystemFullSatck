using StudentManagementSystemFullStack.Models;

namespace StudentManagementSystemFullStack.Repositories.Interfaces
{
    public interface ITeacherCourseRepository
    {
        Task<IEnumerable<TeacherCourse>> GetByTeacherIdAsync(int teacherId);
        Task<IEnumerable<TeacherCourse>> GetByCourseIdAsync(int courseId);
        Task<IEnumerable<TeacherCourse>> GetAllAsync();


        Task AddAsync(TeacherCourse teacherCourse);
        Task DeleteAsync(int id);
    }
}