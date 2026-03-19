using StudentManagementSystemFullStack.DTOs.Auth;

namespace StudentManagementSystemFullStack.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginDto dto);
    }
}
