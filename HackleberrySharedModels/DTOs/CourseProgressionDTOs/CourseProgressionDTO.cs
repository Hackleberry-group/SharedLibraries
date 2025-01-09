namespace HackleberryModels.DTOs.CourseProgressionDTOs
{
    public record CourseProgressionDTO
    {
        public Guid StudentId { get; init; }
        public Guid CourseId { get; init; }
        public string CourseName { get; init; }
        public string ProgrammingLanguage { get; init; }
        public int ProgressionPercentage { get; init; }
        public List<ModuleProgressionDTO> ModuleProgressions { get; init; } = new List<ModuleProgressionDTO>();
    }
}
