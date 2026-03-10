namespace StudentManagementSystemFullStack.Models
{
    public class ProfileUpdateRequest
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public  string FieldName { get; set; }= string.Empty;

        public string OldValue { get; set; } = string.Empty;

        public string NewValue { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";

        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;

        public int ReviewedBy { get; set; }

        public DateTime? ReviewedAt { get; set; }

        public User User { get; set; } = null!;
         public Student Student { get; set; } = null!;
    }
}
