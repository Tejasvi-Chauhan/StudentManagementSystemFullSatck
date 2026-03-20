namespace StudentManagementSystemFullStack.DTOs.StudentCourse
{
    public class StudentCourseResponseDto
    {
        public int Id { get; set; }

        public string StudentName { get; set; }=string.Empty;

        public string RollNumber { get; set; } = string.Empty;

        public string CourseName { get; set; }= string.Empty;

        public string CourseCode { get; set; }= string.Empty;

        public string AssignedBy { get; set; } = string.Empty;

        public DateTime AssignedAt { get; set; }


    }
}
