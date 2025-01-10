using System.ComponentModel.DataAnnotations;

namespace HackleberrySharedModels.DTOs.Questions;

public record MatchingQuestionDto : BaseQuestionDto
{
    [Required]
    public string LeftColumnTitle { get; init; }
    [Required]
    public string RightColumnTitle { get; init; }
}