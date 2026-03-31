using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemFullStack.DTOs.Auth;
using StudentManagementSystemFullStack.DTOs.ForgotPass;
using StudentManagementSystemFullStack.Services.Interfaces;

namespace StudentManagementSystemFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly IForgotPasswordService _forgotPasswordService;

        public AuthController(IAuthService service, IForgotPasswordService forgotPasswordService)
        {
            _service = service;
            _forgotPasswordService = forgotPasswordService;
        }
       
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            try
            {
                var response = await _service.LoginAsync(dto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto dto)
        {
            try
            {
                await _forgotPasswordService.ForgotPasswordAsync(dto.Email);
                return Ok("Reset link sent");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

            }

        [HttpPost("reset-password")]

        public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
        {
            try
            {
                await _forgotPasswordService.ResetPasswordAsync(dto);
                return Ok("Password reset successful");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        }
}
