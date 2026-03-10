namespace StudentManagementSystemFullStack.Models
{
    public class StudentCourse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public string AssignedBy { get; set; } = string.Empty;

        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

        public Student Student { get; set; } = null!; 

        public Course Course { get; set; } = null!; 

        public User User { get; set; } = null!;
    }
}
