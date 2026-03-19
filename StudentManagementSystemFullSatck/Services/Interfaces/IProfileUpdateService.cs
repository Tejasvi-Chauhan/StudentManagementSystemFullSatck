using StudentManagementSystemFullStack.DTOs.ProfileRequest;

namespace StudentManagementSystemFullStack.Services.Interfaces
{
    public interface IProfileUpdateService
    {
        Task<IEnumerable<RequestResponseDto>> GetByStudentIdAsync(int id);
        Task<IEnumerable<RequestResponseDto>> GetAllPendingAsync();
        Task CreateAsync(CreateRequestDto dto, int StudentId);
        Task UpdateAsync(int id, UpdateStatusDto dto);
        Task DeleteAsync(int id);
            
    }
}
