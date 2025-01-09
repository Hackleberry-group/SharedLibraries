using System.ComponentModel.DataAnnotations;
using HackleberrySharedModels.DTOs.Answers;

namespace HackleberrySharedModels.DTOs.Questions;

public record TrueOrFalseQuestionDto : MultipleChoiceQuestionDto
{
    public override IEnumerable<ValidationResult> ValidateQuestion(ValidationContext validationContext)
    {
        foreach (var validationResult in base.ValidateQuestion(validationContext))
        {
            yield return validationResult;
        }

        if (AnswerOptions.Count() != 2)
        {
            yield return new ValidationResult($"{GetNameOfQuestionType()} must have exactly 2 answer options",
                new[] { nameof(AnswerOptions) });
        }
        

        if (AnswerOptions.Any(a => !(a is MultipleChoiceAnswerOptionDto)))
        {
            yield return new ValidationResult(
                $"{GetNameOfQuestionType()} must have answer options of type  {nameof(MultipleChoiceAnswerOptionDto)}",
                new[] { nameof(AnswerOptions) });
        }

        foreach (var answerOption in AnswerOptions)
        {
            var text = answerOption.Text.ToLower();
            if (text != "true" && text != "false")
            {
                yield return new ValidationResult("Answer options must have text 'True' or 'False' (case-insensitive)",
                    new[] { nameof(AnswerOptions) });
            }
        }
    }
}