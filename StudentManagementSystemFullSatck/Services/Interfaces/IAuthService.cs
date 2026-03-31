using StudentManagementSystemFullStack.DTOs.Auth;
using StudentManagementSystemFullStack.DTOs.ForgotPass;

namespace StudentManagementSystemFullStack.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginDto dto);


    }
}