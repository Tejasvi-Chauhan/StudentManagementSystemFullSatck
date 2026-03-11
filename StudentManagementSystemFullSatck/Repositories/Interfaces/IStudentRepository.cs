using StudentManagementSystemFullStack.Models;
namespace StudentManagementSystemFullStack.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student?> GetByIdAsync(int id);
        Task<IEnumerable<Student>> GetAllAsync();
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);

    }
}
