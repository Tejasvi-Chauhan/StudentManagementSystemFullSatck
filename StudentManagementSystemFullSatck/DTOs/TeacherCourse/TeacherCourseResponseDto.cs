namespace StudentManagementSystemFullStack.DTOs.TeacherCourse
{
    public class TeacherCourseResponseDto
    {
        public int Id { get; set; }
        public string TeacherName { get; set; }=string.Empty;
        public string? Department { get; set; }
         public string CourseName { get; set; }= string.Empty;
        public string CourseCode {  get; set; }=string.Empty;
        public string AssignedBy {  get; set; }=string.Empty;
        public DateTime AssignedAt { get; set; }

    }
}
