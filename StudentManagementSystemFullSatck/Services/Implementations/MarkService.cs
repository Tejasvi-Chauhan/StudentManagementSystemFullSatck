using StudentManagementSystemFullStack.DTOs.Marks;
using StudentManagementSystemFullStack.Services.Interfaces;
using StudentManagementSystemFullStack.Repositories.Interfaces;
using StudentManagementSystemFullStack.Models;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystemFullStack.Services.Implementations
{
    public class MarkService : IMarkService
    {     
        private readonly IMarkRepository _repo;
        public MarkService(IMarkRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<MarksResponseDto>> GetByStudentIdAsync(int id)
        {


            var mark = await _repo.GetByStudentIdAsync(id);
            var response = mark.Select(mark => new MarksResponseDto
            {
                Id = mark.Id,
                StudentName = mark.Student.User.FullName,
                CourseName = mark.Course.CourseName,
                TeacherName = mark.Teacher.User.FullName,
                MarksObtained = mark.MarksObtained,
                TotalMarks = mark.TotalMarks,
                Grade = mark.Grade
            });
            return response;
        
        }

        public async Task AddAsync(AddMarksDto marks)
        {
            var newMarks = new Mark
            {
                StudentId = marks.StudentId,
                CourseId = marks.CourseId,
                TeacherId = marks.TeacherId,
                MarksObtained = marks.MarksObtained,
                TotalMarks = marks.TotalMarks,
                Grade = marks.Grade
            };
            await _repo.AddAsync(newMarks);
        }

        public async Task UpdateAsync(int id, UpdateMarksDto marks)
        {
            var existing = await _repo.GetByStudentIdAsync(id);

            var mark = existing.FirstOrDefault(m => m.Id == marks.Id);

            if (mark == null) throw new Exception("Mark not found");

            mark.MarksObtained = marks.MarksObtained;
            mark.TotalMarks = marks.TotalMarks;
            mark.Grade = marks.Grade;
            mark.ModifiedAt = DateTime.Now;
            await _repo.UpdateAsync(mark);
        }
        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);

            
        }

    }
}
