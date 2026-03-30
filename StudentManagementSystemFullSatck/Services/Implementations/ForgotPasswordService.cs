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

                if (user == null) return;

                var token = Guid.NewGuid().ToString();

                user.ResetToken = token;
                user.ResetTokenExpiry = DateTime.UtcNow.AddMinutes(15);

                await _repo.SaveAsync();

                var resetLink = $"http://localhost:3000/reset-password?token={token}";

                var subject = "Reset Password";

                var body = $@" <h3>Reset Password</h3> <a href='{resetLink}'>Click here</a>";

                await _emailService.SendEmailAsync(user.Email, subject, body);

            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while processing the forgot password request: {ex.Message}");
            }


            }
    }
}
