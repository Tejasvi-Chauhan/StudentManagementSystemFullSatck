namespace StudentManagementSystemFullStack.Models
{
    public class StudentCourse : BaseEntity
    {
        public int Id { get; set; }
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public string AssignedBy { get; set; } = string.Empty;

      

        public Student Student { get; set; } = null!; 

        public Course Course { get; set; } = null!; 

      
    }
}
