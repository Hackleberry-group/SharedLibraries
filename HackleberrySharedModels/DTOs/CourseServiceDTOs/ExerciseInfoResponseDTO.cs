namespace HackleberryModels.DTOs.CourseServiceDTOs;

public class ExerciseInfoResponseDTO
{
    public Guid ExerciseId { get; init; }
    public Guid CourseId { get; init; }
    public bool IsTopicExam { get; init; }
    public List<Guid> ExerciseIdsInTopic { get; init; } = new List<Guid>();
}
