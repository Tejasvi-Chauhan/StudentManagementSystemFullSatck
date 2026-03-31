using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystemFullStack.DTOs.ForgotPass
{
    public class ForgotPasswordDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;
    }

    public class ResetPasswordDto
    {
        [Required(ErrorMessage = "Token is required.")]
        public string Token { get; set; } = string.Empty;
        [Required(ErrorMessage = "New password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string NewPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirm password is required.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
