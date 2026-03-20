using StudentManagementSystemFullStack.DTOs.StudentCourse;
using StudentManagementSystemFullStack.Models;
using StudentManagementSystemFullStack.Repositories.Interfaces;
using StudentManagementSystemFullStack.Services.Interfaces;

namespace StudentManagementSystemFullStack.Services.Implementations
{
    public class StudentCourseService : IStudentCourseService
    {
        private readonly IStudentCourseRepository _repo;

        public StudentCourseService(IStudentCourseRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<StudentCourseResponseDto>> GetByStudentIdAsync(int studentId)
        {
            var sc = await _repo.GetByStudentIdAsync(studentId);
            return sc.Select(s => new StudentCourseResponseDto
            {
                Id = s.Id,
                StudentName = s.Student.User.FullName,
                RollNumber = s.Student.RollNumber,
                CourseName = s.Course.CourseName,
                CourseCode = s.Course.CourseCode,
                AssignedAt = s.CreatedAt
            });
        }

        public async Task<IEnumerable<StudentCourseResponseDto>> GetByCourseIdAsync(int courseId)
        {
            var sc = await _repo.GetByCourseIdAsync(courseId);
            return sc.Select(s => new StudentCourseResponseDto
            {
                Id = s.Id,
                StudentName = s.Student.User.FullName,
                RollNumber = s.Student.RollNumber,
                CourseName = s.Course.CourseName,
                CourseCode = s.Course.CourseCode,
                AssignedAt = s.CreatedAt
            });
        }

        public async Task AssignCourseAsync(AssignCourseToStudentDto dto)
        {
            var studentCourse = new StudentCourse
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId,
                CreatedAt = DateTime.Now
            };
            await _repo.AddAsync(studentCourse);
        }

        public async Task RemoveCourseAsync(int studentId, int courseId)
        {
            await _repo.DeleteAsync(studentId, courseId);
        }
    }
}