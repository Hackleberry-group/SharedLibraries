using System.ComponentModel;
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
        public string FirstName { get; init; }
        [Required]
        public string LastName { get; init; }
        [Required]
        public string StudentNumber { get; init; }
        [Required]
        public string Nickname { get; init; }
    }
}
