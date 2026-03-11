using StudentManagementSystemFullStack.Models;

namespace StudentManagementSystemFullStack.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course?> GetByIdAsync(int id);

        Task <IEnumerable<Course>> GetAllAsync();

        Task AddAsync(Course course);
        Task DeleteAsync(int id);


    }
}
