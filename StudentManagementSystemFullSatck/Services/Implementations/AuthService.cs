using Microsoft.EntityFrameworkCore;
using StudentManagementSystemFullStack.Data;
using StudentManagementSystemFullStack.DTOs.Auth;
using StudentManagementSystemFullStack.Services.Interfaces;
using StudentManagementSystemFullStack.Services.Implementations;
using StudentManagementSystemFullStack.Repositories.Interfaces;

namespace StudentManagementSystemFullStack.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repo;
        private readonly TokenService _tokenService;

        public AuthService(IUserRepository repo, TokenService tokenService)
        {
            _repo=repo;
            _tokenService = tokenService;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            
            var user = await _repo.GetByEmailId(dto.Email);
               

            if (user == null)
                throw new Exception("Invalid email or password");

             // Password check kiya
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(
                dto.Password, user.PasswordHash);

            if (!isPasswordValid)
                throw new Exception("Invalid email or password");

            // Token banaya
            var token = _tokenService.GenerateToken(user);

             // return the response
            return new AuthResponseDto
            {
                Token = token,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role,
                UserId = user.Id
            };
        }
    }
}
