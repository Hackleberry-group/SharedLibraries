namespace HackleberryModels.DTOs.CourseProgressionDTOs
{
    public record ModuleProgressionDTO
    {
        public Guid ModuleId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int ProgressionPercentage { get; set; }
        public IEnumerable<TopicProgressionDTO> TopicProgressions { get; set; } = new List<TopicProgressionDTO>();
    }
}
