namespace HackleberryModels.DTOs.UserDTOs
{
    public record TeacherResponseDTO
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string TeacherNumber { get; init; }
        public IEnumerable<Guid> GroupIds { get; init; }
    }
}
