namespace HackleberryModels.DTOs.XPServiceDTOs;

public record XPLogRequestDTO
{
    public Guid StudentId { get; init; }

    public int Exp { get; init; }

    public Guid CourseId { get; init; }
}