using System.ComponentModel.DataAnnotations;

namespace HackleberryModels.DTOs.CourseServiceDTOs;

public class ExerciseRequestDTO
{
    [Required]
    public int Order { get; set; }

    [Required]
    public Guid TopicId { get; set; }

    [Required]
    public bool? IsTopicExam { get; set; }
}
