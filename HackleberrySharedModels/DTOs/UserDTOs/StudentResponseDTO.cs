namespace HackleberryModels.DTOs.UserDTOs
{
    public record StudentResponseDTO
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string StudentNumber { get; init; }
        public string Nickname { get; init; }
        public IEnumerable<Guid> GroupIds { get; init; }
    }
}
