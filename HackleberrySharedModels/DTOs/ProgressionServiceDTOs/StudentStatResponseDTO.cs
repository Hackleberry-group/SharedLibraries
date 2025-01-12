namespace HackleberryModels.DTOs.ProgressionServiceDTOs
{
    public record StudentStatResponseDTO
    {
        public Guid StudentId { get; set; }
        public int TotalNumberOfAnswersCorrect { get; set; }
        public int TotalNumberOfAnswersIncorrect { get; set; }
        public int TotalNumberOfExercisesCompleted { get; set; }
        public int TotalXP { get; set; }
        public int Level { get; set; }
        public int XPToNextLevel { get; set; }
        public int StreakNumber { get; set; }
        public bool StreakFreezeAvailable { get; set; }
        public DateTime LastStreakDay { get; set; }
    }
}
