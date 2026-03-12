using StudentManagementSystemFullStack.DTOs;
using StudentManagementSystemFullStack.DTOs.Student;
namespace StudentManagementSystemFullStack.Services.Interfaces
{
    public interface IStudentService
    {

           Task<StudentResponseDto?> GetByIdAsync(int id);
            Task<IEnumerable<StudentResponseDto>> GetAllAsync();
            Task AddAsync(CreateStudentDto dto);
            Task UpdateAsync(int id, UpdateStudentDto dto);
            Task DeleteAsync(int id);
        
    }
}
