using System.ComponentModel.DataAnnotations;
namespace StudentManagementSystemFullStack.Models
{
    public class Student
    {
        public int Id { get; set; }
      
        public int UserId { get; set; }

      
        public string RollNumber { get; set; }=string.Empty;

        public DateTime DateOfBirth { get; set; }
       
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User User { get; set; } = null!; // Navigation property to User


    }
}
