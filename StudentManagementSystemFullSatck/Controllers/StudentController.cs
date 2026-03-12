using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemFullStack.Repositories.Interfaces;

using StudentManagementSystemFullStack.DTOs.Student;
using StudentManagementSystemFullStack.Services.Interfaces;

namespace StudentManagementSystemFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var student = await _service.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound("Student not found ");
            }
            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _service.GetAllAsync();
            return Ok(students);

        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateStudentDto student)
        {
            await _service.AddAsync(student);
            return Ok("Student added successfully");
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, UpdateStudentDto student)
        {
            await _service.UpdateAsync(id,student);
            return Ok("Student updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Student deleted successfully");
        }

    }
}
