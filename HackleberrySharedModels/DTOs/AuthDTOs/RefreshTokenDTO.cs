using System.ComponentModel.DataAnnotations;

namespace HackleberryModels.DTOs.AuthDTOs
{
    public record RefreshTokenDTO
    {
        [Required]
        public Guid UserId { get; init; }

        [Required]
        public string RefreshToken { get; init; }
    }
}
