using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemFullStack.DTOs.Course;
using StudentManagementSystemFullStack.DTOs.Student;
using StudentManagementSystemFullStack.Services.Interfaces;
namespace StudentManagementSystemFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service) {

            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var course = await _service.GetByIdAsync(id);
                if (course == null) return NotFound("Course not found");
                return Ok(course);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var courses = await _service.GetAllAsync();
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CourseDto course) {

            try
            {
                  await _service.AddAsync(course);
                return Ok("Course added successfully");
            }
            catch (Exception ex) { 
                return StatusCode(500, ex.Message);

            }

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok("Course deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



    }
}
