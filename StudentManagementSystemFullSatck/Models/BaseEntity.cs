namespace StudentManagementSystemFullStack.Models
{
    public class BaseEntity
    {
        public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; }= DateTime.Now;

        public DateTime? ModifiedAt { get; set; }

        public int CreatedBy { get; set; }

        public int ModifiedBy { get; set; }


    }
}
