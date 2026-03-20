using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystemFullStack.DTOs.StudentTeacher
{
    public class AssignTeacherDto
    {
        [Required(ErrorMessage ="Student Id required")]
        public int StudentId { get; set; }

        [Required(ErrorMessage ="Teacher Id required")]
        public int TeacherId { get; set; }
    }
}
