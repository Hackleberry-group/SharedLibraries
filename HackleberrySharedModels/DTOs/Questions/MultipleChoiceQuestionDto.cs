using System.ComponentModel.DataAnnotations;
using HackleberrySharedModels.DTOs.Answers;

namespace HackleberrySharedModels.DTOs.Questions;

public record MultipleChoiceQuestionDto : BaseCodeBlockTextableAndTextableQuestionDto
{
    public override IEnumerable<ValidationResult> ValidateQuestion(ValidationContext validationContext)
    {
        foreach (var validationResult in base.ValidateQuestion(validationContext))
        {
            yield return validationResult;
        }

        if (AnswerOptions.OfType<MultipleChoiceAnswerOptionDto>().Count(a => a.IsCorrect) < 1)
        {
            yield return new ValidationResult($" {GetNameOfQuestionType()} must have at least 1 correct answer option",
                new[] { nameof(AnswerOptions) });
        }
    }
}