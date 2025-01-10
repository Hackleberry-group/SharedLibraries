namespace HackleberryModels.DTOs.ProgressionServiceDTOs
{
    public record ProgressionResponseDTO
    {
        public Guid StudentId { get; set; }
        public double ProgressPercentage { get; set; }
        public List<ExerciseStateDTO> ExerciseStates { get; set; }
    }
}
