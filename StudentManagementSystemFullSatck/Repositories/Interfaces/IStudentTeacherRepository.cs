using StudentManagementSystemFullStack.Models;

namespace StudentManagementSystemFullStack.Repositories.Interfaces
{
    public interface IStudentTeacherRepository
    {

        Task <IEnumerable<StudentTeacher>> GetByStudentIdAsync(int studentId);
        Task <IEnumerable<StudentTeacher>> GetByTeacherIdAsync(int teacherId);

        Task AddAsync(StudentTeacher studentTeacher);
       
        Task DeleteAsync(int studentId, int teacherId);
        
    }
}
