using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystemFullStack.DTOs.StudentCourse
{
    public class AssignCourseToStudentDto
    {
        [Required(ErrorMessage ="Student Id required")]
        public int StudentId { get; set; }

        [Required(ErrorMessage ="Course Id required")]
        public int CourseId { get; set; }


    }
}
