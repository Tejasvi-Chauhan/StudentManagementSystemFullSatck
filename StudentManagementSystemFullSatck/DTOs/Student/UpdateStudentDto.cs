using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystemFullStack.DTOs.Student
{
    public class UpdateStudentDto
    {
       

        [Required(ErrorMessage ="Name is Required")]
        public string FullName { get; set; }= string.Empty;

        public string Address { get; set; } = string.Empty;

        public string PhoneNumber { get; set; }=string.Empty;

        public DateTime DateOfBirth { get; set; }
    }
}
