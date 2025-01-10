namespace HackleberryModels.DTOs.ProgressionServiceDTOs
{
    public record SingleStatPostDTO
    {
        public Guid ExerciseId { get; set; }
        public bool IsExerciseCompleted { get; set; }
        public int NumberOfAnswersCorrect { get; set; }
        public int NumberOfAnswersIncorrect { get; set; }
    }
}
