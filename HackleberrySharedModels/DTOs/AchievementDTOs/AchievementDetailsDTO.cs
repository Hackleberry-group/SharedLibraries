namespace HackleberryModels.DTOs.AchievementDTOs;

public record AchievementDetailsDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string? FileUrl { get; set; }

    public AchievementDetailsDTO(string name, string description, string? fileUrl)
    {
        Name = name;
        Description = description;
        FileUrl = fileUrl;
    }
}