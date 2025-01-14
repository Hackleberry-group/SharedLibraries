namespace HackleberryModels.DTOs.CourseProgressionDTOs
{
    public record TopicProgressionDTO
    {
        public Guid TopicId { get; set; }
        public required string Name { get; set; }
        public int Order { get; set; }
        public int ProgressionPercentage { get; set; }
        public List<ExerciseProgressionDTO> ExerciseProgressions { get; set; } = new List<ExerciseProgressionDTO>();
    }
}
