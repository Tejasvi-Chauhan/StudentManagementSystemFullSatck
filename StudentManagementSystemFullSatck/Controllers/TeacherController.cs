using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemFullStack.DTOs.Teacher;
using StudentManagementSystemFullStack.Services.Interfaces;

namespace StudentManagementSystemFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _service;

        public TeacherController(ITeacherService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id) {

            try
            {
                var teachers = await _service.GetByIdAsync(id);
                if (teachers == null)
                {
                    return NotFound("Teacher not found");

                }
                return Ok(teachers);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetAll() {
            try
            {
                var teachers = await _service.GetAllAsync();
                return Ok(teachers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

            }

        [HttpPost]
        public async Task<IActionResult> Add(CreateTeacherDto teacher) {
            try
            {
                await _service.AddAsync(teacher);
                return Ok("Teacher added successfully");
            }
            catch(Exception ex) {
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
                }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {  
            try
            {

                await _service.DeleteAsync(id);
                return Ok("Teacher deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");

            }
            }
    }
}
