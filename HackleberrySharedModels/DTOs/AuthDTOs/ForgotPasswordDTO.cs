using System.ComponentModel.DataAnnotations;

namespace HackleberryModels.DTOs.AuthDTOs
{
    public record ForgotPasswordDTO
    {
        [Required, EmailAddress]
        public string Email { get; init; }
    }
}
