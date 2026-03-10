using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystemFullStack.DTOs.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage="Inavlid Email format")]
        public string Email { get;set; } 

        [Required(ErrorMessage ="Password is required")]
        [MinLength(8, ErrorMessage ="Minimum 8 characters required")]
        public string Password { get; set; }

    }
}
