namespace HackleberryModels.DTOs.CourseServiceDTOs;

public class ExerciseResponseDTO
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public bool IsTopicExam { get; set; }
    public Guid TopicId { get; set; }
}