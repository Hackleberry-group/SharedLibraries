using System.ComponentModel.DataAnnotations;

namespace HackleberrySharedModels.DTOs.Answers;

public record CreateMatchingAnswerOptionDto : MatchingAnswerOptionDto
{
    [Required] 
    public MatchingAnswerOptionDto AnotherSideMatchingAnswer { get; init; }

    public override IEnumerable<ValidationResult> ValidateAnswerOption(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        var questionSide = Side;
        var anotherSide = AnotherSideMatchingAnswer.Side;

        if (questionSide == anotherSide)
        {
            results.Add(new ValidationResult("Both sides cannot be the same.",
                new[] { nameof(Side), nameof(AnotherSideMatchingAnswer) }));
        }
        
        return results;
    }
}