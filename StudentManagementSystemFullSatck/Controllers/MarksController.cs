using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemFullStack.DTOs.Marks;
using StudentManagementSystemFullStack.Services.Interfaces;


namespace StudentManagementSystemFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly IMarkService _service;

        public MarksController(IMarkService service)
        {
            _service = service;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByStudentId(int Id)
        {
            try
            {
                var marks = await _service.GetByStudentIdAsync(Id);
                if (marks == null) return NotFound("Marks not found");
                return Ok(marks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMarksDto marks)
        {
            try
            {
                await _service.AddAsync(marks);
                return Ok("Marks added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{Id}")]

        public async Task<IActionResult> Update(int Id, UpdateMarksDto marks)
        {
            try
            {
                await _service.UpdateAsync(Id, marks);
                return Ok("Marks updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpDelete("{Id}")]

        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _service.DeleteAsync(Id);
                return Ok("Marks deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
