namespace StudentManagementSystemFullStack.Models
{
    public class Teacher : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Department { get; set; } = string.Empty;  

        public string Qualitfication { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public User User { get; set; } = null!; // Navigation property to User
    }
}
