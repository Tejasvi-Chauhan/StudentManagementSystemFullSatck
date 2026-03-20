using StudentManagementSystemFullStack.DTOs.StudentCourse;

namespace StudentManagementSystemFullStack.Services.Interfaces
{
    public interface IStudentCourseService
    {
        Task<IEnumerable<StudentCourseResponseDto>> GetByStudentIdAsync(int studentId);
        Task<IEnumerable<StudentCourseResponseDto>> GetByCourseIdAsync(int courseId);
        Task AssignCourseAsync(AssignCourseToStudentDto dto);
        Task RemoveCourseAsync(int studentId, int courseId);
    }
}
