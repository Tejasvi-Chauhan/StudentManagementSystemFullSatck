using StudentManagementSystemFullStack.Data;
using StudentManagementSystemFullStack.Models;
using StudentManagementSystemFullStack.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystemFullStack.Repositories.Implementations
{
    public class ProfileRequestRepository : IProfileRequestRepository
    {
        private readonly AppDbContext _db;

        public ProfileRequestRepository(AppDbContext db)
        {
                       _db = db;

        }
        public async Task<IEnumerable<ProfileUpdateRequest>> GetByStudentIdAsync(int studentId)
        {
            var req = await _db.ProfileUpdateRequests.Where(r => r.StudentId == studentId && !r.IsDeleted && r.IsActive).ToListAsync();
            return req;
        }

        public async Task<IEnumerable<ProfileUpdateRequest>> GetAllPendingAsync()
        {
            var req = await _db.ProfileUpdateRequests.Where(r => r.Status == "Pending" && !r.IsDeleted && r.IsActive).ToListAsync();
            return req;
        }

        public async Task<ProfileUpdateRequest?> GetByIdAsync(int id)
        {
            return await _db.ProfileUpdateRequests
        .Include(p => p.Student)
            .ThenInclude(s => s.User)  
        .Include(p => p.Reviewer)
        .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
        }
        public async Task AddAsync(ProfileUpdateRequest request)
        {
            await _db.ProfileUpdateRequests.AddAsync(request);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProfileUpdateRequest request)
        {
            var req = await _db.ProfileUpdateRequests.FindAsync(request.Id);
            if (req != null)
            {
                req.Status = request.Status;
                req.ModifiedAt= DateTime.Now;
                await _db.SaveChangesAsync();
            }
        }
        
        public async Task DeleteAsync(int id)
        {
            var req = await _db.ProfileUpdateRequests.FindAsync(id);
            if (req!=null)
            {
                 req.IsDeleted = true;
                req.IsActive = false;
                req.ModifiedAt = DateTime.Now;
                await _db.SaveChangesAsync();


            }
        }
           
            
        
    }
}
