using System.ComponentModel.DataAnnotations;

namespace HackleberryModels.DTOs.CourseServiceDTOs;

public class TopicRequestDTO
{
    [Required]
    public string Name { get; set; }

    [Required]
    public Guid ModuleId { get; set; }

    [Required]
    public int Order { get; set; }
}