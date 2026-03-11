using System.ComponentModel.DataAnnotations;
namespace StudentManagementSystemFullStack.Models
{
    public class Student : BaseEntity
    {
        public int Id { get; set; }
      
        public int UserId { get; set; }

      
        public string RollNumber { get; set; }=string.Empty;

        public DateTime DateOfBirth { get; set; }
       
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } 

        public User User { get; set; } = null!; // Navigation property to User


    }
}
