using StudentManagementSystemFullStack.Models;

namespace StudentManagementSystemFullStack.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailId(string email);

        Task<User?> GetByResetTokenAsync(string token); 

        Task UpdateAsync(User user); 

        Task SaveAsync();
    }
}