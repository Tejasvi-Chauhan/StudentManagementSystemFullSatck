using StudentManagementSystemFullStack.Models;  
namespace StudentManagementSystemFullStack.Repositories.Interfaces
    
{
    public interface IProfileRequestRepository
    {

        Task<IEnumerable<ProfileUpdateRequest>> GetByStudentIdAsync(int studentId);
        Task <ProfileUpdateRequest> GetByIdAsync(int id);
        Task<IEnumerable<ProfileUpdateRequest>> GetAllPendingAsync();
        Task AddAsync(ProfileUpdateRequest request);

        Task UpdateAsync(ProfileUpdateRequest request);
        Task DeleteAsync(int id);
    }
}
