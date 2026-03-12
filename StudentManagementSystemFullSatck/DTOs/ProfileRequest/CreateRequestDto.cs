using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystemFullStack.DTOs.ProfileRequest
{
    public class CreateRequestDto
    {

        [Required(ErrorMessage ="Filed Name is Required")]
        public string FieldName { get; set; } = string.Empty;
        public string OldValue { get; set; } = string.Empty;

        [Required(ErrorMessage ="New Value is Required")]
        public string NewValue { get; set; }=string.Empty;
    }
}
