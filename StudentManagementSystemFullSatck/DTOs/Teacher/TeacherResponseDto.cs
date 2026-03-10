using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystemFullStack.DTOs.Teacher
{
    public class TeacherResponseDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Qualification { get; set; } = string.Empty;
    }
}
