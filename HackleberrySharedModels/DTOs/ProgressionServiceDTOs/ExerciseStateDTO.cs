namespace HackleberryModels.DTOs.ProgressionServiceDTOs
{
    public record ExerciseStateDTO
    {
        public Guid ExcerciseId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
