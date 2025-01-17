namespace HackleberryModels.DTOs.CourseServiceDTOs;

public class TopicRequestDTO
{
    public string Name { get; set; }

    public Guid ModuleId { get; set; }

    public int Order { get; set; }
}