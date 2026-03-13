namespace StudentManagementSystemFullStack.DTOs.Marks
{
    public class MarksResponseDto
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public string TeacherName { get; set; } = string.Empty;
        public decimal MarksObtained { get; set; }
        public decimal TotalMarks { get; set; }
        public string Grade { get; set; } = string.Empty;

    }
}
