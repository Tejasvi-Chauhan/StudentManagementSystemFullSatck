using StudentManagementSystemFullStack.DTOs.Course;

namespace StudentManagementSystemFullStack.Services.Interfaces
{
    public interface ICourseService
    {
        Task<CourseDto?> GetByIdAsync(int id);
        Task<IEnumerable<CourseDto>> GetAllAsync();
        Task AddAsync(CourseDto course);
        Task DeleteAsync(int id);
    }
}
