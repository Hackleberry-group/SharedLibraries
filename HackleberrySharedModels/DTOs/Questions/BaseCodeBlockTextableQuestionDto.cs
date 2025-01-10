namespace HackleberrySharedModels.DTOs.Questions;

public record BaseCodeBlockTextableQuestionDto : BaseQuestionDto
{
    public string? CodeBlockText { get; init; } 
}