namespace StudentManagementSystemFullStack.Models
{
    public class ProfileUpdateRequest : BaseEntity
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public  string FieldName { get; set; }= string.Empty;

        public string OldValue { get; set; } = string.Empty;

        public string NewValue { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";

        public int? ReviewedBy { get; set; }

        public DateTime? ReviewedAt { get; set; }

        public User? Reviewer { get; set; } 
         public Student Student { get; set; } = null!;
    }
}
