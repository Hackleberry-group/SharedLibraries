using System.ComponentModel.DataAnnotations;

namespace HackleberryModels.DTOs.AuthDTOs
{
    public record RegisterStudentDTO
    {
        [Required, EmailAddress]
        public required string Email { get; init; }
        
        [Required]
        public required string Password { get; init; }
        
        [Required]
        public required string ConfirmPassword { get; init; }
        
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public required string FirstName { get; init; }
        
        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public required string LastName { get; init; }
        
        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Student number must be numeric.")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Student number must be at least 6 numbers.")]
        public required string StudentNumber { get; init; }
        
        [Required]
        [StringLength(50, ErrorMessage = "Nickname cannot exceed 50 characters.")]
        public required string Nickname { get; init; }
    }
}
