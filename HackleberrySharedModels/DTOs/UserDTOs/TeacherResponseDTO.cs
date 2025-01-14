namespace HackleberryModels.DTOs.UserDTOs
{
    public record TeacherResponseDTO
    {
        public Guid Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Email { get; init; }
        public required string TeacherNumber { get; init; }
        public IEnumerable<Guid> GroupIds { get; init; } = new List<Guid>();
    }
}
