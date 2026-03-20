using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemFullStack.DTOs.TeacherCourse;
using StudentManagementSystemFullStack.Services.Interfaces;

namespace StudentManagementSystemFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherCourseController : ControllerBase
    {
        private readonly ITeacherCourseService _service;

        public TeacherCourseController(ITeacherCourseService service)
        {
            _service = service;
        }

        [HttpGet("teacher/{teacherId}")]
        public async Task<IActionResult> GetByTeacherId(int teacherId)
        {
            try
            {
                var courses = await _service.GetByTeacherIdAsync(teacherId);
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
                var teachers = await _service.GetByCourseIdAsync(courseId);
                return Ok(teachers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AssignCourse(AssignCourseToTeacherDto dto)
        {
            try
            {
                await _service.AssignCourseAsync(dto);
                return Ok("Course assigned to teacher successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{teacherId}/{courseId}")]
        public async Task<IActionResult> RemoveCourse(int teacherId, int courseId)
        {
            try
            {
                await _service.RemoveCourseAsync(teacherId, courseId);
                return Ok("Course removed from teacher successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}