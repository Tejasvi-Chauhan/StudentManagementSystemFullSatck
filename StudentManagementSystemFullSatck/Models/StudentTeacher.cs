namespace StudentManagementSystemFullStack.Models
{
    public class StudentTeacher : BaseEntity
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int TeacherId { get; set; }

        public Student Student { get; set; } = null!;

        public Teacher Teacher { get; set; } = null!;
    }
}
