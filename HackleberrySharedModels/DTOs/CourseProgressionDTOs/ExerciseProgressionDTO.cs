namespace HackleberryModels.DTOs.CourseProgressionDTOs
{
    public record ExerciseProgressionDTO
    {
        public Guid ExerciseId { get; set; }
        public bool IsTopicExam { get; set; }
        public int Order { get; set; }
        public bool IsCompleted { get; set; }
    }
}
