namespace StudentManagementSystemFullStack.Models
{
    public class Mark : BaseEntity
    {
        public int Id { get; set; }
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public int TeacherId { get; set; }

        public decimal MarksObtained { get; set; } = 0;

        public decimal TotalMarks { get; set; }= 100;

        public string Grade { get; set; } = string.Empty;
        public Student Student { get; set; } = null!;

        public Teacher Teacher { get; set; } = null!;

       public Course Course { get; set; } = null!;
       

    }
}
