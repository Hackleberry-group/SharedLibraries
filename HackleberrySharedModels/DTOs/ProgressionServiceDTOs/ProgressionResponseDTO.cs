namespace HackleberryModels.DTOs.ProgressionServiceDTOs
{
    public record ProgressionResponseDTO
    {
        public Guid StudentId { get; set; }
        public double ProgressPercentage { get; set; }
        public IEnumerable<ExerciseStateDTO> ExerciseStates { get; set; }
    }
}
