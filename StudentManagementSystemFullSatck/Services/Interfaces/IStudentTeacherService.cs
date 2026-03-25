using StudentManagementSystemFullStack.DTOs.StudentTeacher;

namespace StudentManagementSystemFullStack.Services.Interfaces
{
    public interface IStudentTeacherService
    {
        Task<IEnumerable<StudentTeacherResponseDto>> GetByStudentIdAsync(int studentId);
        Task<IEnumerable<StudentTeacherResponseDto>> GetByTeacherIdAsync(int teacherId);
        Task<IEnumerable<StudentTeacherResponseDto>> GetAllAsync();
        Task AssignTeacherAsync(AssignTeacherDto dto);
        Task RemoveTeacherAsync(int Id);
    }
}