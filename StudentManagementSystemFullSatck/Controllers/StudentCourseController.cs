using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemFullStack.DTOs.StudentCourse;
using StudentManagementSystemFullStack.Services.Interfaces;

namespace StudentManagementSystemFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IStudentCourseService _service;

        public StudentCourseController(IStudentCourseService service)
        {
            _service = service;
        }

        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetByStudentId(int studentId)
        {
            try
            {
                var courses = await _service.GetByStudentIdAsync(studentId);
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetByCourseId(int courseId)
        {
            try
            {
                var students = await _service.GetByCourseIdAsync(courseId);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var sc = await _service.GetAllAsync();
                return Ok(sc);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AssignCourse(AssignCourseToStudentDto dto)
        {
            try
            {
                await _service.AssignCourseAsync(dto);
                return Ok("Course assigned successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveCourse(int Id)
        {
            try
            {
                await _service.RemoveCourseAsync(Id);
                return Ok("Course removed successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}