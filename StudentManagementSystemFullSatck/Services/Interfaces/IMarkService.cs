using StudentManagementSystemFullStack.DTOs.Marks;
namespace StudentManagementSystemFullStack.Services.Interfaces
{
    public  interface  IMarkService
    {
        Task<IEnumerable<MarksResponseDto>> GetByStudentIdAsync(int id);

        Task<IEnumerable<MarksResponseDto>> GetAllAsync();
        Task AddAsync(AddMarksDto marks);
        Task UpdateAsync(int id, UpdateMarksDto marks);
        Task DeleteAsync(int id);
    }
}
