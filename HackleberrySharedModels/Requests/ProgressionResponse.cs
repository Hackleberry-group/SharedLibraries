namespace HackleberrySharedModels.Requests
{
    public class ProgressionResponse
    {
        public Guid StudentId { get; set; }
        public double ProgressPercentage { get; set; }
        public List<ExerciseState> ExerciseStates { get; set; }
    }
}
