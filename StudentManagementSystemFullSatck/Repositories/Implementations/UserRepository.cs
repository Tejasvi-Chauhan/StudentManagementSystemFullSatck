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

        public async Task<User?> GetByResetTokenAsync(string token)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.ResetToken == token && u.ResetTokenExpiry > DateTime.UtcNow && u.IsActive && !u.IsDeleted);
            return user;
        }

        public async Task UpdateAsync(User user)
        {
            _db.Users.Update(user);
           
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();

        }
    }
}

  
