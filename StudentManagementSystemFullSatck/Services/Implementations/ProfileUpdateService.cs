
using StudentManagementSystemFullStack.DTOs.ProfileRequest;
using StudentManagementSystemFullStack.Models;
using StudentManagementSystemFullStack.Repositories.Interfaces;
using StudentManagementSystemFullStack.Services.Interfaces;
using System.Linq;

namespace StudentManagementSystemFullStack.Services.Implementations
{
    public class ProfileUpdateService : IProfileUpdateService
    {
        private readonly IProfileRequestRepository _repo;

        public ProfileUpdateService(IProfileRequestRepository repo)
        {
            _repo = repo;
        }


        public async Task<IEnumerable<RequestResponseDto>> GetByStudentIdAsync(int id)
        {
            var profile = await _repo.GetByStudentIdAsync(id);
            var response = profile.Select(profile => new RequestResponseDto
            {
                Id = profile.Id,
                StudentId=profile.StudentId,
                FullName=profile.Student.User.FullName,
                FieldName=profile.FieldName,
                OldValue=profile.OldValue,
                NewValue=profile.NewValue,
                Status=profile.Status,
                ReviewerName=profile.ReviewedBy !=null ?profile.Reviewer.FullName : null,
            }
            
            
            );
            return response;




        }
        public async Task<IEnumerable<RequestResponseDto>> GetAllPendingAsync()
        {
             var requests= await _repo.GetAllPendingAsync();
            var response =  requests.Select(r
                => new RequestResponseDto
                {
                    Id = r.Id,
                    StudentId = r.StudentId,
                    FullName = r.Student.User.FullName,
                    FieldName = r.FieldName,
                    OldValue = r.OldValue,
                    NewValue = r.NewValue,
                    Status = r.Status,

                });
            return response;
        }

        public async Task CreateAsync(CreateRequestDto dto, int studentId)
        {
            var newreq = new ProfileUpdateRequest
            { 
               StudentId=studentId,
               FieldName = dto.FieldName,
               OldValue = dto.OldValue,
               NewValue = dto.NewValue,
               Status="Pending",
               CreatedAt=DateTime.Now,
               
            
            };

            await _repo.AddAsync(newreq );

        }


        public async Task UpdateAsync(int id, UpdateStatusDto dto)
        {
            var req= await  _repo.GetByIdAsync(id);
            if (req == null) throw new Exception("Request Not found");

            req.Status = dto.status;
           req.ReviewedBy = dto.ReviewedBy;
            req.ReviewedAt=DateTime.Now;
            req.ModifiedAt= DateTime.Now;
            
            await _repo.UpdateAsync(req);

            
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

    }
}
