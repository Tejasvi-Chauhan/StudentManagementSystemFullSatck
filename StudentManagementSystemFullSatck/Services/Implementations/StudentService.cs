using StudentManagementSystemFullStack.DTOs.Student;
using StudentManagementSystemFullStack.Repositories.Interfaces;
using StudentManagementSystemFullStack.Services.Interfaces;

namespace StudentManagementSystemFullStack.Services.Implementations
{
    public class StudentService : IStudentService


    {

        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }


        public async Task<StudentResponseDto?> GetByIdAsync(int id)
        {
            var st = await _repo.GetByIdAsync(id);
            if (st == null)
            {
                throw new Exception("Student not found");
            }
            var response = new StudentResponseDto
            {
                Id = st.Id,
                FullName = st.User.FullName,
                Email = st.User.Email,
                RollNumber = st.RollNumber,
                Address = st.Address,
                PhoneNumber = st.PhoneNumber,
                DateOfBirth = st.DateOfBirth
            };
            return response;
        }

        public async Task<IEnumerable<StudentResponseDto>> GetAllAsync()
        {
            var st = await _repo.GetAllAsync();
            var response = st.Select(s => new StudentResponseDto
            {
                Id = s.Id,
                FullName = s.User.FullName,
                Email = s.User.Email,
                RollNumber = s.RollNumber,
                Address = s.Address,
                PhoneNumber = s.PhoneNumber,
                DateOfBirth = s.DateOfBirth
            });
            return response;

        }

        public async Task AddAsync(CreateStudentDto dto)
        {
           var student = new Models.Student
            {
                User = new Models.User
                {
                    FullName = dto.FullName,
                    Email = dto.Email,
                    PasswordHash = dto.Password ,
                    Role= "Student"
                },
                RollNumber = dto.RollNumber,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
                DateOfBirth = dto.DateOfBirth
            };
            await _repo.AddAsync(student);
         
        }

        public async Task DeleteAsync(int id)
        {
                await _repo.DeleteAsync(id);
           
        }
        public async Task UpdateAsync(int id , UpdateStudentDto dto)
        {
            var student = await _repo.GetByIdAsync(id);
            if (student == null) throw new Exception("Student not found");

            student.User.FullName = dto.FullName;
            student.Address = dto.Address;
            student.PhoneNumber = dto.PhoneNumber;
            student.DateOfBirth = dto.DateOfBirth;
            student.ModifiedAt = DateTime.Now;
            await _repo.UpdateAsync(student);
          
        }
    }
}
