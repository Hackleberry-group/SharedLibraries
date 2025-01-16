using System.ComponentModel.DataAnnotations;

namespace HackleberryModels.DTOs.ProgressionServiceDTOs;

public class StudentAchievementDTO
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public string AchievementId { get; set; }
}