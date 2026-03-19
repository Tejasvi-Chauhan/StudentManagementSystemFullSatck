using StudentManagementSystemFullStack.Models;

namespace StudentManagementSystemFullStack.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailId(string email);

    }
}
