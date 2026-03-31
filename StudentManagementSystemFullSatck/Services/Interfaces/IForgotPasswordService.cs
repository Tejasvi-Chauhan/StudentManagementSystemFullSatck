using StudentManagementSystemFullStack.DTOs.ForgotPass;

namespace StudentManagementSystemFullStack.Services.Interfaces
{
    public interface IForgotPasswordService
    {

        public Task ForgotPasswordAsync(String email);
        
        public Task ResetPasswordAsync(ResetPasswordDto dto);
    }
}
