namespace StudentManagementSystemFullStack.Models
{
    public class StudentTeacher
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int TeacherId { get; set; }

        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

        public Student Student { get; set; } = null!;

        public Teacher Teacher { get; set; } = null!;
    }
}
