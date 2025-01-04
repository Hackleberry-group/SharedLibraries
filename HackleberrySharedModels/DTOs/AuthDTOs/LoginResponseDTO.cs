using System.ComponentModel.DataAnnotations;

namespace HackleberryModels.DTOs.AuthDTOs
{
    public record LoginResponseDTO
    {
        public string AccessToken { get; init; }

        //TODO: Add when refresh token is implemented
        //public string RefreshToken { get; init; } 
    }
}
