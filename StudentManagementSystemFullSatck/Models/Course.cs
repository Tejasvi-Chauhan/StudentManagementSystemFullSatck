namespace StudentManagementSystemFullStack.Models
{
    public class Course : BaseEntity
    {
        public int Id { get; set; }
        public string CourseName { get; set; }= string.Empty;

        public string  CourseCode { get; set; }=string.Empty;

       


    }
}
