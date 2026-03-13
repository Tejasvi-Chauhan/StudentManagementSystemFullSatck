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
            try {

                var student = await _service.GetByIdAsync(id);
                if (student == null)
                {
                    return NotFound("Student not found ");
                }
                return Ok(student);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var students = await _service.GetAllAsync();
                return Ok(students);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }


            }

        [HttpPost]
        public async Task<IActionResult> Add(CreateStudentDto student)
        {
            try
            {
                await _service.AddAsync(student);
                return Ok("Student added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

            }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, UpdateStudentDto student)
        {
            try
            {
                await _service.UpdateAsync(id, student);
                return Ok("Student updated successfully");
            }
            catch (Exception ex) {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

            }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok("Student deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");

            }
            }

    }
}
