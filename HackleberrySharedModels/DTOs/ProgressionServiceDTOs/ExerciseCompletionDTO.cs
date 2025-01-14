using HackleberryModels.DTOs.AchievementDTOs;

namespace HackleberryModels.DTOs.ProgressionServiceDTOs;

public record ExerciseCompletionDTO
{
    public Guid StudentId { get; set; }

    public int XPGained { get; set; }

    public int Level { get; set; }

    public int XPToNextLevel { get; set; }

    public double StreakModifier { get; set; }

    public AchievementDetailsDTO? NewAchievement { get; set; }
}