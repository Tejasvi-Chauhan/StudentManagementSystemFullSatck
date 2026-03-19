using StudentManagementSystemFullStack.DTOs.Teacher;
using StudentManagementSystemFullStack.Repositories.Interfaces;
using StudentManagementSystemFullStack.Services.Interfaces;

namespace StudentManagementSystemFullStack.Services.Implementations
{
    public class TeacherService : ITeacherService
    {   
        private readonly ITeacherRepository _Repo;

        public TeacherService(ITeacherRepository repo)
        {
            _Repo = repo;
        }
        public async Task<TeacherResponseDto?> GetByIdAsync(int id)
        {
            var tr = await _Repo.GetByIdAsync(id);
            if (tr == null)
            {
                return null;
            }

            var response= new TeacherResponseDto
            {
                Id = tr.Id,
                FullName = tr.User.FullName,
                Email = tr.User.Email,
                Department = tr.Department,
                PhoneNumber = tr.PhoneNumber,
                Qualification = tr.Qualitfication
            };
            return response;
        }
        public async Task<IEnumerable<TeacherResponseDto>> GetAllAsync()
        {
            var tr= await _Repo.GetAllAsync();
            var response = tr.Select(t => new TeacherResponseDto
            {
                Id = t.Id,
                FullName = t.User.FullName,
                Email = t.User.Email,
                Department = t.Department,
                PhoneNumber = t.PhoneNumber,
                Qualification = t.Qualitfication
            });
            return response;
        }

        public async Task AddAsync(CreateTeacherDto teacherCreateDto)
        {
            var teacher = new Models.Teacher
            {
                User = new Models.User
                {
                    FullName = teacherCreateDto.FullName,
                    Email = teacherCreateDto.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(teacherCreateDto.Password) ,
                    Role = "Teacher"
                },
               
                Department = teacherCreateDto.Department,
                PhoneNumber = teacherCreateDto.PhoneNumber,
                Qualitfication = teacherCreateDto.Qualification
            };
            await _Repo.AddAsync(teacher);
        }

        public async Task DeleteAsync(int id)
        {
            await _Repo.DeleteAsync(id);

        }

      

       
    }
}
