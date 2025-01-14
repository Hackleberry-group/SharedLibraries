using System.ComponentModel.DataAnnotations;

namespace HackleberryModels.DTOs.AuthDTOs
{
    public record LoginDTO
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email is not valid.")]
        public required string Email { get; init; }

        [Required(ErrorMessage = "Password is required.")]
        public required string Password { get; init; }
    }
}
