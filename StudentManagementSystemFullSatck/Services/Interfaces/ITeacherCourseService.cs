using StudentManagementSystemFullStack.DTOs.TeacherCourse;

namespace StudentManagementSystemFullStack.Services.Interfaces
{
    public interface ITeacherCourseService
    {
        Task<IEnumerable<TeacherCourseResponseDto>> GetByTeacherIdAsync(int teacherId);
        Task<IEnumerable<TeacherCourseResponseDto>> GetByCourseIdAsync(int courseId);
        Task<IEnumerable<TeacherCourseResponseDto>> GetAllAsync();
        Task AssignCourseAsync(AssignCourseToTeacherDto dto);
        Task RemoveCourseAsync(int Id);
    }
}