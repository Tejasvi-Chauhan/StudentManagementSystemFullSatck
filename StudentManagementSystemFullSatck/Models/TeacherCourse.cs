namespace StudentManagementSystemFullStack.Models
{
    public class TeacherCourse
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }

        public int CourseId { get; set; }

        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

        public Teacher Teacher { get; set; } = null!;

        public Course Course { get; set; } = null!;

    }
}
