using System.ComponentModel.DataAnnotations;    
namespace StudentManagementSystemFullStack.DTOs.Course
{
    public class CourseDto
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="CourseName is Required")]

        public string CourseName { get; set; } = string.Empty;
        [Required(ErrorMessage ="CourseCode is required")]
        public string CourseCode { get; set; } = string.Empty;
       
     
    }
}
