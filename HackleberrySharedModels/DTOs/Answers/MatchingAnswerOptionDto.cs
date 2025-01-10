using HackleberrySharedModels.Enums;

namespace HackleberrySharedModels.DTOs.Answers;

public record MatchingAnswerOptionDto : AnswerOptionDto
{
    public MatchingAnswerSidesEnum Side { get; init; }
    public Guid AnotherSideMatchingAnswerId { get; init; } = Guid.Empty;
}