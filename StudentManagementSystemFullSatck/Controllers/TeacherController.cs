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
            var teachers = await _service.GetByIdAsync(id);
            if(teachers==null)
            {
                return NotFound("Teacher not found");

            }
            return Ok(teachers);
        }

        [HttpGet]

        public async Task<IActionResult> GetAll() {
            var teachers = await _service.GetAllAsync();
            return Ok(teachers);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateTeacherDto teacher) {
            await _service.AddAsync(teacher);
            return Ok("Teacher added successfully");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Teacher deleted successfully");
        }
    }
}
