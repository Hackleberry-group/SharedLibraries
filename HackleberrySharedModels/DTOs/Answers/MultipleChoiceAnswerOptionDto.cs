namespace HackleberrySharedModels.DTOs.Answers;

public record MultipleChoiceAnswerOptionDto : AnswerOptionDto
{
    public bool IsCorrect { get; init; }
}