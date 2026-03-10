using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystemFullStack.DTOs.Teacher
{
    public class CreateTeacherDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string FullName { get; set; }= string.Empty;

        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Email format is invalid")]
        public string Email { get; set; } = string.Empty;

         [Required(ErrorMessage ="Password is required")]
         [MinLength(8,ErrorMessage ="Minimum 8 characters required")]
        public string Password { get; set; } = string.Empty;

            
        public string Department { get; set; } = string.Empty;

        [Required(ErrorMessage ="PhoneNumber is required")]
        public string PhoneNumber { get; set; } = string.Empty;

            [Required(ErrorMessage = "Qualification is required")]
        public string Qualification { get; set; } = string.Empty;
     
    }
}
