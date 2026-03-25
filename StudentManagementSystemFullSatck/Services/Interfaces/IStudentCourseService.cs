using StudentManagementSystemFullStack.DTOs.StudentCourse;

namespace StudentManagementSystemFullStack.Services.Interfaces
{
    public interface IStudentCourseService
    {
        Task<IEnumerable<StudentCourseResponseDto>> GetByStudentIdAsync(int studentId);
        Task<IEnumerable<StudentCourseResponseDto>> GetByCourseIdAsync(int courseId);
        Task<IEnumerable<StudentCourseResponseDto>> GetAllAsync();
        Task AssignCourseAsync(AssignCourseToStudentDto dto);
        Task RemoveCourseAsync(int ScId);
    }
}
