using StudentManagementSystemFullStack.DTOs.TeacherCourse;
using StudentManagementSystemFullStack.Models;
using  StudentManagementSystemFullStack.Repositories;
using StudentManagementSystemFullStack.Repositories.Interfaces;
using StudentManagementSystemFullStack.Services.Interfaces;

namespace StudentManagementSystemFullStack.Services.Implementations
{
    public class TeacherCourseService : ITeacherCourseService
    {
        private readonly ITeacherCourseRepository _repo;

        public TeacherCourseService(ITeacherCourseRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TeacherCourseResponseDto>> GetByTeacherIdAsync(int teacherId)
        {
            var tc = await _repo.GetByTeacherIdAsync(teacherId);
            return tc.Select(t => new TeacherCourseResponseDto
            {
                Id = t.Id,
                TeacherName = t.Teacher.User.FullName,
                Department = t.Teacher.Department,
                CourseName = t.Course.CourseName,
                CourseCode = t.Course.CourseCode,
                AssignedAt = t.CreatedAt
            });
        }

        public async Task<IEnumerable<TeacherCourseResponseDto>> GetByCourseIdAsync(int courseId)
        {
            var tc = await _repo.GetByCourseIdAsync(courseId);
            return tc.Select(t => new TeacherCourseResponseDto
            {
                Id = t.Id,
                TeacherName = t.Teacher.User.FullName,
                Department = t.Teacher.Department,
                CourseName = t.Course.CourseName,
                CourseCode = t.Course.CourseCode,
                AssignedAt = t.CreatedAt
            });
        }

        public async Task AssignCourseAsync(AssignCourseToTeacherDto dto)
        {
            var teacherCourse = new TeacherCourse
            {
                TeacherId = dto.TeacherId,
                CourseId = dto.CourseId,
                CreatedAt = DateTime.Now
            };
            await _repo.AddAsync(teacherCourse);
        }

        public async Task RemoveCourseAsync(int teacherId, int courseId)
        {
            await _repo.DeleteAsync(teacherId, courseId);
        }
    }
}