using Microsoft.EntityFrameworkCore;
using StudentManagementSystemFullStack.Data;
using StudentManagementSystemFullStack.Models;
using StudentManagementSystemFullStack.Repositories.Interfaces;

namespace StudentManagementSystemFullStack.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;
        public UserRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<User?> GetByEmailId(string email)
        {
            var user = await _db.Users.FirstOrDefaultAsync(e => e.Email == email && e.IsActive && !e.IsDeleted);

            return user;
        }

        }
    }

  
