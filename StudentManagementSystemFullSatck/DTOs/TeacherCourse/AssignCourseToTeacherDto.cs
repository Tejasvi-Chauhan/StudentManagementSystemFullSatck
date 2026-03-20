using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystemFullStack.DTOs.TeacherCourse
{
    public class AssignCourseToTeacherDto
    {
        [Required(ErrorMessage ="Teacher Id required")]
        public int TeacherId { get; set; }

        [Required(ErrorMessage ="Course Id required")]

        public int CourseId { get; set; }
    }
}
