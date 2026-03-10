using System.ComponentModel.DataAnnotations;
namespace StudentManagementSystemFullStack.DTOs.Marks
{
    public class AddMarksDto
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        [Range(0,100,ErrorMessage ="Marks must be between 0 and 100")]
         public decimal MarksObtained { get; set; }
        
        [Required]
        public decimal TotalMarks { get; set; }= 100;

        [Required]

        public string Grade { get; set; } = string.Empty;

    }
}
