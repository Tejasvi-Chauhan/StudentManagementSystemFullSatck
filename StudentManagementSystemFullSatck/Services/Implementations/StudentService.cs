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

        private string GetBranchCode(string branch)
        {
            return string.Concat(branch
           .Split(' ').Select(word => word[0])).ToUpper();
        }

        private async Task<string> GenerateRollNumber(string branch)
        {
            var branchCode = GetBranchCode(branch);
            var students = await _repo.GetAllAsync();
            var lastStudent = students.Where(s => s.Branch == branch).OrderByDescending(s => s.Id).FirstOrDefault();

            int nextNumber = 1;
            if (lastStudent != null)
            {
                var numberPart = lastStudent.RollNumber.Substring(branchCode.Length);
                nextNumber = int.Parse(numberPart) + 1;


            }
            else
            {
                nextNumber = 1;
            }
            return $"{branchCode}{nextNumber.ToString("D4")}";
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
                Branch = st.Branch,
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
                Branch = s.Branch,
                Address = s.Address,
                PhoneNumber = s.PhoneNumber,
                DateOfBirth = s.DateOfBirth
            });
            return response;

        }

        public async Task AddAsync(CreateStudentDto dto)
        {  
            var rollnumber = await GenerateRollNumber(dto.Branch);
            var student = new Models.Student
            {
                User = new Models.User
                {
                    FullName = dto.FullName,
                    Email = dto.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                    Role= "Student",
                    CreatedAt=DateTime.Now,
                },
               RollNumber = rollnumber,
               Branch = dto.Branch,
               Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
                DateOfBirth = dto.DateOfBirth,
                CreatedAt= DateTime.Now,
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
