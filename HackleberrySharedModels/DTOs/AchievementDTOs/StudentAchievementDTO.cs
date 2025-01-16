namespace HackleberryModels.DTOs.AchievementDTOs;

public class StudentAchievementDTO
{
    public required string PartitionKey { get; set; }
    public required string RowKey { get; set; }
    public required string AchievementId { get; set; }
}