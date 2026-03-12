using StudentManagementSystemFullStack.DTOs.Teacher;
namespace StudentManagementSystemFullStack.Services.Interfaces
{
    public interface ITeacherService
    {
            Task<TeacherResponseDto?> GetByIdAsync(int id);
            Task<IEnumerable<TeacherResponseDto>> GetAllAsync();
            Task AddAsync(CreateTeacherDto teacherCreateDto);
            Task DeleteAsync(int id);
    }
}
