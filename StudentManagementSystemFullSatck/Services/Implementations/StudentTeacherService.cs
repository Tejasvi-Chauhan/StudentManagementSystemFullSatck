using StudentManagementSystemFullStack.DTOs.StudentTeacher;
using StudentManagementSystemFullStack.Models;
using StudentManagementSystemFullStack.Repositories.Interfaces;
using StudentManagementSystemFullStack.Services.Interfaces;

namespace StudentManagementSystemFullStack.Services.Implementations
{
    public class StudentTeacherService : IStudentTeacherService
    {
        private readonly IStudentTeacherRepository _repo;

        public StudentTeacherService(IStudentTeacherRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<StudentTeacherResponseDto>> GetByStudentIdAsync(int studentId)
        {
            var st = await _repo.GetByStudentIdAsync(studentId);
            return st.Select(s => new StudentTeacherResponseDto
            {
                Id = s.Id,
                StudentName = s.Student.User.FullName,
                RollNumber = s.Student.RollNumber,
                TeacherName = s.Teacher.User.FullName,
                TeacherDepartment = s.Teacher.Department,
                AssignedAt = s.CreatedAt
            });
        }

        public async Task<IEnumerable<StudentTeacherResponseDto>> GetByTeacherIdAsync(int teacherId)
        {
            var st = await _repo.GetByTeacherIdAsync(teacherId);
            return st.Select(s => new StudentTeacherResponseDto
            {
                Id = s.Id,
                StudentName = s.Student.User.FullName,
                RollNumber = s.Student.RollNumber,
                TeacherName = s.Teacher.User.FullName,
                TeacherDepartment = s.Teacher.Department,
                AssignedAt = s.CreatedAt
            });
        }

        public async Task<IEnumerable<StudentTeacherResponseDto>> GetAllAsync()
        {
            var st = await _repo.GetAllAsync();
            return st.Select(s => new StudentTeacherResponseDto
            {
                Id = s.Id,
                StudentName = s.Student.User.FullName,
                RollNumber = s.Student.RollNumber,
                TeacherName = s.Teacher.User.FullName,
                TeacherDepartment = s.Teacher.Department,
                AssignedAt = s.CreatedAt
            });

        }

        public async Task AssignTeacherAsync(AssignTeacherDto dto)
        {
            var studentTeacher = new StudentTeacher
            {
                StudentId = dto.StudentId,
                TeacherId = dto.TeacherId,
                CreatedAt = DateTime.Now
            };
            await _repo.AddAsync(studentTeacher);
        }

        public async Task RemoveTeacherAsync(int Id)
        {
            await _repo.DeleteAsync(Id);
        }
    }
}