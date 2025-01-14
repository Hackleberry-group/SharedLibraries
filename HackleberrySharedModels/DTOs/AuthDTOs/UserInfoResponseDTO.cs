namespace HackleberryModels.DTOs.AuthDTOs
{
    public record  UserInfoResponseDTO
    {
        public Guid Id { get; init; }
        public string PreferredUsername { get; init; }
        public string Name { get; init; }
        public string Email { get; init; }
        public string Role { get; init; }
    }
}
