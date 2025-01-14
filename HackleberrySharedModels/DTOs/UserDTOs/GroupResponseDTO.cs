namespace HackleberryModels.DTOs.UserDTOs
{
    public record GroupResponseDTO
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public required string JoinCode { get; init; }
        public Guid TeacherId { get; init; }
        public IEnumerable<Guid> StudentIds { get; init; } = new List<Guid>();
    }
}
