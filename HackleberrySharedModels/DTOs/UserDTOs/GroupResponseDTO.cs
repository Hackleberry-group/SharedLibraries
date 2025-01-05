namespace HackleberryModels.DTOs.UserDTOs
{
    public record GroupResponseDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string JoinCode { get; init; }
        public Guid TeacherId { get; init; }
        public IEnumerable<Guid> StudentIds { get; init; }
    }
}
