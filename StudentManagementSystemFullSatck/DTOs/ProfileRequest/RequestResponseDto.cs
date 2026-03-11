namespace StudentManagementSystemFullStack.DTOs.ProfileRequest
{
    public class RequestResponseDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }=string.Empty;
        public string FieldName { get; set; } = string.Empty;
        public string OldValue { get; set; } 
        public string NewValue { get; set; }=string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime RequestedAt { get; set; }
        public string? ReviewerName { get; set; }
        public string? AdminNote { get; set; }

    }
}
