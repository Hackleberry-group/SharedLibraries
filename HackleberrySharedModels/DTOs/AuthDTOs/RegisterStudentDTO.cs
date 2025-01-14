using System.ComponentModel.DataAnnotations;

namespace HackleberryModels.DTOs.AuthDTOs
{
    public record RegisterStudentDTO
    {
        [Required, EmailAddress]
        public string Email { get; init; }
        [Required]
        public string Password { get; init; }
        [Required]
        public string ConfirmPassword { get; init; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; init; }
        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; init; }
        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Student number must be numeric.")]
        public string StudentNumber { get; init; }
        [Required]
        [StringLength(50, ErrorMessage = "Nick name cannot exceed 50 characters.")]
        public string Nickname { get; init; }
    }
}
