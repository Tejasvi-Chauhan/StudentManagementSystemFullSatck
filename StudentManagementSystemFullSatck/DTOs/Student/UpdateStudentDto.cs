using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystemFullStack.DTOs.Student
{
    public class UpdateStudentDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        public string FullName { get; set; }= string.Empty;

        [Required(ErrorMessage ="Address is Required")]
        public string Address { get; set; } = string.Empty;

            [Required(ErrorMessage ="Phone number is Required")]
        public string PhoneNumber { get; set; }=string.Empty;

            [Required(ErrorMessage = "Date of Birth number is required")]
        public DateTime DateOfBirth { get; set; }
    }
}
