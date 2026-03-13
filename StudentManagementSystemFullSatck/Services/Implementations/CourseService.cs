using System.Linq;
using StudentManagementSystemFullStack.DTOs.Course;
using StudentManagementSystemFullStack.Services.Interfaces;
using StudentManagementSystemFullStack.Repositories.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;





namespace StudentManagementSystemFullStack.Services.Implementations
{
    public class CourseService : ICourseService
    {   

         private readonly ICourseRepository _repo;
        public CourseService(ICourseRepository repo)
        {
            _repo= repo;
        }

        public async Task<CourseDto?> GetByIdAsync(int id)
        {
            
                var course = await _repo.GetByIdAsync(id);
                if (course == null) {
                    return null;
            }
            var courseDto = new CourseDto
                {
                    CourseName = course.CourseName,
                    CourseCode = course.CourseCode
                };
                return courseDto;
         
        }
        public async Task<IEnumerable<CourseDto>> GetAllAsync()
        {
            var courses = await  _repo.GetAllAsync();
            
             var courseDtos = courses.Select(course => new CourseDto
            {
                CourseName = course.CourseName,
                CourseCode = course.CourseCode
            });
            return courseDtos;
        }

        public async Task AddAsync(CourseDto course)
        {
            var newCourse = new Models.Course
            {

                CourseName = course.CourseName,
                CourseCode = course.CourseCode
            };
            await _repo.AddAsync(newCourse);
        }

        public async Task DeleteAsync(int id)
        {
           await _repo.DeleteAsync(id);
        }

        

    
    }
}
