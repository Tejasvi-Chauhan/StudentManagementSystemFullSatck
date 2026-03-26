using StudentManagementSystemFullStack.Models;

namespace StudentManagementSystemFullStack.Repositories.Interfaces
{
    public interface IMarkRepository
    {
        Task<IEnumerable<Mark>> GetByIdAsync(int StudentId);

        Task<IEnumerable<Mark>> GetAllAsync();
        Task AddAsync(Mark mark);

        Task UpdateAsync(Mark mark);
        Task DeleteAsync(int id);
      
    }
}
