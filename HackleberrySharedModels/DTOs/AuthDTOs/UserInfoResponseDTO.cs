namespace HackleberryModels.DTOs.AuthDTOs
{
    public record  UserInfoResponseDTO
    {
        public Guid Id { get; init; }
        public required string PreferredUsername { get; init; }
        public required string Name { get; init; }
        public required string Email { get; init; }
        public required string Role { get; init; }
    }
}
