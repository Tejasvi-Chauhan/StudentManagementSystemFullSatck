using StudentManagementSystemFullStack.DTOs.ForgotPass;
using StudentManagementSystemFullStack.Repositories.Implementations;
using StudentManagementSystemFullStack.Repositories.Interfaces;
using StudentManagementSystemFullStack.Services.Interfaces;

namespace StudentManagementSystemFullStack.Services.Implementations
{
    public class ForgotPasswordService : IForgotPasswordService
    {   
        private readonly IUserRepository _repo;
        private readonly IEmailService _emailService;

        public ForgotPasswordService(IUserRepository repo, IEmailService emailService)
        {
            _repo = repo;
            _emailService = emailService;
        }

     
        public async Task ForgotPasswordAsync(string email)
        {
            try
            {
                var user = await _repo.GetByEmailId(email);

                if (user == null) throw new Exception("User not found");

                var token = Guid.NewGuid().ToString();

                user.ResetToken = token;
                user.ResetTokenExpiry = DateTime.UtcNow.AddMinutes(15);

                await _repo.UpdateAsync(user);

                await _repo.SaveAsync();

                var resetLink = $"http://localhost:5173/reset-password?token={token}";

                var subject = "Reset Password";

                var body = $@" <h3>Reset Password</h3> <a href='{resetLink}'>Click here</a>";

                await _emailService.SendEmailAsync(user.Email, subject, body);

            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while processing the forgot password request: {ex.Message}");
            }


            }

        public async Task ResetPasswordAsync(ResetPasswordDto dto)
        {
            try
            {
                var user = await _repo.GetByResetTokenAsync(dto.Token);
                if (user == null)
                    throw new Exception("Invalid or expired token");
                if(dto.NewPassword != dto.ConfirmPassword)
                    throw new Exception("Passwords do not match");

                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
                user.ResetToken = null;
                user.ResetTokenExpiry = null;
                await _repo.UpdateAsync(user);
                await _repo.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while resetting the password: {ex.Message}");
            }
        }
        }
}
