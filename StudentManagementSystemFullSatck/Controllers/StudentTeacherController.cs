using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemFullStack.DTOs.StudentTeacher;
using StudentManagementSystemFullStack.Services.Interfaces;

namespace StudentManagementSystemFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentTeacherController : ControllerBase
    {
        private readonly IStudentTeacherService _service;

        public StudentTeacherController(IStudentTeacherService service)
        {
            _service = service;
        }

        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetByStudentId(int studentId)
        {
            try
            {
                var teachers = await _service.GetByStudentIdAsync(studentId);
                return Ok(teachers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("teacher/{teacherId}")]
        public async Task<IActionResult> GetByTeacherId(int teacherId)
        {
            try
            {
                var students = await _service.GetByTeacherIdAsync(teacherId);
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
                var st = await _service.GetAllAsync();
                return Ok(st);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AssignTeacher(AssignTeacherDto dto)
        {
            try
            {
                await _service.AssignTeacherAsync(dto);
                return Ok("Teacher assigned successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveTeacher(int Id)
        {
            try
            {
                await _service.RemoveTeacherAsync(Id);
                return Ok("Teacher removed successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}