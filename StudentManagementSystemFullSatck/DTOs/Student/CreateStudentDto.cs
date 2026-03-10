using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystemFullStack.DTOs.Student
{
    public class CreateStudentDto
    {
        [Required(ErrorMessage ="Name is required")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Email format is invalid")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage ="Password is required")]
        [MinLength(8,ErrorMessage ="Minimum 8 characters required")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage =("RollNumber required"))]
        public string RollNumber { get; set; } = string.Empty;

        [Required(ErrorMessage ="Address is required")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage ="Phone number is required")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "Date of Birth number is required")]
        public DateTime DateOfBirth { get; set; }
    }
}
