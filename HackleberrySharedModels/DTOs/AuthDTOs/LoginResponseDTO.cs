using System.ComponentModel.DataAnnotations;

namespace HackleberryModels.DTOs.AuthDTOs
{
    public record LoginResponseDTO
    {
        public string AccessToken { get; init; }
        public string RefreshToken { get; init; } 
    }
}
