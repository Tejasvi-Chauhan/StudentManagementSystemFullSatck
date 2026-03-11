using StudentManagementSystemFullStack.Models;

namespace StudentManagementSystemFullStack.Repositories.Interfaces
{
    public interface ITeacherRepository
    {

        Task<Teacher?> GetByIdAsync(int id);

        Task <IEnumerable<Teacher>> GetAllAsync();

        Task AddAsync(Teacher teacher);

        Task DeleteAsync(int id);
    }
}
