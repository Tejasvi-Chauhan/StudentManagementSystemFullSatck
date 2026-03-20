namespace StudentManagementSystemFullStack.DTOs.StudentTeacher
{
    public class StudentTeacherResponseDto
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = string.Empty;

        public string RollNumber { get; set; }= string.Empty;

        public string TeacherName { get; set; } = string.Empty;

        public string? TeacherDepartment { get; set; }
        public string AssignedBy { get; set; } = string.Empty;
        public DateTime AssignedAt { get; set; }


    }
}
