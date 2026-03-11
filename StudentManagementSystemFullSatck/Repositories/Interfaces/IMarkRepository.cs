using StudentManagementSystemFullStack.Models;

namespace StudentManagementSystemFullStack.Repositories.Interfaces
{
    public interface IMarkRepository
    {
        Task<IEnumerable<Mark>> GetByStudentIdAsync(int StudentId);
        Task AddAsync(Mark mark);

        Task UpdateAsync(Mark mark);
        Task DeleteAsync(int id);
      
    }
}
