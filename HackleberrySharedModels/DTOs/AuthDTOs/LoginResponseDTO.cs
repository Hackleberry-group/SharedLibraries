namespace HackleberryModels.DTOs.AuthDTOs
{
    public record LoginResponseDTO
    {
        public required string AccessToken { get; init; }
        public required string RefreshToken { get; init; } 
    }
}
