using System;

namespace HackleberrySharedModels.Models
{
    public class SingleStatRequest
    {
        // public Guid StudentId { get; set; }
        public Guid ExerciseId { get; set; }
        public bool IsExerciseCompleted { get; set; }
        public int NumberOfAnswersCorrect { get; set; }
        public int NumberOfAnswersIncorrect { get; set; }
    }
}
