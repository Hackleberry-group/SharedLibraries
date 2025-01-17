namespace HackleberryModels.DTOs.CourseServiceDTOs;

public class ExerciseRequestDTO
{
    public int Order { get; set; }

    public Guid TopicId { get; set; }

    public bool? IsTopicExam { get; set; }
}
